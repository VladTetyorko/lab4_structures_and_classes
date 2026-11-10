namespace Task2.SocialNetwork.ConsoleUi.Menu;

internal interface IMenuCommand
{
    string Title { get; }

    void Execute();
}
