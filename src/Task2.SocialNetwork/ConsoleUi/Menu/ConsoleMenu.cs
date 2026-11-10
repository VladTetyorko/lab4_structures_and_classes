namespace Task2.SocialNetwork.ConsoleUi.Menu;

internal sealed class ConsoleMenu : IMenu
{
    private const int ExitChoice = 0;
    private const int FirstCommandNumber = 1;

    private readonly IMenuView _view;
    private readonly IReadOnlyList<IMenuCommand> _commands;

    public ConsoleMenu(IMenuView view, IReadOnlyList<IMenuCommand> commands)
    {
        _view = view;
        _commands = commands;
    }

    public void RunUntilExit()
    {
        IMenuCommand? command = ReadCommand();

        while (command != null)
        {
            command.Execute();
            command = ReadCommand();
        }
    }

    private IMenuCommand? ReadCommand()
    {
        ShowOptions();
        int? choice = _view.AskMenuChoice(ExitChoice, _commands.Count);

        return choice == null || choice == ExitChoice ? null : _commands[choice.Value - FirstCommandNumber];
    }

    private void ShowOptions()
    {
        _view.ShowMenuHeader();

        for (int index = 0; index < _commands.Count; index++)
        {
            _view.ShowMenuOption(index + FirstCommandNumber, _commands[index].Title);
        }

        _view.ShowExitOption(ExitChoice);
    }
}
