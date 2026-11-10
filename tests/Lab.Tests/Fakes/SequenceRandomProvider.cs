using Task1.ShopSimulation.Randomization;

namespace Lab.Tests.Fakes;

public sealed class SequenceRandomProvider : IRandomProvider
{
    private readonly int[] _values;
    private int _position;

    public SequenceRandomProvider(params int[] values)
    {
        _values = values;
    }

    public int Next(int minInclusive, int maxExclusive)
    {
        int value = _values[_position % _values.Length];
        _position++;

        return value;
    }
}
