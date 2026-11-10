using System.Text;

namespace Task1.ShopSimulation.Finance;

using Exceptions;
using Formatting;

internal sealed class CashRegister : ICashRegister
{
    private const string ReportHeader = "=== Cash register report ===";
    private const string SalesLabel = "Units sold: ";
    private const string ProfitLabel = "Profit: ";
    private const string LineTemplate = "  {0,-16} {1,10}   {2,14}";

    private readonly List<Receipt> _receipts = new List<Receipt>();
    private decimal _profit;

    public decimal Profit => _profit;

    public int SalesCount => _receipts.Count;

    public void Register(Receipt receipt)
    {
        _receipts.Add(receipt);
        _profit += receipt.Price;
    }

    public void Cancel(Receipt receipt)
    {
        if (!_receipts.Remove(receipt))
        {
            throw ShopExceptionFactory.ReceiptNotFound();
        }

        _profit -= receipt.Price;
    }

    public string Report()
    {
        StringBuilder report = new StringBuilder();
        report.AppendLine(ReportHeader);
        report.AppendLine(SalesLabel + SalesCount);
        report.AppendLine(ProfitLabel + MoneyFormatter.Format(_profit));

        foreach (IGrouping<string, Receipt> sales in _receipts.GroupBy(receipt => receipt.ProductName))
        {
            report.AppendLine(DescribeSales(sales));
        }

        return report.ToString();
    }

    private static string DescribeSales(IGrouping<string, Receipt> sales)
    {
        Receipt first = sales.First();
        string quantity = MeasureUnitFormatter.FormatQuantity(sales.Count(), first.Unit);
        string revenue = MoneyFormatter.Format(sales.Sum(receipt => receipt.Price));

        return string.Format(LineTemplate, sales.Key, quantity, revenue);
    }
}
