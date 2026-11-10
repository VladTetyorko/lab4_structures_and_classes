namespace Task1.ShopSimulation.ConsoleUi.Commands;

using Customers;
using Menu;
using Simulation;
using Views;

internal sealed class RunSimulationCommand : IMenuCommand
{
    private const string CommandTitle = "Run the shopping simulation";

    private readonly IShoppingSimulation _simulation;
    private readonly IReadOnlyList<ICustomer> _customers;
    private readonly IShopView _view;

    public RunSimulationCommand(IShoppingSimulation simulation, IReadOnlyList<ICustomer> customers, IShopView view)
    {
        _simulation = simulation;
        _customers = customers;
        _view = view;
    }

    public string Title => CommandTitle;

    public void Execute() => _view.ShowSimulationResult(_simulation.Run(_customers));
}
