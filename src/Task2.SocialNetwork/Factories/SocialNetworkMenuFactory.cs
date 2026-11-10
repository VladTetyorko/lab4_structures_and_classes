namespace Task2.SocialNetwork.Factories;

using ConsoleUi.Commands;
using ConsoleUi.Menu;
using ConsoleUi.Session;
using ConsoleUi.Views;

internal static class SocialNetworkMenuFactory
{
    public static IMenu Create(ISocialNetworkView view, SessionContext context, SignInDialog signInDialog)
    {
        IMenuCommand[] commands =
        {
            new ShowUserPostsCommand(context, view),
            new ShowMyPostsCommand(context, view),
            new CreatePostCommand(context, view),
            new EditPostCommand(context, view),
            new DeletePostCommand(context, view),
            new LikePostCommand(context, view),
            new CommentPostCommand(context, view),
            new SwitchUserCommand(signInDialog)
        };

        return new ConsoleMenu(view, commands);
    }
}
