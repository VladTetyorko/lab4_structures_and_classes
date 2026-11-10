namespace Task1.ShopSimulation.Shopping;

using Catalog;
using Customers;
using Finance;

public interface IShop
{
    IReadOnlyList<ProductDescription> Assortment { get; }

    decimal Profit { get; }

    bool IsSoldOut { get; }

    Receipt Sell(ICustomer customer, string productName);

    Receipt SellRandom(ICustomer customer);

    bool CanServe(ICustomer customer);

    void Restock();

    string GetWarehouseReport();

    string GetCashRegisterReport();
}
