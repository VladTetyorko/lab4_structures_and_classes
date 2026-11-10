namespace Task1.ShopSimulation.Customers;

internal readonly struct GenderedNames
{
    public GenderedNames(IReadOnlyList<string> firstNames, IReadOnlyList<string> patronymics)
    {
        FirstNames = firstNames;
        Patronymics = patronymics;
    }

    public IReadOnlyList<string> FirstNames { get; }

    public IReadOnlyList<string> Patronymics { get; }
}
