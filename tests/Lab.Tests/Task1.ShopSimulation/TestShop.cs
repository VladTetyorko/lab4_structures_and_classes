using Lab.Tests.Fakes;
using Task1.ShopSimulation.Catalog;
using Task1.ShopSimulation.Factories;
using Task1.ShopSimulation.Finance;
using Task1.ShopSimulation.Randomization;
using Task1.ShopSimulation.Shopping;
using Task1.ShopSimulation.Storage;

namespace Lab.Tests.Task1.ShopSimulation;

internal static class TestShop
{
    public const string Milk = "Milk";
    public const string Bread = "Bread";
    public const decimal MilkPrice = 40m;
    public const decimal BreadPrice = 25m;
    public const int MilkQuantity = 2;
    public const int BreadQuantity = 1;
    public const int MilkIndex = 0;
    public const int BreadIndex = 1;

    public static IProductCatalog CreateCatalog()
    {
        return ProductCatalogFactory.Create(new[]
        {
            ProductDescriptionFactory.Create(Milk, MilkPrice, MilkQuantity, MeasureUnit.Liter),
            ProductDescriptionFactory.Create(Bread, BreadPrice, BreadQuantity, MeasureUnit.Pack)
        });
    }

    public static IShop CreateShop(IRandomProvider random)
    {
        return ShopFactory.Create(CreateCatalog(), random);
    }

    public static IShop CreateShop(IProductCatalog catalog, IWarehouse warehouse, ICashRegister cashRegister)
    {
        return ShopFactory.Create(catalog, warehouse, cashRegister, new SequenceRandomProvider(MilkIndex));
    }
}
