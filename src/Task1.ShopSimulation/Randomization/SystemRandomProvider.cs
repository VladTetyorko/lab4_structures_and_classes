namespace Task1.ShopSimulation.Randomization;

internal sealed class SystemRandomProvider : IRandomProvider
{
    private readonly Random _random;

    public SystemRandomProvider(Random random)
    {
        _random = random;
    }

    public int Next(int minInclusive, int maxExclusive) => _random.Next(minInclusive, maxExclusive);
}
