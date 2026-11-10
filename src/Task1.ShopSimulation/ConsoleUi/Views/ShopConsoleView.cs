namespace Task1.ShopSimulation.ConsoleUi.Views;

using Catalog;
using Customers;
using Exceptions;
using Finance;
using Formatting;
using Shopping;
using Simulation;

internal sealed class ShopConsoleView : IShopView
{
    private const string WelcomeMessage = "Welcome to the shop simulator!";
    private const string CustomerCountPrompt = "Enter the number of customers: ";
    private const string CustomerPrompt = "Choose a customer by position: ";
    private const string ProductPrompt = "Choose a product by position: ";
    private const string MenuChoicePrompt = "Your choice: ";
    private const string MenuHeader = "";
    private const string OptionSeparator = " - ";
    private const string ExitTitle = "Finish and show the final report";
    private const string RejectedPrefix = "Rejected: ";
    private const string RestockedMessage = "The shelves are full again.";
    private const string SimulationFinishedPrefix = "Simulation finished. Purchases: ";
    private const string RejectionsLabel = ", rejected attempts: ";
    private const int FirstPosition = 1;

    private readonly ConsoleTerminal _terminal;

    public ShopConsoleView(ConsoleTerminal terminal)
    {
        _terminal = terminal;
    }

    public void ShowWelcome() => _terminal.WriteLine(WelcomeMessage);

    public int? AskCustomerCount(int minimum, int maximum)
    {
        return _terminal.ReadNumber(CustomerCountPrompt, minimum, maximum);
    }

    public void ShowCustomers(IReadOnlyList<ICustomer> customers)
    {
        _terminal.WriteLine(CustomerReportFormatter.Format(customers));
    }

    public ICustomer? AskCustomer(IReadOnlyList<ICustomer> customers)
    {
        ShowCustomers(customers);
        int? position = _terminal.ReadNumber(CustomerPrompt, FirstPosition, customers.Count);

        return position == null ? null : customers[position.Value - FirstPosition];
    }

    public ProductDescription? AskProduct(IReadOnlyList<ProductDescription> products)
    {
        _terminal.WriteLine(AssortmentFormatter.Format(products));
        int? position = _terminal.ReadNumber(ProductPrompt, FirstPosition, products.Count);

        return position == null ? null : products[position.Value - FirstPosition];
    }

    public void ShowReceipt(Receipt receipt) => _terminal.WriteLine(ReceiptFormatter.Format(receipt));

    public void ShowRejection(ShopException reason) => _terminal.WriteLine(RejectedPrefix + reason.Message);

    public void ShowReport(string report) => _terminal.WriteLine(report);

    public void ShowRestocked() => _terminal.WriteLine(RestockedMessage);

    public void ShowSimulationResult(SimulationResult result)
    {
        _terminal.WriteLine(SimulationFinishedPrefix + result.PurchaseCount + RejectionsLabel + result.RejectionCount);
    }

    public void ShowFinalReport(IShop shop, IReadOnlyList<ICustomer> customers)
    {
        _terminal.WriteLine(FinalReportFormatter.Format(shop, customers));
    }

    public void ShowMenuHeader() => _terminal.WriteLine(MenuHeader);

    public void ShowMenuOption(int number, string title) => _terminal.WriteLine(number + OptionSeparator + title);

    public void ShowExitOption(int number) => ShowMenuOption(number, ExitTitle);

    public int? AskMenuChoice(int minimum, int maximum)
    {
        return _terminal.ReadNumber(MenuChoicePrompt, minimum, maximum);
    }
}
