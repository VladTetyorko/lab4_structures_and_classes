namespace Task2.SocialNetwork.Users;

using Exceptions;
using Validation;

internal sealed class UserDirectory : IUserDirectory
{
    private readonly List<UserProfile> _users = new List<UserProfile>();

    public IReadOnlyList<UserProfile> All => _users.AsReadOnly();

    public void Add(UserProfile user)
    {
        if (_users.Any(existing => IsSameAccount(existing, user)))
        {
            throw SocialNetworkExceptionFactory.DuplicateUser(user.Nickname);
        }

        _users.Add(user);
    }

    public UserProfile Find(string nickname)
    {
        string normalizedNickname = NicknameNormalizer.Normalize(nickname);
        UserProfile? user = _users.FirstOrDefault(candidate =>
            string.Equals(candidate.Nickname, normalizedNickname, StringComparison.OrdinalIgnoreCase));

        return user ?? throw SocialNetworkExceptionFactory.UserNotFound(normalizedNickname);
    }

    private static bool IsSameAccount(UserProfile first, UserProfile second)
    {
        return string.Equals(first.Nickname, second.Nickname, StringComparison.OrdinalIgnoreCase)
               || string.Equals(first.Email, second.Email, StringComparison.OrdinalIgnoreCase);
    }
}
