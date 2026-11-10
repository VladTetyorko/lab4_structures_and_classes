namespace Task2.SocialNetwork.Exceptions;

public sealed class InvalidUserProfileException : SocialNetworkException
{
    internal InvalidUserProfileException(string message) : base(message)
    {
    }
}
