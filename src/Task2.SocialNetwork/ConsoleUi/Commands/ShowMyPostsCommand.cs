namespace Task2.SocialNetwork.ConsoleUi.Commands;

using Application;
using Session;
using Views;

internal sealed class ShowMyPostsCommand : SessionCommand
{
    private const string CommandTitle = "Show my latest 5 posts";

    public ShowMyPostsCommand(SessionContext context, ISocialNetworkView view) : base(context, view)
    {
    }

    public override string Title => CommandTitle;

    protected override void ExecuteFor(IUserSession session)
    {
        View.ShowPosts(session.GetLatestPosts(session.CurrentUser.Nickname));
    }
}
