namespace Task2.SocialNetwork.Validation;

using Exceptions;

internal static class PostContentValidator
{
    private const int MaxPostLength = 500;
    private const int MaxCommentLength = 200;
    private const string EmptyPostMessage = "The post text must not be empty.";
    private const string LongPostMessage = "The post text must not be longer than 500 characters.";
    private const string EmptyCommentMessage = "The comment text must not be empty.";
    private const string LongCommentMessage = "The comment text must not be longer than 200 characters.";

    public static void ValidatePostText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw SocialNetworkExceptionFactory.InvalidPostText(EmptyPostMessage);
        }

        if (text.Trim().Length > MaxPostLength)
        {
            throw SocialNetworkExceptionFactory.InvalidPostText(LongPostMessage);
        }
    }

    public static void ValidateCommentText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw SocialNetworkExceptionFactory.InvalidCommentText(EmptyCommentMessage);
        }

        if (text.Trim().Length > MaxCommentLength)
        {
            throw SocialNetworkExceptionFactory.InvalidCommentText(LongCommentMessage);
        }
    }
}
