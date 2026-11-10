namespace Task1.ShopSimulation.ConsoleUi.Commands;

using Customers;
using Menu;
using Views;

internal sealed class ShowCustomersCommand : IMenuCommand
{
    private const string CommandTitle = "Customers report";

    private readonly IReadOnlyList<ICustomer> _customers;
    private readonly IShopView _view;

    public ShowCustomersCommand(IReadOnlyList<ICustomer> customers, IShopView view)
    {
        _customers = customers;
        _view = view;
    }

    public string Title => CommandTitle;

    public void Execute() => _view.ShowCustomers(_customers);
}
