namespace Task2.SocialNetwork.ConsoleUi.Session;

using Exceptions;
using Views;

internal sealed class SignInDialog
{
    private readonly SessionContext _context;
    private readonly ISocialNetworkView _view;

    public SignInDialog(SessionContext context, ISocialNetworkView view)
    {
        _context = context;
        _view = view;
    }

    public bool Run()
    {
        _view.ShowUsers(_context.Users);
        string? nickname = _view.AskNicknameToSignIn();

        while (nickname != null && !TrySignIn(nickname))
        {
            nickname = _view.AskNicknameToSignIn();
        }

        return nickname != null;
    }

    private bool TrySignIn(string nickname)
    {
        try
        {
            _view.ShowSignedIn(_context.SignIn(nickname));
            return true;
        }
        catch (SocialNetworkException error)
        {
            _view.ShowError(error);
            return false;
        }
    }
}
