using System.Text;

namespace Task1.ShopSimulation.ConsoleUi.Formatting;

using Catalog;
using Task1.ShopSimulation.Formatting;

internal static class AssortmentFormatter
{
    private const string Header = "=== Assortment ===";
    private const string LineTemplate = "{0,3}. {1,-16} {2,12} per {3}";
    private const int FirstPosition = 1;

    public static string Format(IReadOnlyList<ProductDescription> products)
    {
        StringBuilder text = new StringBuilder();
        text.AppendLine(Header);

        for (int index = 0; index < products.Count; index++)
        {
            ProductDescription product = products[index];
            text.AppendLine(string.Format(LineTemplate, index + FirstPosition, product.Name,
                MoneyFormatter.Format(product.UnitPrice), MeasureUnitFormatter.Format(product.Unit)));
        }

        return text.ToString();
    }
}
