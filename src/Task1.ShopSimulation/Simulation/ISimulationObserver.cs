namespace Task1.ShopSimulation.Simulation;

using Customers;
using Exceptions;
using Finance;

public interface ISimulationObserver
{
    void OnPurchase(ICustomer customer, Receipt receipt);

    void OnRejected(ICustomer customer, ShopException reason);
}
