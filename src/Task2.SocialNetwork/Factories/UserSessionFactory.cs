namespace Task2.SocialNetwork.Factories;

using Application;
using Time;
using Users;

internal static class UserSessionFactory
{
    public static IUserSession Create(UserProfile currentUser, IUserDirectory users, IPostService posts, IClock clock)
    {
        return new UserSession(currentUser, users, posts, clock);
    }
}
