namespace Task1.ShopSimulation.Randomization;

using Catalog;

internal sealed class ProductRandomizer : IProductRandomizer
{
    private const int FirstIndex = 0;

    private readonly IProductCatalog _catalog;
    private readonly IRandomProvider _random;

    public ProductRandomizer(IProductCatalog catalog, IRandomProvider random)
    {
        _catalog = catalog;
        _random = random;
    }

    public ProductDescription PickProduct()
    {
        int index = _random.Next(FirstIndex, _catalog.Products.Count);

        return _catalog.Products[index];
    }
}
