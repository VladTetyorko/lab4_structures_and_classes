using System.Text;

namespace Task1.ShopSimulation.Storage;

using Catalog;
using Exceptions;
using Factories;
using Formatting;

internal sealed class Warehouse : IWarehouse
{
    private const string ReportHeader = "=== Warehouse report ===";
    private const string LineTemplate = "{0,-16} {1,10}   {2,12} per {3}{4}";
    private const string OutOfStockMark = "   [OUT OF STOCK]";
    private const string NoMark = "";

    private readonly IProductCatalog _catalog;
    private readonly Dictionary<string, Shelf> _shelves =
        new Dictionary<string, Shelf>(StringComparer.OrdinalIgnoreCase);

    public Warehouse(IProductCatalog catalog)
    {
        _catalog = catalog;

        foreach (ProductDescription product in catalog.Products)
        {
            _shelves[product.Name] = ShelfFactory.Create(product);
        }
    }

    public IReadOnlyList<ProductDescription> Assortment => _catalog.Products;

    public bool IsEmpty => !_shelves.Values.Any(shelf => shelf.IsAvailable);

    public ProductDescription FindProduct(string productName) => _catalog.Find(productName);

    public int GetQuantity(string productName) => FindShelf(productName).Quantity;

    public bool IsInStock(string productName) => FindShelf(productName).IsAvailable;

    public void Take(string productName) => FindShelf(productName).TakeOne();

    public void Return(string productName) => FindShelf(productName).PutOne();

    public void Restock()
    {
        foreach (ProductDescription product in _catalog.Products)
        {
            _shelves[product.Name].Refill(product.AvailableQuantity);
        }
    }

    public string Report()
    {
        StringBuilder report = new StringBuilder();
        report.AppendLine(ReportHeader);

        foreach (ProductDescription product in _catalog.Products)
        {
            report.AppendLine(DescribeShelf(product, _shelves[product.Name]));
        }

        return report.ToString();
    }

    private static string DescribeShelf(ProductDescription product, Shelf shelf)
    {
        string quantity = MeasureUnitFormatter.FormatQuantity(shelf.Quantity, shelf.Unit);
        string price = MoneyFormatter.Format(product.UnitPrice);
        string mark = shelf.IsAvailable ? NoMark : OutOfStockMark;

        return string.Format(LineTemplate, product.Name, quantity, price,
            MeasureUnitFormatter.Format(shelf.Unit), mark);
    }

    private Shelf FindShelf(string productName)
    {
        if (_shelves.TryGetValue(productName, out Shelf? shelf))
        {
            return shelf;
        }

        throw ShopExceptionFactory.UnknownProduct(productName);
    }
}
