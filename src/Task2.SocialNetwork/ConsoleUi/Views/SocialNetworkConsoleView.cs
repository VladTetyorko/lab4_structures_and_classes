namespace Task2.SocialNetwork.ConsoleUi.Views;

using Exceptions;
using Formatting;
using Posts;
using Users;

internal sealed class SocialNetworkConsoleView : ISocialNetworkView
{
    private const string WelcomeMessage = "Welcome to the social network!";
    private const string GoodbyeMessage = "Goodbye!";
    private const string SignInPrompt = "Sign in with your nickname: ";
    private const string SignedInPrefix = "You are signed in as ";
    private const string AuthorNicknamePrompt = "Whose posts do you want to see? Nickname: ";
    private const string PostIdPrompt = "Post id: ";
    private const string PostTextPrompt = "Post text: ";
    private const string CommentTextPrompt = "Comment text: ";
    private const string PostDeletedMessage = "The post has been deleted.";
    private const string MenuChoicePrompt = "Your choice: ";
    private const string MenuHeader = "";
    private const string OptionSeparator = " - ";
    private const string ExitTitle = "Exit";
    private const string EmptyText = "";
    private const int MinPostId = 1;

    private readonly ConsoleTerminal _terminal;

    public SocialNetworkConsoleView(ConsoleTerminal terminal)
    {
        _terminal = terminal;
    }

    public void ShowWelcome() => _terminal.WriteLine(WelcomeMessage);

    public void ShowGoodbye() => _terminal.WriteLine(GoodbyeMessage);

    public void ShowUsers(IReadOnlyList<UserProfile> users) => _terminal.WriteLine(UserFormatter.FormatMany(users));

    public string? AskNicknameToSignIn() => _terminal.ReadText(SignInPrompt);

    public void ShowSignedIn(UserProfile user) => _terminal.WriteLine(SignedInPrefix + user.Nickname);

    public string AskAuthorNickname() => ReadTextOrEmpty(AuthorNicknamePrompt);

    public int? AskPostId() => _terminal.ReadNumber(PostIdPrompt, MinPostId, int.MaxValue);

    public string AskPostText() => ReadTextOrEmpty(PostTextPrompt);

    public string AskCommentText() => ReadTextOrEmpty(CommentTextPrompt);

    public void ShowPost(PostView post) => _terminal.WriteLine(PostFormatter.Format(post));

    public void ShowPosts(IReadOnlyList<PostView> posts) => _terminal.WriteLine(PostFormatter.FormatMany(posts));

    public void ShowPostDeleted() => _terminal.WriteLine(PostDeletedMessage);

    public void ShowError(SocialNetworkException error) => _terminal.WriteLine(error.Message);

    public void ShowMenuHeader() => _terminal.WriteLine(MenuHeader);

    public void ShowMenuOption(int number, string title) => _terminal.WriteLine(number + OptionSeparator + title);

    public void ShowExitOption(int number) => ShowMenuOption(number, ExitTitle);

    public int? AskMenuChoice(int minimum, int maximum) => _terminal.ReadNumber(MenuChoicePrompt, minimum, maximum);

    private string ReadTextOrEmpty(string prompt) => _terminal.ReadText(prompt) ?? EmptyText;
}
