using Lab.Tests.Fakes;
using Task2.SocialNetwork.Application;
using Task2.SocialNetwork.Exceptions;
using Task2.SocialNetwork.Posts;

namespace Lab.Tests.Task2.SocialNetwork;

public sealed class PostManagementTests
{
    public void ShouldCreatePostWithAuthorDateAndText()
    {
        IUserSession alice = TestNetwork.Create().SignIn(TestNetwork.Alice);

        PostView post = alice.CreatePost("  Hello world  ");

        Assertions.AreEqual(TestNetwork.Alice, post.AuthorNickname);
        Assertions.AreEqual("Hello world", post.Text);
        Assertions.IsTrue(post.CreatedAt == TestNetwork.Start, "date comes from the clock");
        Assertions.AreEqual(0, post.LikeCount);
    }

    public void ShouldRejectEmptyPost()
    {
        IUserSession alice = TestNetwork.Create().SignIn(TestNetwork.Alice);

        Assertions.Throws<InvalidPostTextException>(() => alice.CreatePost("   "), "blank text");
    }

    public void ShouldReturnOnlyFiveNewestPostsNewestFirst()
    {
        ManualClock clock = new ManualClock(TestNetwork.Start);
        IUserSession alice = TestNetwork.Create(clock).SignIn(TestNetwork.Alice);
        PublishNumberedPosts(alice, clock, 7);

        IReadOnlyList<PostView> latest = alice.GetLatestPosts(TestNetwork.Alice);

        Assertions.AreEqual(5, latest.Count);
        Assertions.AreEqual("Post 7", latest[0].Text);
        Assertions.AreEqual("Post 3", latest[4].Text);
    }

    public void ShouldShowPostsOfAnotherUser()
    {
        ISocialNetwork network = TestNetwork.Create();
        network.SignIn(TestNetwork.Bob).CreatePost("Bob's thoughts");

        IReadOnlyList<PostView> bobPosts = network.SignIn(TestNetwork.Alice).GetLatestPosts(TestNetwork.Bob);

        Assertions.AreEqual(1, bobPosts.Count);
        Assertions.AreEqual("Bob's thoughts", bobPosts[0].Text);
    }

    public void ShouldDeleteOwnPost()
    {
        IUserSession alice = TestNetwork.Create().SignIn(TestNetwork.Alice);
        PostView post = alice.CreatePost("Temporary");

        alice.DeletePost(post.Id);

        Assertions.AreEqual(0, alice.GetLatestPosts(TestNetwork.Alice).Count);
    }

    public void ShouldForbidDeletingSomeoneElsesPost()
    {
        ISocialNetwork network = TestNetwork.Create();
        PostView bobPost = network.SignIn(TestNetwork.Bob).CreatePost("Mine");
        IUserSession alice = network.SignIn(TestNetwork.Alice);

        Assertions.Throws<PostOwnershipException>(() => alice.DeletePost(bobPost.Id), "foreign post");
        Assertions.AreEqual(1, alice.GetLatestPosts(TestNetwork.Bob).Count);
    }

    public void ShouldEditOwnPost()
    {
        IUserSession alice = TestNetwork.Create().SignIn(TestNetwork.Alice);
        PostView post = alice.CreatePost("Draft");

        PostView edited = alice.EditPost(post.Id, "Final");

        Assertions.AreEqual("Final", edited.Text);
    }

    public void ShouldForbidEditingSomeoneElsesPost()
    {
        ISocialNetwork network = TestNetwork.Create();
        PostView bobPost = network.SignIn(TestNetwork.Bob).CreatePost("Mine");
        IUserSession alice = network.SignIn(TestNetwork.Alice);

        Assertions.Throws<PostOwnershipException>(() => alice.EditPost(bobPost.Id, "Hacked"), "foreign post");
        Assertions.AreEqual("Mine", alice.GetLatestPosts(TestNetwork.Bob)[0].Text);
    }

    public void ShouldThrowForMissingPost()
    {
        IUserSession alice = TestNetwork.Create().SignIn(TestNetwork.Alice);

        Assertions.Throws<PostNotFoundException>(() => alice.DeletePost(999), "missing post");
    }

    private static void PublishNumberedPosts(IUserSession session, ManualClock clock, int count)
    {
        for (int number = 1; number <= count; number++)
        {
            session.CreatePost("Post " + number);
            clock.AdvanceMinutes(1);
        }
    }
}
