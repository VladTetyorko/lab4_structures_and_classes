namespace Task1.ShopSimulation.ConsoleUi.Commands;

using Customers;
using Finance;
using Shopping;
using Views;

internal sealed class BuyRandomProductCommand : PurchaseCommand
{
    private const string CommandTitle = "Buy a random product";

    public BuyRandomProductCommand(IShop shop, IReadOnlyList<ICustomer> customers, IShopView view)
        : base(shop, customers, view)
    {
    }

    public override string Title => CommandTitle;

    protected override Receipt? Buy(ICustomer customer) => Shop.SellRandom(customer);
}
