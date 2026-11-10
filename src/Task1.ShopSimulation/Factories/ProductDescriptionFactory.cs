namespace Task1.ShopSimulation.Factories;

using Catalog;
using Exceptions;

public static class ProductDescriptionFactory
{
    private const decimal MinimumPriceExclusive = 0m;
    private const int MinimumQuantity = 0;
    private const string EmptyNameMessage = "The product name must not be empty.";
    private const string NonPositivePriceMessage = "The product price must be greater than zero.";
    private const string NegativeQuantityMessage = "The product quantity must not be negative.";
    private const string UnknownUnitMessage = "The product unit of measure is unknown.";

    public static ProductDescription Create(string name, decimal unitPrice, int availableQuantity, MeasureUnit unit)
    {
        RequireValid(!string.IsNullOrWhiteSpace(name), EmptyNameMessage);
        RequireValid(unitPrice > MinimumPriceExclusive, NonPositivePriceMessage);
        RequireValid(availableQuantity >= MinimumQuantity, NegativeQuantityMessage);
        RequireValid(Enum.IsDefined(unit), UnknownUnitMessage);

        return new ProductDescription(name.Trim(), unitPrice, availableQuantity, unit);
    }

    private static void RequireValid(bool isValid, string reason)
    {
        if (!isValid)
        {
            throw ShopExceptionFactory.InvalidProductDescription(reason);
        }
    }
}
