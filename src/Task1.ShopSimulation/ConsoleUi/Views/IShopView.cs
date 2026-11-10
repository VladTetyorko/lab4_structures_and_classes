namespace Task1.ShopSimulation.ConsoleUi.Views;

using Catalog;
using Customers;
using Exceptions;
using Finance;
using Menu;
using Shopping;
using Simulation;

internal interface IShopView : IMenuView
{
    void ShowWelcome();

    int? AskCustomerCount(int minimum, int maximum);

    void ShowCustomers(IReadOnlyList<ICustomer> customers);

    ICustomer? AskCustomer(IReadOnlyList<ICustomer> customers);

    ProductDescription? AskProduct(IReadOnlyList<ProductDescription> products);

    void ShowReceipt(Receipt receipt);

    void ShowRejection(ShopException reason);

    void ShowReport(string report);

    void ShowRestocked();

    void ShowSimulationResult(SimulationResult result);

    void ShowFinalReport(IShop shop, IReadOnlyList<ICustomer> customers);
}
