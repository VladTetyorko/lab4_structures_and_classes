namespace Task1.ShopSimulation.Factories;

using Catalog;
using Exceptions;

public static class ProductCatalogFactory
{
    private const int EmptyCount = 0;

    public static IProductCatalog CreateDefault()
    {
        return Create(DefaultProducts.Create());
    }

    public static IProductCatalog Create(IReadOnlyList<ProductDescription> products)
    {
        if (products.Count == EmptyCount)
        {
            throw ShopExceptionFactory.EmptyCatalog();
        }

        EnsureUniqueNames(products);

        return new ProductCatalog(products);
    }

    private static void EnsureUniqueNames(IReadOnlyList<ProductDescription> products)
    {
        HashSet<string> names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (ProductDescription product in products)
        {
            if (!names.Add(product.Name))
            {
                throw ShopExceptionFactory.DuplicateProduct(product.Name);
            }
        }
    }
}
