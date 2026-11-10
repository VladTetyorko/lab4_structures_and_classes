namespace Task1.ShopSimulation.Factories;

using ConsoleUi.Commands;
using ConsoleUi.Menu;
using ConsoleUi.Views;
using Customers;
using Shopping;
using Simulation;

internal static class ShopMenuFactory
{
    public static IMenu Create(IShopView view, IShop shop, IReadOnlyList<ICustomer> customers)
    {
        IShoppingSimulation simulation =
            ShoppingSimulationFactory.Create(shop, SimulationObserverFactory.CreateConsole(view));

        IMenuCommand[] commands =
        {
            new RunSimulationCommand(simulation, customers, view),
            new BuySpecificProductCommand(shop, customers, view),
            new BuyRandomProductCommand(shop, customers, view),
            new ShowWarehouseReportCommand(shop, view),
            new ShowCashRegisterReportCommand(shop, view),
            new ShowCustomersCommand(customers, view),
            new RestockShelvesCommand(shop, view)
        };

        return new ConsoleMenu(view, commands);
    }
}
