namespace Task2.SocialNetwork.Factories;

using Application;
using Posts;

internal static class PostServiceFactory
{
    public static IPostService Create()
    {
        return new PostService(new PostRepository());
    }
}
