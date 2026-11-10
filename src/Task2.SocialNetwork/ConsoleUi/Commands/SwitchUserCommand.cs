namespace Task2.SocialNetwork.ConsoleUi.Commands;

using Menu;
using Session;

internal sealed class SwitchUserCommand : IMenuCommand
{
    private const string CommandTitle = "Switch user";

    private readonly SignInDialog _signInDialog;

    public SwitchUserCommand(SignInDialog signInDialog)
    {
        _signInDialog = signInDialog;
    }

    public string Title => CommandTitle;

    public void Execute() => _signInDialog.Run();
}
