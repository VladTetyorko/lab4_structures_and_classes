namespace Task2.SocialNetwork.Exceptions;

public sealed class PostOwnershipException : SocialNetworkException
{
    internal PostOwnershipException(int postId, string message) : base(message)
    {
        PostId = postId;
    }

    public int PostId { get; }
}
