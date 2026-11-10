namespace Task1.ShopSimulation.Customers;

public interface ICustomer
{
    PersonName Name { get; }

    CustomerCard Card { get; }

    decimal Balance { get; }

    int PurchasedCount { get; }

    decimal SpentAmount { get; }

    bool CanAfford(decimal price);

    internal void Pay(decimal price);

    internal void Refund(decimal price);
}
