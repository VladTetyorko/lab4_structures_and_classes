namespace Task2.SocialNetwork.Time;

internal sealed class SystemClock : IClock
{
    public DateTime Now => DateTime.Now;
}
