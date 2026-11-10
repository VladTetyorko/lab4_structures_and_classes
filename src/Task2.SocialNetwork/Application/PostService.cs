namespace Task2.SocialNetwork.Application;

using Exceptions;
using Factories;
using Posts;
using Users;
using Validation;

internal sealed class PostService : IPostService
{
    private readonly IPostRepository _posts;

    public PostService(IPostRepository posts)
    {
        _posts = posts;
    }

    public PostView Publish(UserProfile author, string text, DateTime createdAt)
    {
        PostContentValidator.ValidatePostText(text);
        Post post = PostFactory.Create(_posts.NextId(), author.Nickname, createdAt, text.Trim());
        _posts.Add(post);

        return PostViewFactory.Create(post);
    }

    public PostView Edit(UserProfile actor, int postId, string newText)
    {
        PostContentValidator.ValidatePostText(newText);
        Post post = FindOwnPost(actor, postId);
        post.ChangeText(newText.Trim());

        return PostViewFactory.Create(post);
    }

    public void Delete(UserProfile actor, int postId)
    {
        FindOwnPost(actor, postId);
        _posts.Remove(postId);
    }

    public PostView Like(UserProfile actor, int postId)
    {
        Post post = _posts.Find(postId);
        post.AddLike(actor.Nickname);

        return PostViewFactory.Create(post);
    }

    public PostView Comment(UserProfile actor, int postId, string text, DateTime createdAt)
    {
        PostContentValidator.ValidateCommentText(text);
        Post post = _posts.Find(postId);
        post.AddComment(CommentFactory.Create(actor.Nickname, text.Trim(), createdAt));

        return PostViewFactory.Create(post);
    }

    public IReadOnlyList<PostView> GetLatest(UserProfile owner, int count)
    {
        return _posts.FindLatestByAuthor(owner.Nickname, count).Select(PostViewFactory.Create).ToArray();
    }

    private Post FindOwnPost(UserProfile actor, int postId)
    {
        Post post = _posts.Find(postId);

        if (!post.IsAuthoredBy(actor.Nickname))
        {
            throw SocialNetworkExceptionFactory.PostOwnership(postId);
        }

        return post;
    }
}
