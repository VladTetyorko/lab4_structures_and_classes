namespace Task2.SocialNetwork.Exceptions;

public sealed class NotSignedInException : SocialNetworkException
{
    internal NotSignedInException(string message) : base(message)
    {
    }
}
