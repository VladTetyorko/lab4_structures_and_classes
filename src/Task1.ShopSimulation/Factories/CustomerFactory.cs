namespace Task1.ShopSimulation.Factories;

using Customers;
using Exceptions;
using Randomization;

public static class CustomerFactory
{
    public const int MinCardNumber = 1;
    public const int MaxCardNumber = 1000;
    public const int MinStartMoney = 1000;
    public const int MaxStartMoney = 10_000;
    public const int MinCustomerCount = 1;
    public const int MaxCustomerCount = 1000;
    private const int InclusiveBoundOffset = 1;

    public static ICustomer Create(PersonName name, int cardNumber, decimal startMoney)
    {
        CustomerCard card = new CustomerCard(cardNumber);

        return new Customer(name, card, WalletFactory.Create(startMoney));
    }

    public static ICustomer CreateRandom(IRandomProvider random)
    {
        PersonName name = PersonNameFactory.CreateRandom(random);
        int cardNumber = random.Next(MinCardNumber, MaxCardNumber + InclusiveBoundOffset);
        int startMoney = random.Next(MinStartMoney, MaxStartMoney + InclusiveBoundOffset);

        return Create(name, cardNumber, startMoney);
    }

    public static IReadOnlyList<ICustomer> CreateRandomGroup(int count, IRandomProvider random)
    {
        if (count < MinCustomerCount || count > MaxCustomerCount)
        {
            throw ShopExceptionFactory.InvalidCustomerCount(count, MinCustomerCount, MaxCustomerCount);
        }

        return Enumerable.Range(0, count).Select(_ => CreateRandom(random)).ToArray();
    }
}
