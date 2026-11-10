namespace Task2.SocialNetwork.Factories;

using Posts;

internal static class PostFactory
{
    public static Post Create(int id, string authorNickname, DateTime createdAt, string text)
    {
        return new Post(id, authorNickname, createdAt, text);
    }
}
