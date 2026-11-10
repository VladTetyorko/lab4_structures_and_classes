namespace Task1.ShopSimulation.Storage;

using Catalog;
using Reporting;

internal interface IWarehouse : IReportable
{
    IReadOnlyList<ProductDescription> Assortment { get; }

    bool IsEmpty { get; }

    ProductDescription FindProduct(string productName);

    int GetQuantity(string productName);

    bool IsInStock(string productName);

    void Take(string productName);

    void Return(string productName);

    void Restock();
}
