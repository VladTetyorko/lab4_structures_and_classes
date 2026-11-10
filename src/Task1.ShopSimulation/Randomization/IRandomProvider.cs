namespace Task1.ShopSimulation.Randomization;

public interface IRandomProvider
{
    int Next(int minInclusive, int maxExclusive);
}
