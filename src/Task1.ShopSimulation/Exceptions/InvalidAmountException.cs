namespace Task1.ShopSimulation.Exceptions;

public sealed class InvalidAmountException : ShopException
{
    internal InvalidAmountException(string message) : base(message)
    {
    }
}
