namespace Task2.SocialNetwork.Factories;

using Users;

internal static class UserDirectoryFactory
{
    public static IUserDirectory Create(IReadOnlyList<UserProfile> users)
    {
        IUserDirectory directory = new UserDirectory();

        foreach (UserProfile user in users)
        {
            directory.Add(user);
        }

        return directory;
    }
}
