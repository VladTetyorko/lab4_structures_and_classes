namespace Task2.SocialNetwork.ConsoleUi.Commands;

using Application;
using Session;
using Views;

internal abstract class PostCommand : SessionCommand
{
    protected PostCommand(SessionContext context, ISocialNetworkView view) : base(context, view)
    {
    }

    protected override void ExecuteFor(IUserSession session)
    {
        int? postId = View.AskPostId();

        if (postId != null)
        {
            ExecuteForPost(session, postId.Value);
        }
    }

    protected abstract void ExecuteForPost(IUserSession session, int postId);
}
