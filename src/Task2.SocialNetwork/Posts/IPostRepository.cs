namespace Task2.SocialNetwork.Posts;

internal interface IPostRepository
{
    int NextId();

    void Add(Post post);

    Post Find(int postId);

    void Remove(int postId);

    IReadOnlyList<Post> FindLatestByAuthor(string nickname, int count);
}
