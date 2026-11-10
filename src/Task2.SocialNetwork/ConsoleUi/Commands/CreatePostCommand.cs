namespace Task2.SocialNetwork.ConsoleUi.Commands;

using Application;
using Session;
using Views;

internal sealed class CreatePostCommand : SessionCommand
{
    private const string CommandTitle = "Create a post";

    public CreatePostCommand(SessionContext context, ISocialNetworkView view) : base(context, view)
    {
    }

    public override string Title => CommandTitle;

    protected override void ExecuteFor(IUserSession session)
    {
        View.ShowPost(session.CreatePost(View.AskPostText()));
    }
}
