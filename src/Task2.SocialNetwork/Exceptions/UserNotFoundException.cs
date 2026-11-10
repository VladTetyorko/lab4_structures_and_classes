namespace Task2.SocialNetwork.Exceptions;

public sealed class UserNotFoundException : SocialNetworkException
{
    internal UserNotFoundException(string nickname, string message) : base(message)
    {
        Nickname = nickname;
    }

    public string Nickname { get; }
}
