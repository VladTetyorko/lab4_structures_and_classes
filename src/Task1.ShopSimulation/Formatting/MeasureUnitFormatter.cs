namespace Task1.ShopSimulation.Formatting;

using Catalog;

public static class MeasureUnitFormatter
{
    private const string KilogramSymbol = "kg";
    private const string LiterSymbol = "L";
    private const string PackSymbol = "pack";
    private const string UnknownSymbol = "unit";
    private const string Space = " ";

    public static string Format(MeasureUnit unit)
    {
        switch (unit)
        {
            case MeasureUnit.Kilogram:
                return KilogramSymbol;
            case MeasureUnit.Liter:
                return LiterSymbol;
            case MeasureUnit.Pack:
                return PackSymbol;
            default:
                return UnknownSymbol;
        }
    }

    public static string FormatQuantity(int quantity, MeasureUnit unit)
    {
        return quantity + Space + Format(unit);
    }
}
