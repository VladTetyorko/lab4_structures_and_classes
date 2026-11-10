namespace Task2.SocialNetwork.Application;

using Posts;
using Time;
using Users;

internal sealed class UserSession : IUserSession
{
    private const int LatestPostsCount = 5;

    private readonly IUserDirectory _users;
    private readonly IPostService _posts;
    private readonly IClock _clock;

    public UserSession(UserProfile currentUser, IUserDirectory users, IPostService posts, IClock clock)
    {
        CurrentUser = currentUser;
        _users = users;
        _posts = posts;
        _clock = clock;
    }

    public UserProfile CurrentUser { get; }

    public PostView CreatePost(string text) => _posts.Publish(CurrentUser, text, _clock.Now);

    public PostView EditPost(int postId, string newText) => _posts.Edit(CurrentUser, postId, newText);

    public void DeletePost(int postId) => _posts.Delete(CurrentUser, postId);

    public PostView LikePost(int postId) => _posts.Like(CurrentUser, postId);

    public PostView CommentPost(int postId, string text) => _posts.Comment(CurrentUser, postId, text, _clock.Now);

    public IReadOnlyList<PostView> GetLatestPosts(string nickname)
    {
        return _posts.GetLatest(_users.Find(nickname), LatestPostsCount);
    }
}
