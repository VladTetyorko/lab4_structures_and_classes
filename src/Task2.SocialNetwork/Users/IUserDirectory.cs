namespace Task2.SocialNetwork.Users;

internal interface IUserDirectory
{
    IReadOnlyList<UserProfile> All { get; }

    void Add(UserProfile user);

    UserProfile Find(string nickname);
}
