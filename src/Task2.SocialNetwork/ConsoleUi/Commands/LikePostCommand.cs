namespace Task2.SocialNetwork.ConsoleUi.Commands;

using Application;
using Session;
using Views;

internal sealed class LikePostCommand : PostCommand
{
    private const string CommandTitle = "Like a post";

    public LikePostCommand(SessionContext context, ISocialNetworkView view) : base(context, view)
    {
    }

    public override string Title => CommandTitle;

    protected override void ExecuteForPost(IUserSession session, int postId)
    {
        View.ShowPost(session.LikePost(postId));
    }
}
