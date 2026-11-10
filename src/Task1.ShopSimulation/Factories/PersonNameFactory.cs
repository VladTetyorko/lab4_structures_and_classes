namespace Task1.ShopSimulation.Factories;

using Customers;
using Exceptions;
using Randomization;

public static class PersonNameFactory
{
    private const int FirstIndex = 0;
    private const string EmptyPartMessage = "The first name, patronymic and last name must all be filled in.";

    public static PersonName Create(string firstName, string patronymic, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(patronymic)
                                                 || string.IsNullOrWhiteSpace(lastName))
        {
            throw ShopExceptionFactory.InvalidPersonName(EmptyPartMessage);
        }

        return new PersonName(firstName.Trim(), patronymic.Trim(), lastName.Trim());
    }

    public static PersonName CreateRandom(IRandomProvider random)
    {
        GenderedNames names = Pick(DefaultNames.Genders, random);

        return Create(Pick(names.FirstNames, random), Pick(names.Patronymics, random),
            Pick(DefaultNames.LastNames, random));
    }

    private static T Pick<T>(IReadOnlyList<T> items, IRandomProvider random)
    {
        return items[random.Next(FirstIndex, items.Count)];
    }
}
