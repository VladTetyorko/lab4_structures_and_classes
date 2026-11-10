namespace Task1.ShopSimulation.Exceptions;

public abstract class ShopException : Exception
{
    protected ShopException(string message) : base(message)
    {
    }
}
