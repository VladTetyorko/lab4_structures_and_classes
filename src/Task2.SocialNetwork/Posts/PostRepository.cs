namespace Task2.SocialNetwork.Posts;

using Exceptions;

internal sealed class PostRepository : IPostRepository
{
    private readonly Dictionary<int, Post> _postsById = new Dictionary<int, Post>();
    private int _lastId;

    public int NextId()
    {
        _lastId++;

        return _lastId;
    }

    public void Add(Post post)
    {
        _postsById.Add(post.Id, post);
    }

    public Post Find(int postId)
    {
        if (_postsById.TryGetValue(postId, out Post? post))
        {
            return post;
        }

        throw SocialNetworkExceptionFactory.PostNotFound(postId);
    }

    public void Remove(int postId)
    {
        if (!_postsById.Remove(postId))
        {
            throw SocialNetworkExceptionFactory.PostNotFound(postId);
        }
    }

    public IReadOnlyList<Post> FindLatestByAuthor(string nickname, int count)
    {
        return _postsById.Values
            .Where(post => post.IsAuthoredBy(nickname))
            .OrderByDescending(post => post.CreatedAt)
            .ThenByDescending(post => post.Id)
            .Take(count)
            .ToArray();
    }
}
