namespace Task2.SocialNetwork.Users;

public sealed class UserProfile
{
    internal UserProfile(string name, string email, string nickname)
    {
        Name = name;
        Email = email;
        Nickname = nickname;
    }

    public string Name { get; }

    public string Email { get; }

    public string Nickname { get; }
}
