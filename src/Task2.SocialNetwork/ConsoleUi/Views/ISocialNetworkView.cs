namespace Task2.SocialNetwork.ConsoleUi.Views;

using Exceptions;
using Menu;
using Posts;
using Users;

internal interface ISocialNetworkView : IMenuView
{
    void ShowWelcome();

    void ShowGoodbye();

    void ShowUsers(IReadOnlyList<UserProfile> users);

    string? AskNicknameToSignIn();

    void ShowSignedIn(UserProfile user);

    string AskAuthorNickname();

    int? AskPostId();

    string AskPostText();

    string AskCommentText();

    void ShowPost(PostView post);

    void ShowPosts(IReadOnlyList<PostView> posts);

    void ShowPostDeleted();

    void ShowError(SocialNetworkException error);
}
