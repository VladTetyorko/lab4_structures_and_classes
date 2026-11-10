namespace Task2.SocialNetwork.Factories;

using Posts;

internal static class CommentFactory
{
    public static Comment Create(string authorNickname, string text, DateTime createdAt)
    {
        return new Comment(authorNickname, text, createdAt);
    }
}
