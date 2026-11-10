namespace Task1.ShopSimulation.Exceptions;

public sealed class InvalidCustomerCountException : ShopException
{
    internal InvalidCustomerCountException(string message) : base(message)
    {
    }
}
