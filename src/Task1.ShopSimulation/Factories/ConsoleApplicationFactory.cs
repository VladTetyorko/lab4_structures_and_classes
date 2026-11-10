namespace Task1.ShopSimulation.Factories;

using ConsoleUi;
using ConsoleUi.Views;
using Randomization;

public static class ConsoleApplicationFactory
{
    public static IConsoleApplication Create(TextReader input, TextWriter output, IRandomProvider random)
    {
        ConsoleTerminal terminal = new ConsoleTerminal(input, output);
        IShopView view = new ShopConsoleView(terminal);

        return new ShopConsoleApplication(view, ShopFactory.CreateDefault(random), random);
    }
}
