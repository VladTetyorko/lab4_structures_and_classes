using Lab.Tests.Fakes;
using Task1.ShopSimulation.Customers;
using Task1.ShopSimulation.Exceptions;
using Task1.ShopSimulation.Factories;
using Task1.ShopSimulation.Randomization;

namespace Lab.Tests.Task1.ShopSimulation;

public sealed class PersonNameTests
{
    private const string MalePatronymicEnding = "ovych";
    private const string FemalePatronymicEnding = "ivna";

    public void ShouldComposeFullNameFromTrimmedParts()
    {
        PersonName name = PersonNameFactory.Create(" Olena ", "Ivanivna", " Kovalenko");

        Assertions.AreEqual("Olena Ivanivna Kovalenko", name.FullName);
    }

    public void ShouldRejectNameWithEmptyPart()
    {
        Assertions.Throws<InvalidPersonNameException>(
            () => PersonNameFactory.Create("Olena", " ", "Kovalenko"), "empty patronymic");
    }

    public void ShouldPickFirstNamesFromSetsWhenRandomIsLowest()
    {
        PersonName name = PersonNameFactory.CreateRandom(new BoundaryRandomProvider(false));

        Assertions.AreEqual("Taras Ivanovych Shevchenko", name.FullName);
    }

    public void ShouldPickLastNamesFromSetsWhenRandomIsHighest()
    {
        PersonName name = PersonNameFactory.CreateRandom(new BoundaryRandomProvider(true));

        Assertions.AreEqual("Tetiana Stepanivna Savchuk", name.FullName);
    }

    public void ShouldKeepPatronymicOfTheSameGenderAsFirstName()
    {
        IRandomProvider random = RandomProviderFactory.CreateSeeded(3);

        for (int attempt = 0; attempt < 200; attempt++)
        {
            PersonName name = PersonNameFactory.CreateRandom(random);
            bool isMale = name.Patronymic.EndsWith(MalePatronymicEnding);
            bool isFemale = name.Patronymic.EndsWith(FemalePatronymicEnding);

            Assertions.IsTrue(isMale || isFemale, "patronymic " + name.Patronymic + " has a known ending");
        }
    }

    public void ShouldGiveRandomCustomerAFullName()
    {
        ICustomer customer = CustomerFactory.CreateRandom(new BoundaryRandomProvider(false));

        Assertions.AreEqual("Taras Ivanovych Shevchenko", customer.Name.FullName);
    }
}
