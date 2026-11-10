using Task1.ShopSimulation.Factories;

namespace Lab.Tests.Task1.ShopSimulation;

public sealed class ShopConsoleApplicationTests
{
    public void ShouldShowWarehouseReportAndFinalReport()
    {
        string output = RunWithInput("2\n4\n0\n");

        Assertions.IsTrue(output.Contains("=== Warehouse report ==="), "warehouse report from the menu");
        Assertions.IsTrue(output.Contains("=== Final report ==="), "final report after exit");
    }

    public void ShouldAskAgainWhenCustomerCountIsInvalid()
    {
        string output = RunWithInput("abc\n1\n0\n");

        Assertions.IsTrue(output.Contains("Please enter a whole number from 1 to 1000."), "validation message");
    }

    public void ShouldSellChosenProductToChosenCustomer()
    {
        string output = RunWithInput("1\n2\n1\n1\n0\n");

        Assertions.IsTrue(output.Contains("bought 1 L of Milk for 42.50 UAH"), "receipt for milk");
    }

    public void ShouldFinishQuietlyWhenInputEnds()
    {
        string output = RunWithInput("");

        Assertions.IsFalse(output.Contains("=== Final report ==="), "no customers, no report");
    }

    private static string RunWithInput(string input)
    {
        StringWriter output = new StringWriter();
        ConsoleApplicationFactory.Create(new StringReader(input), output, RandomProviderFactory.CreateSeeded(1)).Run();

        return output.ToString();
    }
}
