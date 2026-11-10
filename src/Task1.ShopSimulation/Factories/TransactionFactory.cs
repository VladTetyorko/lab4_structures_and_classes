namespace Task1.ShopSimulation.Factories;

using Customers;
using Finance;
using Storage;
using Transactions;

internal static class TransactionFactory
{
    public static Transaction CreatePurchase(IWarehouse warehouse, ICustomer customer,
        ICashRegister cashRegister, Receipt receipt)
    {
        ITransactionStep[] steps =
        {
            new TakeFromWarehouseStep(warehouse, receipt.ProductName),
            new ChargeCustomerStep(customer, receipt.Price),
            new RegisterSaleStep(cashRegister, receipt)
        };

        return Create(steps);
    }

    public static Transaction Create(IReadOnlyList<ITransactionStep> steps)
    {
        return new Transaction(steps);
    }
}
