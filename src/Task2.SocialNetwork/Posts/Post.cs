namespace Task2.SocialNetwork.Posts;

using Exceptions;

internal sealed class Post
{
    private readonly HashSet<string> _likedBy = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    private readonly List<Comment> _comments = new List<Comment>();

    public Post(int id, string authorNickname, DateTime createdAt, string text)
    {
        Id = id;
        AuthorNickname = authorNickname;
        CreatedAt = createdAt;
        Text = text;
    }

    public int Id { get; }

    public string AuthorNickname { get; }

    public DateTime CreatedAt { get; }

    public string Text { get; private set; }

    public int LikeCount => _likedBy.Count;

    public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();

    public bool IsAuthoredBy(string nickname)
    {
        return string.Equals(AuthorNickname, nickname, StringComparison.OrdinalIgnoreCase);
    }

    public void AddLike(string likerNickname)
    {
        if (IsAuthoredBy(likerNickname))
        {
            throw SocialNetworkExceptionFactory.SelfLike(Id);
        }

        if (!_likedBy.Add(likerNickname))
        {
            throw SocialNetworkExceptionFactory.DuplicateLike(Id);
        }
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void ChangeText(string newText)
    {
        Text = newText;
    }
}
