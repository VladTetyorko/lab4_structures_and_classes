namespace Task2.SocialNetwork.ConsoleUi.Commands;

using Application;
using Session;
using Views;

internal sealed class CommentPostCommand : PostCommand
{
    private const string CommandTitle = "Comment on a post";

    public CommentPostCommand(SessionContext context, ISocialNetworkView view) : base(context, view)
    {
    }

    public override string Title => CommandTitle;

    protected override void ExecuteForPost(IUserSession session, int postId)
    {
        View.ShowPost(session.CommentPost(postId, View.AskCommentText()));
    }
}
