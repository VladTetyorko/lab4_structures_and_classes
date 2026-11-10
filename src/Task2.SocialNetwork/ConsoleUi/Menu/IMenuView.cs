namespace Task2.SocialNetwork.ConsoleUi.Menu;

internal interface IMenuView
{
    void ShowMenuHeader();

    void ShowMenuOption(int number, string title);

    void ShowExitOption(int number);

    int? AskMenuChoice(int minimum, int maximum);
}
