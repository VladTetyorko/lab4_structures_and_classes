using System.Text;

namespace Task1.ShopSimulation.ConsoleUi.Formatting;

using Customers;
using Task1.ShopSimulation.Formatting;
using Shopping;
using Simulation;

internal static class FinalReportFormatter
{
    private const string ReportHeader = "=== Final report ===";
    private const string ProfitLabel = "Shop profit: ";
    private const string TopByItemsLabel = "Most items bought: ";
    private const string TopBySpendingLabel = "Most money spent: ";
    private const string CardLabel = " (card #";
    private const string DetailsSeparator = ", ";
    private const string UnitsSuffix = " units)";
    private const string ClosingBracket = ")";
    private const string NobodyBoughtMessage = "Nobody has bought anything yet.";

    public static string Format(IShop shop, IReadOnlyList<ICustomer> customers)
    {
        StringBuilder report = new StringBuilder();
        report.AppendLine(ReportHeader);
        report.AppendLine(ProfitLabel + MoneyFormatter.Format(shop.Profit));
        report.AppendLine(DescribeTopByItems(CustomerRanking.FindTopBuyerByItems(customers)));
        report.AppendLine(DescribeTopBySpending(CustomerRanking.FindTopBuyerBySpending(customers)));

        return report.ToString();
    }

    private static string DescribeTopByItems(ICustomer? leader)
    {
        if (leader == null)
        {
            return NobodyBoughtMessage;
        }

        return TopByItemsLabel + DescribeCustomer(leader) + leader.PurchasedCount + UnitsSuffix;
    }

    private static string DescribeTopBySpending(ICustomer? leader)
    {
        if (leader == null)
        {
            return NobodyBoughtMessage;
        }

        return TopBySpendingLabel + DescribeCustomer(leader) + MoneyFormatter.Format(leader.SpentAmount) + ClosingBracket;
    }

    private static string DescribeCustomer(ICustomer customer)
    {
        return customer.Name.FullName + CardLabel + customer.Card.Number + DetailsSeparator;
    }
}
