namespace Task2.SocialNetwork.Validation;

internal static class NicknameNormalizer
{
    public const char NicknamePrefix = '@';

    public static string Normalize(string nickname)
    {
        return NicknamePrefix + StripPrefix(nickname);
    }

    public static string StripPrefix(string nickname)
    {
        return nickname.Trim().TrimStart(NicknamePrefix);
    }
}
