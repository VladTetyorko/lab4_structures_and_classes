namespace Task2.SocialNetwork.ConsoleUi.Commands;

using Application;
using Session;
using Views;

internal sealed class ShowUserPostsCommand : SessionCommand
{
    private const string CommandTitle = "Show the latest 5 posts of a user";

    public ShowUserPostsCommand(SessionContext context, ISocialNetworkView view) : base(context, view)
    {
    }

    public override string Title => CommandTitle;

    protected override void ExecuteFor(IUserSession session)
    {
        View.ShowPosts(session.GetLatestPosts(View.AskAuthorNickname()));
    }
}
