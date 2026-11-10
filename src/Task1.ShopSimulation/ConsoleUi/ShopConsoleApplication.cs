namespace Task1.ShopSimulation.ConsoleUi;

using Customers;
using Factories;
using Randomization;
using Shopping;
using Views;

internal sealed class ShopConsoleApplication : IConsoleApplication
{
    private readonly IShopView _view;
    private readonly IShop _shop;
    private readonly IRandomProvider _random;

    public ShopConsoleApplication(IShopView view, IShop shop, IRandomProvider random)
    {
        _view = view;
        _shop = shop;
        _random = random;
    }

    public void Run()
    {
        _view.ShowWelcome();
        int? customerCount = _view.AskCustomerCount(CustomerFactory.MinCustomerCount, CustomerFactory.MaxCustomerCount);

        if (customerCount != null)
        {
            ServeCustomers(CustomerFactory.CreateRandomGroup(customerCount.Value, _random));
        }
    }

    private void ServeCustomers(IReadOnlyList<ICustomer> customers)
    {
        _view.ShowCustomers(customers);
        ShopMenuFactory.Create(_view, _shop, customers).RunUntilExit();
        _view.ShowFinalReport(_shop, customers);
    }
}
