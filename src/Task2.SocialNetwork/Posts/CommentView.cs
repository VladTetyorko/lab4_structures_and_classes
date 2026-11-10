namespace Task2.SocialNetwork.Posts;

public sealed class CommentView
{
    internal CommentView(string authorNickname, string text, DateTime createdAt)
    {
        AuthorNickname = authorNickname;
        Text = text;
        CreatedAt = createdAt;
    }

    public string AuthorNickname { get; }

    public string Text { get; }

    public DateTime CreatedAt { get; }
}
