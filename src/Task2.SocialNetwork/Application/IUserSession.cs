namespace Task2.SocialNetwork.Application;

using Posts;
using Users;

public interface IUserSession
{
    UserProfile CurrentUser { get; }

    PostView CreatePost(string text);

    PostView EditPost(int postId, string newText);

    void DeletePost(int postId);

    PostView LikePost(int postId);

    PostView CommentPost(int postId, string text);

    IReadOnlyList<PostView> GetLatestPosts(string nickname);
}
