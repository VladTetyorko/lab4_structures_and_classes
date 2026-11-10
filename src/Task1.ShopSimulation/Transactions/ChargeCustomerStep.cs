namespace Task1.ShopSimulation.Transactions;

using Customers;

internal sealed class ChargeCustomerStep : ITransactionStep
{
    private readonly ICustomer _customer;
    private readonly decimal _price;

    public ChargeCustomerStep(ICustomer customer, decimal price)
    {
        _customer = customer;
        _price = price;
    }

    public void Execute() => _customer.Pay(_price);

    public void Rollback() => _customer.Refund(_price);
}
