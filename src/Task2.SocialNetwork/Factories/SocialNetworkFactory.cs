namespace Task2.SocialNetwork.Factories;

using Application;
using Data;
using Time;
using Users;

public static class SocialNetworkFactory
{
    public static ISocialNetwork Create(IReadOnlyList<UserProfile> users, IClock clock)
    {
        return new SocialNetworkPlatform(UserDirectoryFactory.Create(users), PostServiceFactory.Create(), clock);
    }

    public static ISocialNetwork CreateWithSeedData(IClock clock)
    {
        IUserDirectory users = UserDirectoryFactory.Create(SeedData.CreateUsers());
        IPostService posts = PostServiceFactory.Create();
        SeedData.PublishPosts(users, posts);

        return new SocialNetworkPlatform(users, posts, clock);
    }
}
