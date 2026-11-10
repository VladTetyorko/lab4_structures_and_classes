namespace Task2.SocialNetwork.Application;

using Factories;
using Time;
using Users;

internal sealed class SocialNetworkPlatform : ISocialNetwork
{
    private readonly IUserDirectory _users;
    private readonly IPostService _posts;
    private readonly IClock _clock;

    public SocialNetworkPlatform(IUserDirectory users, IPostService posts, IClock clock)
    {
        _users = users;
        _posts = posts;
        _clock = clock;
    }

    public IReadOnlyList<UserProfile> Users => _users.All;

    public IUserSession SignIn(string nickname)
    {
        return UserSessionFactory.Create(_users.Find(nickname), _users, _posts, _clock);
    }
}
