namespace Task2.SocialNetwork.Exceptions;

public sealed class SelfLikeException : SocialNetworkException
{
    internal SelfLikeException(int postId, string message) : base(message)
    {
        PostId = postId;
    }

    public int PostId { get; }
}
