namespace Task1.ShopSimulation.Finance;

using Catalog;
using Customers;

public sealed class Receipt
{
    internal Receipt(PersonName customerName, int cardNumber, string productName, MeasureUnit unit, decimal price)
    {
        CustomerName = customerName;
        CardNumber = cardNumber;
        ProductName = productName;
        Unit = unit;
        Price = price;
    }

    public PersonName CustomerName { get; }

    public int CardNumber { get; }

    public string ProductName { get; }

    public MeasureUnit Unit { get; }

    public decimal Price { get; }
}
