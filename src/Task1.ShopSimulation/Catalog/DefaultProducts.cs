namespace Task1.ShopSimulation.Catalog;

using Factories;

internal static class DefaultProducts
{
    private static readonly ProductDescription[] Products =
    {
        ProductDescriptionFactory.Create("Milk", 42.50m, 30, MeasureUnit.Liter),
        ProductDescriptionFactory.Create("Kefir", 48.00m, 20, MeasureUnit.Liter),
        ProductDescriptionFactory.Create("Sunflower oil", 89.90m, 15, MeasureUnit.Liter),
        ProductDescriptionFactory.Create("Apple juice", 65.00m, 18, MeasureUnit.Liter),
        ProductDescriptionFactory.Create("Potatoes", 22.00m, 50, MeasureUnit.Kilogram),
        ProductDescriptionFactory.Create("Apples", 39.90m, 40, MeasureUnit.Kilogram),
        ProductDescriptionFactory.Create("Bananas", 64.50m, 25, MeasureUnit.Kilogram),
        ProductDescriptionFactory.Create("Chicken fillet", 189.00m, 20, MeasureUnit.Kilogram),
        ProductDescriptionFactory.Create("Cheese", 420.00m, 10, MeasureUnit.Kilogram),
        ProductDescriptionFactory.Create("Bread", 28.00m, 40, MeasureUnit.Pack),
        ProductDescriptionFactory.Create("Buckwheat", 72.00m, 30, MeasureUnit.Pack),
        ProductDescriptionFactory.Create("Butter", 98.50m, 25, MeasureUnit.Pack),
        ProductDescriptionFactory.Create("Coffee", 245.00m, 12, MeasureUnit.Pack),
        ProductDescriptionFactory.Create("Tea", 85.00m, 20, MeasureUnit.Pack)
    };

    public static IReadOnlyList<ProductDescription> Create()
    {
        return Products;
    }
}
