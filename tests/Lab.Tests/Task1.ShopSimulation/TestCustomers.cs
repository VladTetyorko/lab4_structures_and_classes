using Task1.ShopSimulation.Customers;
using Task1.ShopSimulation.Factories;

namespace Lab.Tests.Task1.ShopSimulation;

internal static class TestCustomers
{
    public const string FullName = "Ivan Petrovych Shevchenko";

    public static ICustomer Create(int cardNumber, decimal startMoney)
    {
        PersonName name = PersonNameFactory.Create("Ivan", "Petrovych", "Shevchenko");

        return CustomerFactory.Create(name, cardNumber, startMoney);
    }
}
