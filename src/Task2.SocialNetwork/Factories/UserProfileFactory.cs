namespace Task2.SocialNetwork.Factories;

using Users;
using Validation;

public static class UserProfileFactory
{
    public static UserProfile Create(string name, string email, string nickname)
    {
        UserProfileValidator.Validate(name, email, nickname);

        return new UserProfile(name.Trim(), email.Trim(), NicknameNormalizer.Normalize(nickname));
    }
}
