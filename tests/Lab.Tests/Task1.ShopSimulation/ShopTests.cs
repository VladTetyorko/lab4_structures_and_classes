using Lab.Tests.Fakes;
using Task1.ShopSimulation.Catalog;
using Task1.ShopSimulation.Customers;
using Task1.ShopSimulation.Exceptions;
using Task1.ShopSimulation.Factories;
using Task1.ShopSimulation.Finance;
using Task1.ShopSimulation.Shopping;
using Task1.ShopSimulation.Storage;

namespace Lab.Tests.Task1.ShopSimulation;

public sealed class ShopTests
{
    public void ShouldMoveGoodsAndMoneyWhenSelling()
    {
        IProductCatalog catalog = TestShop.CreateCatalog();
        IWarehouse warehouse = WarehouseFactory.Create(catalog);
        ICashRegister cashRegister = CashRegisterFactory.Create();
        IShop shop = TestShop.CreateShop(catalog, warehouse, cashRegister);
        ICustomer customer = TestCustomers.Create(5, 100m);

        Receipt receipt = shop.Sell(customer, TestShop.Milk);

        Assertions.AreEqual(TestShop.MilkQuantity - 1, warehouse.GetQuantity(TestShop.Milk));
        Assertions.AreEqual(100m - TestShop.MilkPrice, customer.Balance);
        Assertions.AreEqual(TestShop.MilkPrice, cashRegister.Profit);
        Assertions.AreEqual(5, receipt.CardNumber);
        Assertions.AreEqual(TestCustomers.FullName, receipt.CustomerName.FullName);
    }

    public void ShouldNameTheCustomerWhoCannotAfford()
    {
        IShop shop = TestShop.CreateShop(new SequenceRandomProvider(TestShop.MilkIndex));

        InsufficientFundsException exception = Assertions.Throws<InsufficientFundsException>(
            () => shop.Sell(TestCustomers.Create(5, 10m), TestShop.Milk), "too poor");

        Assertions.IsTrue(exception.Message.StartsWith(TestCustomers.FullName), "message starts with the name");
    }

    public void ShouldRejectOutOfStockProductWithoutChangingAnything()
    {
        IShop shop = TestShop.CreateShop(new SequenceRandomProvider(TestShop.MilkIndex));
        ICustomer customer = TestCustomers.Create(5, 100m);
        shop.Sell(customer, TestShop.Bread);

        Assertions.Throws<ProductOutOfStockException>(() => shop.Sell(customer, TestShop.Bread), "bread is gone");
        Assertions.AreEqual(100m - TestShop.BreadPrice, customer.Balance);
        Assertions.AreEqual(TestShop.BreadPrice, shop.Profit);
    }

    public void ShouldExplainThatSuppliesHaveNotArrived()
    {
        IShop shop = TestShop.CreateShop(new SequenceRandomProvider(TestShop.MilkIndex));
        ICustomer customer = TestCustomers.Create(5, 100m);
        shop.Sell(customer, TestShop.Bread);

        ProductOutOfStockException exception =
            Assertions.Throws<ProductOutOfStockException>(() => shop.Sell(customer, TestShop.Bread), "bread is gone");

        Assertions.IsTrue(exception.Message.Contains("supplies have not arrived"), "friendly message");
    }

    public void ShouldRejectPurchaseWhenCustomerCannotAfford()
    {
        IProductCatalog catalog = TestShop.CreateCatalog();
        IWarehouse warehouse = WarehouseFactory.Create(catalog);
        IShop shop = TestShop.CreateShop(catalog, warehouse, CashRegisterFactory.Create());
        ICustomer customer = TestCustomers.Create(5, 10m);

        Assertions.Throws<InsufficientFundsException>(() => shop.Sell(customer, TestShop.Milk), "too poor");
        Assertions.AreEqual(TestShop.MilkQuantity, warehouse.GetQuantity(TestShop.Milk));
        Assertions.AreEqual(0m, shop.Profit);
    }

    public void ShouldRejectUnknownProduct()
    {
        IShop shop = TestShop.CreateShop(new SequenceRandomProvider(TestShop.MilkIndex));

        Assertions.Throws<UnknownProductException>(
            () => shop.Sell(TestCustomers.Create(5, 100m), "Caviar"), "unknown product");
    }

    public void ShouldSellProductPickedByRandomizer()
    {
        IShop shop = TestShop.CreateShop(new SequenceRandomProvider(TestShop.BreadIndex));

        Receipt receipt = shop.SellRandom(TestCustomers.Create(5, 100m));

        Assertions.AreEqual(TestShop.Bread, receipt.ProductName);
    }

    public void ShouldNotServeCustomerWhoCannotAffordAnything()
    {
        IShop shop = TestShop.CreateShop(new SequenceRandomProvider(TestShop.MilkIndex));

        Assertions.IsFalse(shop.CanServe(TestCustomers.Create(5, 20m)), "cheapest product costs 25");
        Assertions.IsTrue(shop.CanServe(TestCustomers.Create(6, 25m)), "bread is affordable");
    }

    public void ShouldSellAgainAfterRestock()
    {
        IShop shop = TestShop.CreateShop(new SequenceRandomProvider(TestShop.MilkIndex));
        ICustomer customer = TestCustomers.Create(5, 100m);
        shop.Sell(customer, TestShop.Bread);

        shop.Restock();
        shop.Sell(customer, TestShop.Bread);

        Assertions.AreEqual(2, customer.PurchasedCount);
    }
}
