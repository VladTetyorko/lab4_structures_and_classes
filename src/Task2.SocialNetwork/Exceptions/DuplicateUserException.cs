namespace Task2.SocialNetwork.Exceptions;

public sealed class DuplicateUserException : SocialNetworkException
{
    internal DuplicateUserException(string nickname, string message) : base(message)
    {
        Nickname = nickname;
    }

    public string Nickname { get; }
}
