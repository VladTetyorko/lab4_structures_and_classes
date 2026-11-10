namespace Task1.ShopSimulation.Catalog;

public interface IProductCatalog
{
    IReadOnlyList<ProductDescription> Products { get; }

    ProductDescription Find(string productName);
}
