using System.Globalization;
using System.Text;

namespace Task2.SocialNetwork.ConsoleUi.Formatting;

using Posts;

internal static class PostFormatter
{
    private const string DateFormat = "yyyy-MM-dd HH:mm";
    private const string PostPrefix = "Post #";
    private const string ByLabel = " by ";
    private const string DateSeparator = " | ";
    private const string Indent = "  ";
    private const string LikesLabel = "  Likes: ";
    private const string CommentsLabel = "  Comments: ";
    private const string CommentPrefix = "    - ";
    private const string CommentDateOpening = " (";
    private const string CommentDateClosing = "): ";
    private const string NoPostsMessage = "No posts yet.";

    public static string Format(PostView post)
    {
        StringBuilder text = new StringBuilder();
        text.AppendLine(PostPrefix + post.Id + ByLabel + post.AuthorNickname + DateSeparator + FormatDate(post.CreatedAt));
        text.AppendLine(Indent + post.Text);
        text.AppendLine(LikesLabel + post.LikeCount);
        text.AppendLine(CommentsLabel + post.Comments.Count);

        foreach (CommentView comment in post.Comments)
        {
            text.AppendLine(FormatComment(comment));
        }

        return text.ToString();
    }

    public static string FormatMany(IReadOnlyList<PostView> posts)
    {
        if (posts.Count == 0)
        {
            return NoPostsMessage;
        }

        return string.Join(Environment.NewLine, posts.Select(Format));
    }

    private static string FormatComment(CommentView comment)
    {
        return CommentPrefix + comment.AuthorNickname + CommentDateOpening + FormatDate(comment.CreatedAt)
               + CommentDateClosing + comment.Text;
    }

    private static string FormatDate(DateTime date)
    {
        return date.ToString(DateFormat, CultureInfo.InvariantCulture);
    }
}
