namespace Task1.ShopSimulation.Customers;

using Finance;

internal sealed class Customer : ICustomer
{
    private readonly IWallet _wallet;
    private int _purchasedCount;
    private decimal _spentAmount;

    public Customer(PersonName name, CustomerCard card, IWallet wallet)
    {
        Name = name;
        Card = card;
        _wallet = wallet;
    }

    public PersonName Name { get; }

    public CustomerCard Card { get; }

    public decimal Balance => _wallet.Balance;

    public int PurchasedCount => _purchasedCount;

    public decimal SpentAmount => _spentAmount;

    public bool CanAfford(decimal price) => _wallet.CanAfford(price);

    void ICustomer.Pay(decimal price)
    {
        _wallet.Withdraw(price);
        _purchasedCount++;
        _spentAmount += price;
    }

    void ICustomer.Refund(decimal price)
    {
        _wallet.Deposit(price);
        _purchasedCount--;
        _spentAmount -= price;
    }
}
