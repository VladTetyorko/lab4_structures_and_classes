namespace Task1.ShopSimulation.Simulation;

using Customers;
using Exceptions;
using Finance;

internal sealed class SilentSimulationObserver : ISimulationObserver
{
    public void OnPurchase(ICustomer customer, Receipt receipt)
    {
    }

    public void OnRejected(ICustomer customer, ShopException reason)
    {
    }
}
