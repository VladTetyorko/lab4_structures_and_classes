namespace Task2.SocialNetwork.Exceptions;

public abstract class SocialNetworkException : Exception
{
    protected SocialNetworkException(string message) : base(message)
    {
    }
}
