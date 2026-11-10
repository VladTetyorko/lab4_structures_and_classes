namespace Task1.ShopSimulation.Exceptions;

public sealed class ReceiptNotFoundException : ShopException
{
    internal ReceiptNotFoundException(string message) : base(message)
    {
    }
}
