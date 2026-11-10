namespace Task2.SocialNetwork.Application;

using Users;

public interface ISocialNetwork
{
    IReadOnlyList<UserProfile> Users { get; }

    IUserSession SignIn(string nickname);
}
