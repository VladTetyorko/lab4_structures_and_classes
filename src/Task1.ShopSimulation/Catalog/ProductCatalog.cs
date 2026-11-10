namespace Task1.ShopSimulation.Catalog;

using Exceptions;

internal sealed class ProductCatalog : IProductCatalog
{
    private readonly IReadOnlyList<ProductDescription> _products;

    public ProductCatalog(IReadOnlyList<ProductDescription> products)
    {
        _products = Array.AsReadOnly(products.ToArray());
    }

    public IReadOnlyList<ProductDescription> Products => _products;

    public ProductDescription Find(string productName)
    {
        foreach (ProductDescription product in _products)
        {
            if (string.Equals(product.Name, productName, StringComparison.OrdinalIgnoreCase))
            {
                return product;
            }
        }

        throw ShopExceptionFactory.UnknownProduct(productName);
    }
}
