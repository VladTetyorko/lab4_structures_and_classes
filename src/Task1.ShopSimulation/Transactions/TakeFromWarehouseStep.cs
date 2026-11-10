namespace Task1.ShopSimulation.Transactions;

using Storage;

internal sealed class TakeFromWarehouseStep : ITransactionStep
{
    private readonly IWarehouse _warehouse;
    private readonly string _productName;

    public TakeFromWarehouseStep(IWarehouse warehouse, string productName)
    {
        _warehouse = warehouse;
        _productName = productName;
    }

    public void Execute() => _warehouse.Take(_productName);

    public void Rollback() => _warehouse.Return(_productName);
}
