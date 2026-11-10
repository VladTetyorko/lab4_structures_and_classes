namespace Task1.ShopSimulation.Factories;

using Catalog;
using Storage;

internal static class WarehouseFactory
{
    public static IWarehouse Create(IProductCatalog catalog)
    {
        return new Warehouse(catalog);
    }
}
