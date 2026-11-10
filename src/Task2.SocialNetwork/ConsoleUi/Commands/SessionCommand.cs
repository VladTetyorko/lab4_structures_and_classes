namespace Task2.SocialNetwork.ConsoleUi.Commands;

using Application;
using Exceptions;
using Menu;
using Session;
using Views;

internal abstract class SessionCommand : IMenuCommand
{
    private readonly SessionContext _context;

    protected SessionCommand(SessionContext context, ISocialNetworkView view)
    {
        _context = context;
        View = view;
    }

    public abstract string Title { get; }

    protected ISocialNetworkView View { get; }

    public void Execute()
    {
        try
        {
            ExecuteFor(_context.CurrentSession);
        }
        catch (SocialNetworkException error)
        {
            View.ShowError(error);
        }
    }

    protected abstract void ExecuteFor(IUserSession session);
}
