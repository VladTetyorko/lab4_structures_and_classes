namespace Task1.ShopSimulation.Factories;

using Catalog;
using Customers;
using Finance;

internal static class ReceiptFactory
{
    public static Receipt Create(ICustomer customer, ProductDescription product)
    {
        return new Receipt(customer.Name, customer.Card.Number, product.Name, product.Unit, product.UnitPrice);
    }
}
