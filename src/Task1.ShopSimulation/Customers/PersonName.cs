namespace Task1.ShopSimulation.Customers;

public readonly struct PersonName
{
    private const string Separator = " ";

    internal PersonName(string firstName, string patronymic, string lastName)
    {
        FirstName = firstName;
        Patronymic = patronymic;
        LastName = lastName;
    }

    public string FirstName { get; }

    public string Patronymic { get; }

    public string LastName { get; }

    public string FullName => FirstName + Separator + Patronymic + Separator + LastName;
}
