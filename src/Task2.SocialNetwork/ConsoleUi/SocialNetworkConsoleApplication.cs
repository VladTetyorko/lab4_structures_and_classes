namespace Task2.SocialNetwork.ConsoleUi;

using Menu;
using Session;
using Views;

internal sealed class SocialNetworkConsoleApplication : IConsoleApplication
{
    private readonly ISocialNetworkView _view;
    private readonly SignInDialog _signInDialog;
    private readonly IMenu _menu;

    public SocialNetworkConsoleApplication(ISocialNetworkView view, SignInDialog signInDialog, IMenu menu)
    {
        _view = view;
        _signInDialog = signInDialog;
        _menu = menu;
    }

    public void Run()
    {
        _view.ShowWelcome();

        if (_signInDialog.Run())
        {
            _menu.RunUntilExit();
        }

        _view.ShowGoodbye();
    }
}
