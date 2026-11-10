using Task2.SocialNetwork.Application;
using Task2.SocialNetwork.ConsoleUi;
using Task2.SocialNetwork.Factories;

ISocialNetwork network = SocialNetworkFactory.CreateWithSeedData(ClockFactory.CreateSystem());
IConsoleApplication application = ConsoleApplicationFactory.Create(Console.In, Console.Out, network);

application.Run();
