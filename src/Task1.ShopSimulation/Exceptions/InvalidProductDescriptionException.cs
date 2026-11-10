namespace Task1.ShopSimulation.Exceptions;

public sealed class InvalidProductDescriptionException : ShopException
{
    internal InvalidProductDescriptionException(string message) : base(message)
    {
    }
}
