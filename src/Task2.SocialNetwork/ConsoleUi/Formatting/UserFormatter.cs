using System.Text;

namespace Task2.SocialNetwork.ConsoleUi.Formatting;

using Users;

internal static class UserFormatter
{
    private const string Header = "=== Users ===";
    private const string LineTemplate = "{0,-10} {1,-18} {2}";

    public static string FormatMany(IReadOnlyList<UserProfile> users)
    {
        StringBuilder text = new StringBuilder();
        text.AppendLine(Header);

        foreach (UserProfile user in users)
        {
            text.AppendLine(string.Format(LineTemplate, user.Nickname, user.Name, user.Email));
        }

        return text.ToString();
    }
}
