namespace Task1.ShopSimulation.Shopping;

using Catalog;
using Customers;
using Exceptions;
using Factories;
using Finance;
using Randomization;
using Storage;
using Transactions;

internal sealed class Shop : IShop
{
    private readonly IWarehouse _warehouse;
    private readonly ICashRegister _cashRegister;
    private readonly IProductRandomizer _randomizer;

    public Shop(IWarehouse warehouse, ICashRegister cashRegister, IProductRandomizer randomizer)
    {
        _warehouse = warehouse;
        _cashRegister = cashRegister;
        _randomizer = randomizer;
    }

    public IReadOnlyList<ProductDescription> Assortment => _warehouse.Assortment;

    public decimal Profit => _cashRegister.Profit;

    public bool IsSoldOut => _warehouse.IsEmpty;

    public Receipt Sell(ICustomer customer, string productName)
    {
        ProductDescription product = _warehouse.FindProduct(productName);
        EnsureInStock(product);
        EnsureAffordable(customer, product);

        Receipt receipt = ReceiptFactory.Create(customer, product);
        Transaction purchase = TransactionFactory.CreatePurchase(_warehouse, customer, _cashRegister, receipt);
        purchase.Commit();

        return receipt;
    }

    public Receipt SellRandom(ICustomer customer)
    {
        return Sell(customer, _randomizer.PickProduct().Name);
    }

    public bool CanServe(ICustomer customer)
    {
        return _warehouse.Assortment.Any(product =>
            _warehouse.IsInStock(product.Name) && customer.CanAfford(product.UnitPrice));
    }

    public void Restock() => _warehouse.Restock();

    public string GetWarehouseReport() => _warehouse.Report();

    public string GetCashRegisterReport() => _cashRegister.Report();

    private void EnsureInStock(ProductDescription product)
    {
        if (!_warehouse.IsInStock(product.Name))
        {
            throw ShopExceptionFactory.OutOfStock(product.Name);
        }
    }

    private static void EnsureAffordable(ICustomer customer, ProductDescription product)
    {
        if (!customer.CanAfford(product.UnitPrice))
        {
            throw ShopExceptionFactory.InsufficientFunds(customer.Name, product.UnitPrice, customer.Balance);
        }
    }
}
