namespace Task2.SocialNetwork.Exceptions;

public sealed class DuplicateLikeException : SocialNetworkException
{
    internal DuplicateLikeException(int postId, string message) : base(message)
    {
        PostId = postId;
    }

    public int PostId { get; }
}
