using Lab.Tests.Fakes;
using Task2.SocialNetwork.Factories;

namespace Lab.Tests.Task2.SocialNetwork;

public sealed class SocialNetworkConsoleApplicationTests
{
    public void ShouldRetrySignInAfterUnknownNickname()
    {
        string output = RunWithInput("ghost\nalice\n0\n");

        Assertions.IsTrue(output.Contains("There is no user @ghost."), "unknown user message");
        Assertions.IsTrue(output.Contains("You are signed in as @alice"), "second attempt succeeds");
    }

    public void ShouldCreatePostAndShowItInMyFeed()
    {
        string output = RunWithInput("alice\n3\nHello there\n2\n0\n");

        Assertions.IsTrue(output.Contains("Post #1 by @alice"), "post header");
        Assertions.IsTrue(output.Contains("Hello there"), "post text");
    }

    public void ShouldReportOwnershipErrorWhenDeletingForeignPost()
    {
        string output = RunWithInput("bob\n3\nBob's post\n8\nalice\n5\n1\n0\n");

        Assertions.IsTrue(output.Contains("belongs to another user"), "ownership error is shown");
    }

    public void ShouldSayGoodbyeWhenInputEnds()
    {
        string output = RunWithInput("");

        Assertions.IsTrue(output.Contains("Goodbye!"), "goodbye message");
    }

    private static string RunWithInput(string input)
    {
        StringWriter output = new StringWriter();
        ConsoleApplicationFactory.Create(new StringReader(input), output, TestNetwork.Create(new ManualClock(TestNetwork.Start))).Run();

        return output.ToString();
    }
}
