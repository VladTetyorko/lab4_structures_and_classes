using Task1.ShopSimulation.Exceptions;
using Task1.ShopSimulation.Factories;
using Task1.ShopSimulation.Storage;

namespace Lab.Tests.Task1.ShopSimulation;

public sealed class WarehouseTests
{
    public void ShouldStartWithQuantitiesFromCatalog()
    {
        IWarehouse warehouse = WarehouseFactory.Create(TestShop.CreateCatalog());

        Assertions.AreEqual(TestShop.MilkQuantity, warehouse.GetQuantity(TestShop.Milk));
        Assertions.AreEqual(TestShop.BreadQuantity, warehouse.GetQuantity(TestShop.Bread));
    }

    public void ShouldDecreaseQuantityByOneWhenTaking()
    {
        IWarehouse warehouse = WarehouseFactory.Create(TestShop.CreateCatalog());

        warehouse.Take(TestShop.Milk);

        Assertions.AreEqual(TestShop.MilkQuantity - 1, warehouse.GetQuantity(TestShop.Milk));
    }

    public void ShouldThrowOutOfStockWhenShelfIsEmpty()
    {
        IWarehouse warehouse = WarehouseFactory.Create(TestShop.CreateCatalog());
        warehouse.Take(TestShop.Bread);

        Assertions.Throws<ProductOutOfStockException>(() => warehouse.Take(TestShop.Bread), "empty shelf");
    }

    public void ShouldIncreaseQuantityWhenReturning()
    {
        IWarehouse warehouse = WarehouseFactory.Create(TestShop.CreateCatalog());
        warehouse.Take(TestShop.Milk);

        warehouse.Return(TestShop.Milk);

        Assertions.AreEqual(TestShop.MilkQuantity, warehouse.GetQuantity(TestShop.Milk));
    }

    public void ShouldBecomeEmptyWhenEveryUnitIsTaken()
    {
        IWarehouse warehouse = WarehouseFactory.Create(TestShop.CreateCatalog());

        warehouse.Take(TestShop.Milk);
        warehouse.Take(TestShop.Milk);
        warehouse.Take(TestShop.Bread);

        Assertions.IsTrue(warehouse.IsEmpty, "all shelves are empty");
    }

    public void ShouldRefillShelvesWhenRestocking()
    {
        IWarehouse warehouse = WarehouseFactory.Create(TestShop.CreateCatalog());
        warehouse.Take(TestShop.Bread);

        warehouse.Restock();

        Assertions.AreEqual(TestShop.BreadQuantity, warehouse.GetQuantity(TestShop.Bread));
    }

    public void ShouldMarkEmptyShelvesInReport()
    {
        IWarehouse warehouse = WarehouseFactory.Create(TestShop.CreateCatalog());
        warehouse.Take(TestShop.Bread);

        string report = warehouse.Report();

        Assertions.IsTrue(report.Contains("2 L"), "milk quantity with its unit");
        Assertions.IsTrue(report.Contains("[OUT OF STOCK]"), "bread is marked as out of stock");
    }

    public void ShouldThrowUnknownProductForMissingShelf()
    {
        IWarehouse warehouse = WarehouseFactory.Create(TestShop.CreateCatalog());

        Assertions.Throws<UnknownProductException>(() => warehouse.Take("Caviar"), "missing shelf");
    }
}
