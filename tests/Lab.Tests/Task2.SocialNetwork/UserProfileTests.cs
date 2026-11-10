using Task2.SocialNetwork.Application;
using Task2.SocialNetwork.Exceptions;
using Task2.SocialNetwork.Factories;
using Task2.SocialNetwork.Users;

namespace Lab.Tests.Task2.SocialNetwork;

public sealed class UserProfileTests
{
    public void ShouldAddAtSignToNickname()
    {
        UserProfile user = UserProfileFactory.Create("Alice Green", "alice@example.com", "alice");

        Assertions.AreEqual("@alice", user.Nickname);
    }

    public void ShouldKeepSingleAtSignWhenNicknameAlreadyHasIt()
    {
        UserProfile user = UserProfileFactory.Create("Alice Green", "alice@example.com", "@alice");

        Assertions.AreEqual("@alice", user.Nickname);
    }

    public void ShouldRejectEmptyName()
    {
        Assertions.Throws<InvalidUserProfileException>(
            () => UserProfileFactory.Create(" ", "alice@example.com", "@alice"), "empty name");
    }

    public void ShouldRejectEmailWithoutDomain()
    {
        Assertions.Throws<InvalidUserProfileException>(
            () => UserProfileFactory.Create("Alice", "alice@example", "@alice"), "email without dot");
    }

    public void ShouldRejectNicknameWithForbiddenSymbols()
    {
        Assertions.Throws<InvalidUserProfileException>(
            () => UserProfileFactory.Create("Alice", "alice@example.com", "@al ice!"), "spaces and punctuation");
    }

    public void ShouldRejectDuplicateNickname()
    {
        UserProfile[] users =
        {
            UserProfileFactory.Create("Alice", "alice@example.com", "@alice"),
            UserProfileFactory.Create("Alice Twin", "twin@example.com", "@ALICE")
        };

        Assertions.Throws<DuplicateUserException>(
            () => SocialNetworkFactory.Create(users, ClockFactory.CreateSystem()), "same nickname");
    }

    public void ShouldSignInWithNicknameWithoutAtSign()
    {
        IUserSession session = TestNetwork.Create().SignIn("alice");

        Assertions.AreEqual(TestNetwork.Alice, session.CurrentUser.Nickname);
    }

    public void ShouldRejectSignInOfUnknownUser()
    {
        Assertions.Throws<UserNotFoundException>(() => TestNetwork.Create().SignIn("@nobody"), "unknown user");
    }
}
