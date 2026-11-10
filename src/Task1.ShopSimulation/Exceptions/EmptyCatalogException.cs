namespace Task1.ShopSimulation.Exceptions;

public sealed class EmptyCatalogException : ShopException
{
    internal EmptyCatalogException(string message) : base(message)
    {
    }
}
