using Task1.ShopSimulation.Customers;
using Task1.ShopSimulation.Factories;
using Task1.ShopSimulation.Simulation;

namespace Lab.Tests.Task1.ShopSimulation;

public sealed class CustomerRankingTests
{
    public void ShouldFindCustomerWithMostItems()
    {
        ICustomer manyCheapItems = CreateCustomerWithPurchases(1, 10m, 10m, 10m);
        ICustomer oneExpensiveItem = CreateCustomerWithPurchases(2, 500m);

        ICustomer? leader = CustomerRanking.FindTopBuyerByItems(new[] { oneExpensiveItem, manyCheapItems });

        Assertions.AreEqual(1, leader!.Card.Number);
    }

    public void ShouldFindCustomerWhoSpentMost()
    {
        ICustomer manyCheapItems = CreateCustomerWithPurchases(1, 10m, 10m, 10m);
        ICustomer oneExpensiveItem = CreateCustomerWithPurchases(2, 500m);

        ICustomer? leader = CustomerRanking.FindTopBuyerBySpending(new[] { manyCheapItems, oneExpensiveItem });

        Assertions.AreEqual(2, leader!.Card.Number);
    }

    public void ShouldReturnNobodyWhenNothingWasBought()
    {
        ICustomer[] customers = { TestCustomers.Create(1, 100m), TestCustomers.Create(2, 100m) };

        Assertions.IsTrue(CustomerRanking.FindTopBuyerByItems(customers) == null, "no leader by items");
        Assertions.IsTrue(CustomerRanking.FindTopBuyerBySpending(customers) == null, "no leader by money");
    }

    private static ICustomer CreateCustomerWithPurchases(int cardNumber, params decimal[] prices)
    {
        ICustomer customer = TestCustomers.Create(cardNumber, 1000m);

        foreach (decimal price in prices)
        {
            customer.Pay(price);
        }

        return customer;
    }
}
