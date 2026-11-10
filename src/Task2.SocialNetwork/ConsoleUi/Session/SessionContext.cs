namespace Task2.SocialNetwork.ConsoleUi.Session;

using Application;
using Exceptions;
using Users;

internal sealed class SessionContext
{
    private readonly ISocialNetwork _network;
    private IUserSession? _currentSession;

    public SessionContext(ISocialNetwork network)
    {
        _network = network;
    }

    public IReadOnlyList<UserProfile> Users => _network.Users;

    public IUserSession CurrentSession => _currentSession ?? throw SocialNetworkExceptionFactory.NotSignedIn();

    public UserProfile SignIn(string nickname)
    {
        _currentSession = _network.SignIn(nickname);

        return _currentSession.CurrentUser;
    }
}
