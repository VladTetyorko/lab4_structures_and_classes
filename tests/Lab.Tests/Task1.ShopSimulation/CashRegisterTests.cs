using Task1.ShopSimulation.Catalog;
using Task1.ShopSimulation.Exceptions;
using Task1.ShopSimulation.Factories;
using Task1.ShopSimulation.Finance;

namespace Lab.Tests.Task1.ShopSimulation;

public sealed class CashRegisterTests
{
    public void ShouldStartWithZeroProfit()
    {
        ICashRegister cashRegister = CashRegisterFactory.Create();

        Assertions.AreEqual(0m, cashRegister.Profit);
        Assertions.AreEqual(0, cashRegister.SalesCount);
    }

    public void ShouldIncreaseProfitByReceiptPrice()
    {
        ICashRegister cashRegister = CashRegisterFactory.Create();

        cashRegister.Register(CreateMilkReceipt());
        cashRegister.Register(CreateMilkReceipt());

        Assertions.AreEqual(TestShop.MilkPrice * 2, cashRegister.Profit);
        Assertions.AreEqual(2, cashRegister.SalesCount);
    }

    public void ShouldRestoreProfitWhenReceiptIsCancelled()
    {
        ICashRegister cashRegister = CashRegisterFactory.Create();
        Receipt receipt = CreateMilkReceipt();
        cashRegister.Register(receipt);

        cashRegister.Cancel(receipt);

        Assertions.AreEqual(0m, cashRegister.Profit);
    }

    public void ShouldThrowWhenCancellingUnknownReceipt()
    {
        ICashRegister cashRegister = CashRegisterFactory.Create();

        Assertions.Throws<ReceiptNotFoundException>(() => cashRegister.Cancel(CreateMilkReceipt()), "unknown receipt");
    }

    public void ShouldShowProfitAndSoldProductsInReport()
    {
        ICashRegister cashRegister = CashRegisterFactory.Create();
        cashRegister.Register(CreateMilkReceipt());

        string report = cashRegister.Report();

        Assertions.IsTrue(report.Contains("Profit: 40.00 UAH"), "profit line");
        Assertions.IsTrue(report.Contains(TestShop.Milk), "sold product line");
    }

    private static Receipt CreateMilkReceipt()
    {
        ProductDescription milk = TestShop.CreateCatalog().Find(TestShop.Milk);

        return ReceiptFactory.Create(TestCustomers.Create(7, 100m), milk);
    }
}
