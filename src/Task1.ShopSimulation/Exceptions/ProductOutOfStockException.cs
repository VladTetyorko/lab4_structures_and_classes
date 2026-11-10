namespace Task1.ShopSimulation.Exceptions;

public sealed class ProductOutOfStockException : ShopException
{
    internal ProductOutOfStockException(string productName, string message) : base(message)
    {
        ProductName = productName;
    }

    public string ProductName { get; }
}
