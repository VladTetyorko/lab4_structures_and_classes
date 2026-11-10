namespace Task2.SocialNetwork.Exceptions;

public sealed class InvalidPostTextException : SocialNetworkException
{
    internal InvalidPostTextException(string message) : base(message)
    {
    }
}
