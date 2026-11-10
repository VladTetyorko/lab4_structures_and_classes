namespace Task1.ShopSimulation.Exceptions;

public sealed class UnknownProductException : ShopException
{
    internal UnknownProductException(string productName, string message) : base(message)
    {
        ProductName = productName;
    }

    public string ProductName { get; }
}
