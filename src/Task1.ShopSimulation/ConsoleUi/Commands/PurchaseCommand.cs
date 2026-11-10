namespace Task1.ShopSimulation.ConsoleUi.Commands;

using Customers;
using Exceptions;
using Finance;
using Menu;
using Shopping;
using Views;

internal abstract class PurchaseCommand : IMenuCommand
{
    private readonly IReadOnlyList<ICustomer> _customers;

    protected PurchaseCommand(IShop shop, IReadOnlyList<ICustomer> customers, IShopView view)
    {
        Shop = shop;
        View = view;
        _customers = customers;
    }

    public abstract string Title { get; }

    protected IShop Shop { get; }

    protected IShopView View { get; }

    public void Execute()
    {
        ICustomer? customer = View.AskCustomer(_customers);

        if (customer != null)
        {
            TryBuy(customer);
        }
    }

    protected abstract Receipt? Buy(ICustomer customer);

    private void TryBuy(ICustomer customer)
    {
        try
        {
            Receipt? receipt = Buy(customer);

            if (receipt != null)
            {
                View.ShowReceipt(receipt);
            }
        }
        catch (ShopException reason)
        {
            View.ShowRejection(reason);
        }
    }
}
