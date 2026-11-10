namespace Task1.ShopSimulation.Customers;

using Factories;

internal static class DefaultNames
{
    public static readonly IReadOnlyList<GenderedNames> Genders = new[]
    {
        GenderedNamesFactory.Create(
            new[] { "Taras", "Andrii", "Oleksandr", "Dmytro", "Mykola", "Bohdan", "Ivan", "Petro", "Yurii", "Serhii" },
            new[]
            {
                "Ivanovych", "Petrovych", "Mykolaiovych", "Andriiovych", "Serhiiovych",
                "Volodymyrovych", "Oleksandrovych", "Vasylovych", "Hryhorovych", "Stepanovych"
            }),
        GenderedNamesFactory.Create(
            new[] { "Olena", "Iryna", "Oksana", "Nataliia", "Mariia", "Sofiia", "Kateryna", "Yuliia", "Anna", "Tetiana" },
            new[]
            {
                "Ivanivna", "Petrivna", "Mykolaivna", "Andriivna", "Serhiivna",
                "Volodymyrivna", "Oleksandrivna", "Vasylivna", "Hryhorivna", "Stepanivna"
            })
    };

    public static readonly IReadOnlyList<string> LastNames = new[]
    {
        "Shevchenko", "Kovalenko", "Bondarenko", "Tkachuk", "Kravchuk",
        "Melnyk", "Boiko", "Lysenko", "Marchenko", "Savchuk"
    };
}
