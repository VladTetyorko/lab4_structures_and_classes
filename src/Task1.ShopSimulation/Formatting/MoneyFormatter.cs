using System.Globalization;

namespace Task1.ShopSimulation.Formatting;

public static class MoneyFormatter
{
    private const string MoneyFormat = "0.00";
    private const string CurrencySuffix = " UAH";

    public static string Format(decimal amount)
    {
        return amount.ToString(MoneyFormat, CultureInfo.InvariantCulture) + CurrencySuffix;
    }
}
