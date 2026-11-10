using Task1.ShopSimulation.Catalog;
using Task1.ShopSimulation.Exceptions;
using Task1.ShopSimulation.Factories;

namespace Lab.Tests.Task1.ShopSimulation;

public sealed class ProductCatalogTests
{
    public void ShouldCreateDescriptionWithTrimmedName()
    {
        ProductDescription milk = ProductDescriptionFactory.Create("  Milk ", 40m, 3, MeasureUnit.Liter);

        Assertions.AreEqual("Milk", milk.Name);
        Assertions.AreEqual(40m, milk.UnitPrice);
        Assertions.AreEqual(3, milk.AvailableQuantity);
    }

    public void ShouldRejectDescriptionWithEmptyName()
    {
        Assertions.Throws<InvalidProductDescriptionException>(
            () => ProductDescriptionFactory.Create(" ", 40m, 3, MeasureUnit.Liter), "empty name");
    }

    public void ShouldRejectDescriptionWithNonPositivePrice()
    {
        Assertions.Throws<InvalidProductDescriptionException>(
            () => ProductDescriptionFactory.Create("Milk", 0m, 3, MeasureUnit.Liter), "zero price");
    }

    public void ShouldRejectDescriptionWithNegativeQuantity()
    {
        Assertions.Throws<InvalidProductDescriptionException>(
            () => ProductDescriptionFactory.Create("Milk", 40m, -1, MeasureUnit.Liter), "negative quantity");
    }

    public void ShouldUseEveryMeasureUnitInDefaultCatalog()
    {
        IProductCatalog catalog = ProductCatalogFactory.CreateDefault();

        foreach (MeasureUnit unit in Enum.GetValues<MeasureUnit>())
        {
            Assertions.IsTrue(catalog.Products.Any(product => product.Unit == unit), "unit " + unit + " is used");
        }
    }

    public void ShouldFindProductIgnoringCase()
    {
        ProductDescription milk = TestShop.CreateCatalog().Find("mILK");

        Assertions.AreEqual(TestShop.Milk, milk.Name);
    }

    public void ShouldThrowUnknownProductExceptionForMissingProduct()
    {
        Assertions.Throws<UnknownProductException>(() => TestShop.CreateCatalog().Find("Caviar"), "missing product");
    }

    public void ShouldRejectCatalogWithDuplicateNames()
    {
        ProductDescription milk = ProductDescriptionFactory.Create("Milk", 40m, 3, MeasureUnit.Liter);

        Assertions.Throws<DuplicateProductException>(
            () => ProductCatalogFactory.Create(new[] { milk, milk }), "duplicate names");
    }

    public void ShouldRejectEmptyCatalog()
    {
        Assertions.Throws<EmptyCatalogException>(
            () => ProductCatalogFactory.Create(Array.Empty<ProductDescription>()), "empty catalog");
    }
}
