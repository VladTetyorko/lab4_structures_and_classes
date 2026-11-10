using Task1.ShopSimulation.Randomization;

namespace Lab.Tests.Fakes;

public sealed class BoundaryRandomProvider : IRandomProvider
{
    private const int ExclusiveOffset = 1;

    private readonly bool _returnsMaximum;

    public BoundaryRandomProvider(bool returnsMaximum)
    {
        _returnsMaximum = returnsMaximum;
    }

    public int Next(int minInclusive, int maxExclusive)
    {
        return _returnsMaximum ? maxExclusive - ExclusiveOffset : minInclusive;
    }
}
