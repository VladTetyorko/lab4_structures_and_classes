using Task1.ShopSimulation.ConsoleUi;
using Task1.ShopSimulation.Factories;

IConsoleApplication application =
    ConsoleApplicationFactory.Create(Console.In, Console.Out, RandomProviderFactory.CreateSystem());

application.Run();
