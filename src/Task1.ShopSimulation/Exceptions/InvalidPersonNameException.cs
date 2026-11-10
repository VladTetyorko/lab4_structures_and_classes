namespace Task1.ShopSimulation.Exceptions;

public sealed class InvalidPersonNameException : ShopException
{
    internal InvalidPersonNameException(string message) : base(message)
    {
    }
}
