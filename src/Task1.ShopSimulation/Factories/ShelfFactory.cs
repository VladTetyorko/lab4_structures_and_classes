namespace Task1.ShopSimulation.Factories;

using Catalog;
using Storage;

internal static class ShelfFactory
{
    public static Shelf Create(ProductDescription product)
    {
        return new Shelf(product.Name, product.Unit, product.AvailableQuantity);
    }
}
