namespace Task1.ShopSimulation.Simulation;

using Customers;

public interface IShoppingSimulation
{
    SimulationResult Run(IReadOnlyList<ICustomer> customers);
}
