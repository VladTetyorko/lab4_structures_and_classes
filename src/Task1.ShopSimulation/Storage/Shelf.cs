namespace Task1.ShopSimulation.Storage;

using Catalog;
using Exceptions;

internal sealed class Shelf
{
    private const int EmptyQuantity = 0;

    public Shelf(string productName, MeasureUnit unit, int quantity)
    {
        ProductName = productName;
        Unit = unit;
        Quantity = quantity;
    }

    public string ProductName { get; }

    public MeasureUnit Unit { get; }

    public int Quantity { get; private set; }

    public bool IsAvailable => Quantity > EmptyQuantity;

    public void TakeOne()
    {
        if (!IsAvailable)
        {
            throw ShopExceptionFactory.OutOfStock(ProductName);
        }

        Quantity--;
    }

    public void PutOne()
    {
        Quantity++;
    }

    public void Refill(int quantity)
    {
        Quantity = quantity;
    }
}
