namespace Task1.ShopSimulation.Simulation;

using Customers;
using Exceptions;
using Factories;
using Finance;
using Shopping;

internal sealed class ShoppingSimulation : IShoppingSimulation
{
    private readonly IShop _shop;
    private readonly ISimulationObserver _observer;

    public ShoppingSimulation(IShop shop, ISimulationObserver observer)
    {
        _shop = shop;
        _observer = observer;
    }

    public SimulationResult Run(IReadOnlyList<ICustomer> customers)
    {
        int purchaseCount = 0;
        int attemptCount = 0;
        IReadOnlyList<ICustomer> shoppers = FindShoppers(customers);

        while (shoppers.Count > 0)
        {
            purchaseCount += ServeRound(shoppers);
            attemptCount += shoppers.Count;
            shoppers = FindShoppers(customers);
        }

        return SimulationResultFactory.Create(purchaseCount, attemptCount - purchaseCount);
    }

    private int ServeRound(IReadOnlyList<ICustomer> shoppers)
    {
        int purchaseCount = 0;

        foreach (ICustomer shopper in shoppers)
        {
            if (TryBuyRandomProduct(shopper))
            {
                purchaseCount++;
            }
        }

        return purchaseCount;
    }

    private IReadOnlyList<ICustomer> FindShoppers(IReadOnlyList<ICustomer> customers)
    {
        return customers.Where(_shop.CanServe).ToArray();
    }

    private bool TryBuyRandomProduct(ICustomer customer)
    {
        try
        {
            _observer.OnPurchase(customer, _shop.SellRandom(customer));
            return true;
        }
        catch (ShopException reason)
        {
            _observer.OnRejected(customer, reason);
            return false;
        }
    }
}
