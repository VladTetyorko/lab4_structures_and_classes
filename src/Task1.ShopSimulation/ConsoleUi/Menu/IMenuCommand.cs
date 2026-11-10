namespace Task1.ShopSimulation.ConsoleUi.Menu;

internal interface IMenuCommand
{
    string Title { get; }

    void Execute();
}
