namespace Task2.SocialNetwork.Data;

using Application;
using Factories;
using Posts;
using Users;

internal static class SeedData
{
    private const int SeedYear = 2026;
    private const int SeedMonth = 10;
    private const int SeedMinute = 0;

    private static readonly (string Author, string Text, int Day, int Hour)[] Posts =
    {
        ("@olena", "Good morning! Starting a new week with a cup of coffee.", 1, 8),
        ("@olena", "Finished reading \"Clean Code\". Highly recommend it.", 3, 21),
        ("@taras", "Our team won the football match yesterday!", 4, 10),
        ("@olena", "Who wants to join a weekend hike in the Carpathians?", 6, 12),
        ("@iryna_b", "Just published my first open-source library.", 7, 16),
        ("@olena", "Tried a new borscht recipe, it was amazing.", 9, 19),
        ("@taras", "Looking for a good book about software architecture.", 11, 9),
        ("@olena", "Kyiv looks beautiful in autumn.", 13, 17),
        ("@olena", "Learning C# structs and classes today.", 15, 11),
        ("@iryna_b", "Conference talk slides are ready, wish me luck!", 18, 14),
        ("@olena", "Weekend plans: board games and pizza.", 20, 20)
    };

    private static readonly (int PostIndex, string Liker)[] Likes =
    {
        (0, "@taras"), (0, "@iryna_b"), (2, "@olena"), (4, "@olena"),
        (4, "@max_l"), (7, "@taras"), (9, "@olena"), (10, "@max_l")
    };

    private static readonly (int PostIndex, string Author, string Text, int Day, int Hour)[] Comments =
    {
        (0, "@taras", "Coffee is the best way to start a day!", 1, 9),
        (3, "@max_l", "Count me in!", 6, 13),
        (4, "@olena", "Congratulations, sharing it with my team.", 7, 18),
        (6, "@iryna_b", "Try \"Fundamentals of Software Architecture\".", 11, 12)
    };

    public static IReadOnlyList<UserProfile> CreateUsers()
    {
        return new[]
        {
            UserProfileFactory.Create("Olena Kovalenko", "olena.kovalenko@example.com", "@olena"),
            UserProfileFactory.Create("Taras Shevchuk", "taras.shevchuk@example.com", "@taras"),
            UserProfileFactory.Create("Iryna Bondar", "iryna.bondar@example.com", "@iryna_b"),
            UserProfileFactory.Create("Maksym Lysenko", "maksym.lysenko@example.com", "@max_l")
        };
    }

    public static void PublishPosts(IUserDirectory users, IPostService posts)
    {
        PostView[] published = Posts
            .Select(post => posts.Publish(users.Find(post.Author), post.Text, At(post.Day, post.Hour)))
            .ToArray();

        foreach ((int postIndex, string liker) in Likes)
        {
            posts.Like(users.Find(liker), published[postIndex].Id);
        }

        foreach ((int postIndex, string author, string text, int day, int hour) in Comments)
        {
            posts.Comment(users.Find(author), published[postIndex].Id, text, At(day, hour));
        }
    }

    private static DateTime At(int day, int hour)
    {
        return new DateTime(SeedYear, SeedMonth, day, hour, SeedMinute, SeedMinute);
    }
}
