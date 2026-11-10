using Task2.SocialNetwork.Application;
using Task2.SocialNetwork.Factories;
using Task2.SocialNetwork.Posts;

namespace Lab.Tests.Task2.SocialNetwork;

public sealed class SeedDataTests
{
    public void ShouldDescribeUsersInCode()
    {
        ISocialNetwork network = SocialNetworkFactory.CreateWithSeedData(ClockFactory.CreateSystem());

        Assertions.AreEqual(4, network.Users.Count);
        Assertions.IsTrue(network.Users.All(user => user.Nickname.StartsWith('@')), "nicknames start with @");
    }

    public void ShouldLimitSeededFeedToFiveNewestPosts()
    {
        ISocialNetwork network = SocialNetworkFactory.CreateWithSeedData(ClockFactory.CreateSystem());

        IReadOnlyList<PostView> latest = network.SignIn("@taras").GetLatestPosts("@olena");

        Assertions.AreEqual(5, latest.Count);
        Assertions.IsTrue(latest[0].CreatedAt > latest[4].CreatedAt, "newest first");
    }

    public void ShouldContainSeededLikesAndComments()
    {
        ISocialNetwork network = SocialNetworkFactory.CreateWithSeedData(ClockFactory.CreateSystem());

        IReadOnlyList<PostView> irynaPosts = network.SignIn("@olena").GetLatestPosts("@iryna_b");
        PostView library = irynaPosts.Single(post => post.Text.Contains("open-source"));

        Assertions.AreEqual(2, library.LikeCount);
        Assertions.AreEqual(1, library.Comments.Count);
    }
}
