namespace Task1.ShopSimulation.Factories;

using Catalog;
using Finance;
using Randomization;
using Shopping;
using Storage;

public static class ShopFactory
{
    public static IShop CreateDefault(IRandomProvider random)
    {
        return Create(ProductCatalogFactory.CreateDefault(), random);
    }

    public static IShop Create(IProductCatalog catalog, IRandomProvider random)
    {
        return Create(catalog, WarehouseFactory.Create(catalog), CashRegisterFactory.Create(), random);
    }

    internal static IShop Create(IProductCatalog catalog, IWarehouse warehouse, ICashRegister cashRegister,
        IRandomProvider random)
    {
        return new Shop(warehouse, cashRegister, ProductRandomizerFactory.Create(catalog, random));
    }
}
