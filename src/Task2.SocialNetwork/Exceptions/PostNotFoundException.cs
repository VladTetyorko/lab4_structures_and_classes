namespace Task2.SocialNetwork.Exceptions;

public sealed class PostNotFoundException : SocialNetworkException
{
    internal PostNotFoundException(int postId, string message) : base(message)
    {
        PostId = postId;
    }

    public int PostId { get; }
}
