namespace Task2.SocialNetwork.Factories;

using Time;

public static class ClockFactory
{
    public static IClock CreateSystem()
    {
        return new SystemClock();
    }
}
