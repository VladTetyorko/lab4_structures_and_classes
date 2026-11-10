namespace Task1.ShopSimulation.Simulation;

using Customers;

public static class CustomerRanking
{
    private const decimal NothingBought = 0m;

    public static ICustomer? FindTopBuyerByItems(IReadOnlyList<ICustomer> customers)
    {
        return FindLeader(customers, customer => customer.PurchasedCount);
    }

    public static ICustomer? FindTopBuyerBySpending(IReadOnlyList<ICustomer> customers)
    {
        return FindLeader(customers, customer => customer.SpentAmount);
    }

    private static ICustomer? FindLeader(IReadOnlyList<ICustomer> customers, Func<ICustomer, decimal> score)
    {
        ICustomer? leader = null;

        foreach (ICustomer customer in customers)
        {
            if (score(customer) > (leader == null ? NothingBought : score(leader)))
            {
                leader = customer;
            }
        }

        return leader;
    }
}
