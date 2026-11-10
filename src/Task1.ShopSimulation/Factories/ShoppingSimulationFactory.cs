namespace Task1.ShopSimulation.Factories;

using Shopping;
using Simulation;

public static class ShoppingSimulationFactory
{
    public static IShoppingSimulation Create(IShop shop, ISimulationObserver observer)
    {
        return new ShoppingSimulation(shop, observer);
    }
}
