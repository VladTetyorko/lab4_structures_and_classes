namespace Task1.ShopSimulation.ConsoleUi;

using Customers;
using Exceptions;
using Finance;
using Simulation;
using Views;

internal sealed class ConsoleSimulationObserver : ISimulationObserver
{
    private readonly IShopView _view;

    public ConsoleSimulationObserver(IShopView view)
    {
        _view = view;
    }

    public void OnPurchase(ICustomer customer, Receipt receipt) => _view.ShowReceipt(receipt);

    public void OnRejected(ICustomer customer, ShopException reason) => _view.ShowRejection(reason);
}
