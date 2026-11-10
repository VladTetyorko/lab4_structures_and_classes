namespace Task2.SocialNetwork.Validation;

using Exceptions;

internal static class UserProfileValidator
{
    private const int MinNicknameLength = 3;
    private const int MaxNicknameLength = 20;
    private const int NotFound = -1;
    private const int MinLocalPartLength = 1;
    private const int NeighbourOffset = 1;
    private const char Space = ' ';
    private const char AtSign = '@';
    private const char DomainSeparator = '.';
    private const char Underscore = '_';
    private const string EmptyNameMessage = "The user name must not be empty.";
    private const string InvalidEmailMessage = "The email must look like name@domain.com.";
    private const string InvalidNicknameMessage =
        "The nickname must contain 3 to 20 letters, digits or underscores.";

    public static void Validate(string name, string email, string nickname)
    {
        Require(!string.IsNullOrWhiteSpace(name), EmptyNameMessage);
        Require(IsValidEmail(email.Trim()), InvalidEmailMessage);
        Require(IsValidNickname(NicknameNormalizer.StripPrefix(nickname)), InvalidNicknameMessage);
    }

    private static bool IsValidEmail(string email)
    {
        int atIndex = email.IndexOf(AtSign);
        int dotIndex = email.LastIndexOf(DomainSeparator);

        return atIndex >= MinLocalPartLength
               && atIndex == email.LastIndexOf(AtSign)
               && dotIndex > atIndex + NeighbourOffset
               && dotIndex < email.Length - NeighbourOffset
               && email.IndexOf(Space) == NotFound;
    }

    private static bool IsValidNickname(string nickname)
    {
        return nickname.Length >= MinNicknameLength
               && nickname.Length <= MaxNicknameLength
               && nickname.All(symbol => char.IsLetterOrDigit(symbol) || symbol == Underscore);
    }

    private static void Require(bool isValid, string reason)
    {
        if (!isValid)
        {
            throw SocialNetworkExceptionFactory.InvalidUserProfile(reason);
        }
    }
}
