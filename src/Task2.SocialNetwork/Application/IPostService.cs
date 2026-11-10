namespace Task2.SocialNetwork.Application;

using Posts;
using Users;

internal interface IPostService
{
    PostView Publish(UserProfile author, string text, DateTime createdAt);

    PostView Edit(UserProfile actor, int postId, string newText);

    void Delete(UserProfile actor, int postId);

    PostView Like(UserProfile actor, int postId);

    PostView Comment(UserProfile actor, int postId, string text, DateTime createdAt);

    IReadOnlyList<PostView> GetLatest(UserProfile owner, int count);
}
