using Task2.SocialNetwork.Application;
using Task2.SocialNetwork.Exceptions;
using Task2.SocialNetwork.ConsoleUi.Formatting;
using Task2.SocialNetwork.Posts;

namespace Lab.Tests.Task2.SocialNetwork;

public sealed class PostReactionTests
{
    public void ShouldLikeSomeoneElsesPost()
    {
        ISocialNetwork network = TestNetwork.Create();
        PostView bobPost = network.SignIn(TestNetwork.Bob).CreatePost("Like me");

        PostView liked = network.SignIn(TestNetwork.Alice).LikePost(bobPost.Id);

        Assertions.AreEqual(1, liked.LikeCount);
    }

    public void ShouldForbidLikingOwnPost()
    {
        IUserSession alice = TestNetwork.Create().SignIn(TestNetwork.Alice);
        PostView post = alice.CreatePost("Self-love");

        Assertions.Throws<SelfLikeException>(() => alice.LikePost(post.Id), "own post");
    }

    public void ShouldForbidLikingTheSamePostTwice()
    {
        ISocialNetwork network = TestNetwork.Create();
        PostView bobPost = network.SignIn(TestNetwork.Bob).CreatePost("Like me");
        IUserSession alice = network.SignIn(TestNetwork.Alice);
        alice.LikePost(bobPost.Id);

        Assertions.Throws<DuplicateLikeException>(() => alice.LikePost(bobPost.Id), "second like");
    }

    public void ShouldAddCommentWithAuthor()
    {
        ISocialNetwork network = TestNetwork.Create();
        PostView bobPost = network.SignIn(TestNetwork.Bob).CreatePost("Thoughts?");

        PostView commented = network.SignIn(TestNetwork.Alice).CommentPost(bobPost.Id, "Nice one");

        Assertions.AreEqual(1, commented.Comments.Count);
        Assertions.AreEqual(TestNetwork.Alice, commented.Comments[0].AuthorNickname);
        Assertions.AreEqual("Nice one", commented.Comments[0].Text);
    }

    public void ShouldRejectEmptyComment()
    {
        ISocialNetwork network = TestNetwork.Create();
        PostView bobPost = network.SignIn(TestNetwork.Bob).CreatePost("Thoughts?");

        Assertions.Throws<InvalidCommentTextException>(
            () => network.SignIn(TestNetwork.Alice).CommentPost(bobPost.Id, ""), "empty comment");
    }

    public void ShouldKeepOldSnapshotUnchangedAfterLike()
    {
        ISocialNetwork network = TestNetwork.Create();
        PostView snapshot = network.SignIn(TestNetwork.Bob).CreatePost("Like me");

        network.SignIn(TestNetwork.Alice).LikePost(snapshot.Id);

        Assertions.AreEqual(0, snapshot.LikeCount);
    }

    public void ShouldPrintFullPostInformation()
    {
        ISocialNetwork network = TestNetwork.Create();
        PostView bobPost = network.SignIn(TestNetwork.Bob).CreatePost("Thoughts?");
        network.SignIn(TestNetwork.Alice).LikePost(bobPost.Id);
        PostView commented = network.SignIn(TestNetwork.Alice).CommentPost(bobPost.Id, "Nice one");

        string text = PostFormatter.Format(commented);

        Assertions.IsTrue(text.Contains("by @bob | 2026-11-01 09:00"), "author and date");
        Assertions.IsTrue(text.Contains("Likes: 1"), "likes");
        Assertions.IsTrue(text.Contains("@alice (2026-11-01 09:00): Nice one"), "comment");
    }
}
