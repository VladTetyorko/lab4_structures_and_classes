using Lab.Tests.Fakes;
using Task1.ShopSimulation.Customers;
using Task1.ShopSimulation.Exceptions;
using Task1.ShopSimulation.Factories;

namespace Lab.Tests.Task1.ShopSimulation;

public sealed class CustomerTests
{
    public void ShouldTrackBalanceItemsAndSpendingWhenPaying()
    {
        ICustomer customer = TestCustomers.Create(1, 100m);

        customer.Pay(30m);

        Assertions.AreEqual(70m, customer.Balance);
        Assertions.AreEqual(1, customer.PurchasedCount);
        Assertions.AreEqual(30m, customer.SpentAmount);
    }

    public void ShouldKeepStateWhenPaymentIsTooBig()
    {
        ICustomer customer = TestCustomers.Create(1, 20m);

        Assertions.Throws<InsufficientFundsException>(() => customer.Pay(30m), "price above balance");
        Assertions.AreEqual(20m, customer.Balance);
        Assertions.AreEqual(0, customer.PurchasedCount);
    }

    public void ShouldRejectNonPositivePayment()
    {
        ICustomer customer = TestCustomers.Create(1, 20m);

        Assertions.Throws<InvalidAmountException>(() => customer.Pay(0m), "zero payment");
    }

    public void ShouldUndoPurchaseWhenRefunded()
    {
        ICustomer customer = TestCustomers.Create(1, 100m);
        customer.Pay(30m);

        customer.Refund(30m);

        Assertions.AreEqual(100m, customer.Balance);
        Assertions.AreEqual(0, customer.PurchasedCount);
        Assertions.AreEqual(0m, customer.SpentAmount);
    }

    public void ShouldCreateRandomCustomerWithLowestBounds()
    {
        ICustomer customer = CustomerFactory.CreateRandom(new BoundaryRandomProvider(false));

        Assertions.AreEqual(CustomerFactory.MinCardNumber, customer.Card.Number);
        Assertions.AreEqual(CustomerFactory.MinStartMoney, customer.Balance);
    }

    public void ShouldCreateRandomCustomerWithHighestBounds()
    {
        ICustomer customer = CustomerFactory.CreateRandom(new BoundaryRandomProvider(true));

        Assertions.AreEqual(CustomerFactory.MaxCardNumber, customer.Card.Number);
        Assertions.AreEqual(CustomerFactory.MaxStartMoney, customer.Balance);
    }

    public void ShouldCreateRequestedNumberOfCustomers()
    {
        IReadOnlyList<ICustomer> customers =
            CustomerFactory.CreateRandomGroup(5, RandomProviderFactory.CreateSeeded(42));

        Assertions.AreEqual(5, customers.Count);
    }

    public void ShouldRejectZeroCustomers()
    {
        Assertions.Throws<InvalidCustomerCountException>(
            () => CustomerFactory.CreateRandomGroup(0, RandomProviderFactory.CreateSeeded(42)), "zero customers");
    }
}
