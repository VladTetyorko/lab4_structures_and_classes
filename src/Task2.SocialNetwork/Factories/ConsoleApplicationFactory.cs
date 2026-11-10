namespace Task2.SocialNetwork.Factories;

using Application;
using ConsoleUi;
using ConsoleUi.Session;
using ConsoleUi.Views;

public static class ConsoleApplicationFactory
{
    public static IConsoleApplication Create(TextReader input, TextWriter output, ISocialNetwork network)
    {
        ISocialNetworkView view = new SocialNetworkConsoleView(new ConsoleTerminal(input, output));
        SessionContext context = new SessionContext(network);
        SignInDialog signInDialog = new SignInDialog(context, view);

        return new SocialNetworkConsoleApplication(view, signInDialog,
            SocialNetworkMenuFactory.Create(view, context, signInDialog));
    }
}
