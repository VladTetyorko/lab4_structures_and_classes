namespace Task1.ShopSimulation.Exceptions;

using Customers;
using Formatting;

internal static class ShopExceptionFactory
{
    private const string Quote = "\"";
    private const string UnknownProductSuffix = "\" is not sold in this shop.";
    private const string DuplicateProductSuffix = "\" is described in the catalog more than once.";
    private const string OutOfStockSuffix =
        "\" is out of stock. What are you trying to buy? The supplies have not arrived yet.";
    private const string NotEnoughMoneyPrefix = "Not enough money: ";
    private const string NeededLabel = " needed, ";
    private const string AvailableLabel = " available.";
    private const string NameSeparator = ": ";
    private const string NonPositiveAmountPrefix = "The amount must be greater than zero, but was ";
    private const string Dot = ".";
    private const string EmptyCatalogMessage = "The catalog must contain at least one product.";
    private const string CustomerCountPrefix = "The number of customers must be between ";
    private const string AndLabel = " and ";
    private const string ButWasLabel = ", but was ";
    private const string ReceiptNotFoundMessage = "The receipt is not registered in the cash register.";

    public static UnknownProductException UnknownProduct(string productName)
    {
        return new UnknownProductException(productName, Quote + productName + UnknownProductSuffix);
    }

    public static DuplicateProductException DuplicateProduct(string productName)
    {
        return new DuplicateProductException(productName, Quote + productName + DuplicateProductSuffix);
    }

    public static ProductOutOfStockException OutOfStock(string productName)
    {
        return new ProductOutOfStockException(productName, Quote + productName + OutOfStockSuffix);
    }

    public static InsufficientFundsException InsufficientFunds(decimal required, decimal available)
    {
        return new InsufficientFundsException(required, available, DescribeShortage(required, available));
    }

    public static InsufficientFundsException InsufficientFunds(PersonName customerName, decimal required,
        decimal available)
    {
        string message = customerName.FullName + NameSeparator + DescribeShortage(required, available);

        return new InsufficientFundsException(required, available, message);
    }

    public static InvalidPersonNameException InvalidPersonName(string reason)
    {
        return new InvalidPersonNameException(reason);
    }

    public static InvalidAmountException NonPositiveAmount(decimal amount)
    {
        return new InvalidAmountException(NonPositiveAmountPrefix + MoneyFormatter.Format(amount) + Dot);
    }

    public static InvalidProductDescriptionException InvalidProductDescription(string reason)
    {
        return new InvalidProductDescriptionException(reason);
    }

    public static EmptyCatalogException EmptyCatalog()
    {
        return new EmptyCatalogException(EmptyCatalogMessage);
    }

    public static InvalidCustomerCountException InvalidCustomerCount(int count, int minimum, int maximum)
    {
        string message = CustomerCountPrefix + minimum + AndLabel + maximum + ButWasLabel + count + Dot;

        return new InvalidCustomerCountException(message);
    }

    public static ReceiptNotFoundException ReceiptNotFound()
    {
        return new ReceiptNotFoundException(ReceiptNotFoundMessage);
    }

    private static string DescribeShortage(decimal required, decimal available)
    {
        return NotEnoughMoneyPrefix + MoneyFormatter.Format(required) + NeededLabel
               + MoneyFormatter.Format(available) + AvailableLabel;
    }
}
