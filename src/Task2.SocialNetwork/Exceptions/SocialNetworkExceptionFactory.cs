namespace Task2.SocialNetwork.Exceptions;

internal static class SocialNetworkExceptionFactory
{
    private const string UserNotFoundPrefix = "There is no user ";
    private const string DuplicateUserPrefix = "A user with the same nickname or email already exists: ";
    private const string PostNotFoundPrefix = "There is no post #";
    private const string PostOwnershipPrefix = "You can change or delete only your own posts. Post #";
    private const string PostOwnershipSuffix = " belongs to another user.";
    private const string SelfLikePrefix = "You cannot like your own post #";
    private const string DuplicateLikePrefix = "You have already liked post #";
    private const string NotSignedInMessage = "Please sign in first.";
    private const string Dot = ".";

    public static UserNotFoundException UserNotFound(string nickname)
    {
        return new UserNotFoundException(nickname, UserNotFoundPrefix + nickname + Dot);
    }

    public static DuplicateUserException DuplicateUser(string nickname)
    {
        return new DuplicateUserException(nickname, DuplicateUserPrefix + nickname + Dot);
    }

    public static InvalidUserProfileException InvalidUserProfile(string reason)
    {
        return new InvalidUserProfileException(reason);
    }

    public static PostNotFoundException PostNotFound(int postId)
    {
        return new PostNotFoundException(postId, PostNotFoundPrefix + postId + Dot);
    }

    public static PostOwnershipException PostOwnership(int postId)
    {
        return new PostOwnershipException(postId, PostOwnershipPrefix + postId + PostOwnershipSuffix);
    }

    public static SelfLikeException SelfLike(int postId)
    {
        return new SelfLikeException(postId, SelfLikePrefix + postId + Dot);
    }

    public static DuplicateLikeException DuplicateLike(int postId)
    {
        return new DuplicateLikeException(postId, DuplicateLikePrefix + postId + Dot);
    }

    public static InvalidPostTextException InvalidPostText(string reason)
    {
        return new InvalidPostTextException(reason);
    }

    public static InvalidCommentTextException InvalidCommentText(string reason)
    {
        return new InvalidCommentTextException(reason);
    }

    public static NotSignedInException NotSignedIn()
    {
        return new NotSignedInException(NotSignedInMessage);
    }
}
