using Task2.SocialNetwork.Time;

namespace Lab.Tests.Fakes;

public sealed class ManualClock : IClock
{
    public ManualClock(DateTime start)
    {
        Now = start;
    }

    public DateTime Now { get; private set; }

    public void AdvanceMinutes(int minutes)
    {
        Now = Now.AddMinutes(minutes);
    }
}
