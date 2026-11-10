namespace Task2.SocialNetwork.Posts;

public sealed class PostView
{
    internal PostView(int id, string authorNickname, DateTime createdAt, string text, int likeCount,
        IReadOnlyList<CommentView> comments)
    {
        Id = id;
        AuthorNickname = authorNickname;
        CreatedAt = createdAt;
        Text = text;
        LikeCount = likeCount;
        Comments = comments;
    }

    public int Id { get; }

    public string AuthorNickname { get; }

    public DateTime CreatedAt { get; }

    public string Text { get; }

    public int LikeCount { get; }

    public IReadOnlyList<CommentView> Comments { get; }
}
