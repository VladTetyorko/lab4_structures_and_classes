namespace Task1.ShopSimulation.ConsoleUi.Commands;

using Catalog;
using Customers;
using Finance;
using Shopping;
using Views;

internal sealed class BuySpecificProductCommand : PurchaseCommand
{
    private const string CommandTitle = "Buy a specific product";

    public BuySpecificProductCommand(IShop shop, IReadOnlyList<ICustomer> customers, IShopView view)
        : base(shop, customers, view)
    {
    }

    public override string Title => CommandTitle;

    protected override Receipt? Buy(ICustomer customer)
    {
        ProductDescription? product = View.AskProduct(Shop.Assortment);

        return product == null ? null : Shop.Sell(customer, product.Value.Name);
    }
}
