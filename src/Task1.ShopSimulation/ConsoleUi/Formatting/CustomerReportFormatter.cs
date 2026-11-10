using System.Text;

namespace Task1.ShopSimulation.ConsoleUi.Formatting;

using Customers;
using Task1.ShopSimulation.Formatting;

internal static class CustomerReportFormatter
{
    private const string ReportHeader = "=== Customers ===";
    private const string LineTemplate =
        "{0,3}. {1,-34} card #{2,-5} balance {3,14}   bought {4,4} units   spent {5,14}";
    private const int FirstPosition = 1;

    public static string Format(IReadOnlyList<ICustomer> customers)
    {
        StringBuilder report = new StringBuilder();
        report.AppendLine(ReportHeader);

        for (int index = 0; index < customers.Count; index++)
        {
            report.AppendLine(DescribeCustomer(index + FirstPosition, customers[index]));
        }

        return report.ToString();
    }

    private static string DescribeCustomer(int position, ICustomer customer)
    {
        return string.Format(LineTemplate, position, customer.Name.FullName, customer.Card.Number,
            MoneyFormatter.Format(customer.Balance), customer.PurchasedCount,
            MoneyFormatter.Format(customer.SpentAmount));
    }
}
