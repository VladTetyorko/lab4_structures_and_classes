namespace Task1.ShopSimulation.ConsoleUi.Formatting;

using Finance;
using Task1.ShopSimulation.Formatting;

internal static class ReceiptFormatter
{
    private const int SingleUnit = 1;
    private const string BoughtLabel = " bought ";
    private const string OfLabel = " of ";
    private const string ForLabel = " for ";

    public static string Format(Receipt receipt)
    {
        return receipt.CustomerName.FullName + BoughtLabel
               + MeasureUnitFormatter.FormatQuantity(SingleUnit, receipt.Unit) + OfLabel + receipt.ProductName
               + ForLabel + MoneyFormatter.Format(receipt.Price);
    }
}
