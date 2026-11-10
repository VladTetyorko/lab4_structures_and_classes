namespace Task2.SocialNetwork.Factories;

using Posts;

internal static class PostViewFactory
{
    public static PostView Create(Post post)
    {
        CommentView[] comments = post.Comments.Select(CreateComment).ToArray();

        return new PostView(post.Id, post.AuthorNickname, post.CreatedAt, post.Text, post.LikeCount,
            Array.AsReadOnly(comments));
    }

    private static CommentView CreateComment(Comment comment)
    {
        return new CommentView(comment.AuthorNickname, comment.Text, comment.CreatedAt);
    }
}
