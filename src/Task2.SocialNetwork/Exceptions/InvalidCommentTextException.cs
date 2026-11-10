namespace Task2.SocialNetwork.Exceptions;

public sealed class InvalidCommentTextException : SocialNetworkException
{
    internal InvalidCommentTextException(string message) : base(message)
    {
    }
}
