namespace Task1.ShopSimulation.Factories;

using Catalog;
using Randomization;

internal static class ProductRandomizerFactory
{
    public static IProductRandomizer Create(IProductCatalog catalog, IRandomProvider random)
    {
        return new ProductRandomizer(catalog, random);
    }
}
