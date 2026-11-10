namespace Task1.ShopSimulation.Factories;

using Customers;

internal static class GenderedNamesFactory
{
    public static GenderedNames Create(IReadOnlyList<string> firstNames, IReadOnlyList<string> patronymics)
    {
        return new GenderedNames(firstNames, patronymics);
    }
}
