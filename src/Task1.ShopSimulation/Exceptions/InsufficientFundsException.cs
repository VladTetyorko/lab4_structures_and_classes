namespace Task1.ShopSimulation.Exceptions;

public sealed class InsufficientFundsException : ShopException
{
    internal InsufficientFundsException(decimal required, decimal available, string message) : base(message)
    {
        Required = required;
        Available = available;
    }

    public decimal Required { get; }

    public decimal Available { get; }
}
