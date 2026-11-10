using Lab.Tests.Fakes;
using Task2.SocialNetwork.Application;
using Task2.SocialNetwork.Factories;
using Task2.SocialNetwork.Users;

namespace Lab.Tests.Task2.SocialNetwork;

internal static class TestNetwork
{
    public const string Alice = "@alice";
    public const string Bob = "@bob";
    public static readonly DateTime Start = new DateTime(2026, 11, 1, 9, 0, 0);

    public static ISocialNetwork Create(ManualClock clock)
    {
        UserProfile[] users =
        {
            UserProfileFactory.Create("Alice Green", "alice@example.com", Alice),
            UserProfileFactory.Create("Bob Brown", "bob@example.com", Bob)
        };

        return SocialNetworkFactory.Create(users, clock);
    }

    public static ISocialNetwork Create()
    {
        return Create(new ManualClock(Start));
    }
}
