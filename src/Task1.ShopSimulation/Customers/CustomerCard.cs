namespace Task1.ShopSimulation.Customers;

public sealed class CustomerCard
{
    internal CustomerCard(int number)
    {
        Number = number;
    }

    public int Number { get; }
}
