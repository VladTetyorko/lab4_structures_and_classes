namespace Task1.ShopSimulation.Exceptions;

public sealed class DuplicateProductException : ShopException
{
    internal DuplicateProductException(string productName, string message) : base(message)
    {
        ProductName = productName;
    }

    public string ProductName { get; }
}
