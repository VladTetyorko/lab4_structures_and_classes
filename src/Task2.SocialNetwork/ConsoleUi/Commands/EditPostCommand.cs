namespace Task2.SocialNetwork.ConsoleUi.Commands;

using Application;
using Session;
using Views;

internal sealed class EditPostCommand : PostCommand
{
    private const string CommandTitle = "Edit my post";

    public EditPostCommand(SessionContext context, ISocialNetworkView view) : base(context, view)
    {
    }

    public override string Title => CommandTitle;

    protected override void ExecuteForPost(IUserSession session, int postId)
    {
        View.ShowPost(session.EditPost(postId, View.AskPostText()));
    }
}
