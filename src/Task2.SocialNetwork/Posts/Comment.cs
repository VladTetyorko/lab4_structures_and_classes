namespace Task2.SocialNetwork.Posts;

internal sealed class Comment
{
    public Comment(string authorNickname, string text, DateTime createdAt)
    {
        AuthorNickname = authorNickname;
        Text = text;
        CreatedAt = createdAt;
    }

    public string AuthorNickname { get; }

    public string Text { get; }

    public DateTime CreatedAt { get; }
}
