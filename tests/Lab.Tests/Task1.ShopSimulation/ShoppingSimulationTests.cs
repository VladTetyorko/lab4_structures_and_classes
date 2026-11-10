using Lab.Tests.Fakes;
using Task1.ShopSimulation.Customers;
using Task1.ShopSimulation.Factories;
using Task1.ShopSimulation.ConsoleUi.Formatting;
using Task1.ShopSimulation.Shopping;
using Task1.ShopSimulation.Simulation;

namespace Lab.Tests.Task1.ShopSimulation;

public sealed class ShoppingSimulationTests
{
    public void ShouldStopWhenNobodyCanBuyAnything()
    {
        IShop shop = ShopFactory.CreateDefault(RandomProviderFactory.CreateSeeded(7));
        IReadOnlyList<ICustomer> customers = CustomerFactory.CreateRandomGroup(10, RandomProviderFactory.CreateSeeded(7));

        CreateSimulation(shop).Run(customers);

        Assertions.IsFalse(customers.Any(shop.CanServe), "every customer is out of money or goods");
    }

    public void ShouldKeepProfitEqualToCustomersSpending()
    {
        IShop shop = ShopFactory.CreateDefault(RandomProviderFactory.CreateSeeded(11));
        IReadOnlyList<ICustomer> customers = CustomerFactory.CreateRandomGroup(3, RandomProviderFactory.CreateSeeded(11));

        SimulationResult result = CreateSimulation(shop).Run(customers);

        Assertions.AreEqual(customers.Sum(customer => customer.SpentAmount), shop.Profit);
        Assertions.AreEqual(customers.Sum(customer => customer.PurchasedCount), result.PurchaseCount);
    }

    public void ShouldSellOutWhenCustomersAreRich()
    {
        IShop shop = TestShop.CreateShop(new SequenceRandomProvider(0, 1));
        ICustomer customer = TestCustomers.Create(1, 1000m);

        CreateSimulation(shop).Run(new[] { customer });

        Assertions.IsTrue(shop.IsSoldOut, "all three units are sold");
        Assertions.AreEqual(3, customer.PurchasedCount);
    }

    public void ShouldReportProfitAndLeadersAtTheEnd()
    {
        IShop shop = TestShop.CreateShop(new SequenceRandomProvider(0, 1));
        ICustomer customer = TestCustomers.Create(77, 1000m);
        CreateSimulation(shop).Run(new[] { customer });

        string report = FinalReportFormatter.Format(shop, new[] { customer });

        Assertions.IsTrue(report.Contains("Shop profit: 105.00 UAH"), "profit");
        Assertions.IsTrue(report.Contains("Most items bought: " + TestCustomers.FullName + " (card #77, 3 units)"), "top buyer by items");
        Assertions.IsTrue(report.Contains("Most money spent: " + TestCustomers.FullName + " (card #77, 105.00 UAH)"), "top buyer by money");
    }

    private static IShoppingSimulation CreateSimulation(IShop shop)
    {
        return ShoppingSimulationFactory.Create(shop, SimulationObserverFactory.CreateSilent());
    }
}
