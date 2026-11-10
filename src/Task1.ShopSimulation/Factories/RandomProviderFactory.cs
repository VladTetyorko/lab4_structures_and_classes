namespace Task1.ShopSimulation.Factories;

using Randomization;

public static class RandomProviderFactory
{
    public static IRandomProvider CreateSystem()
    {
        return new SystemRandomProvider(new Random());
    }

    public static IRandomProvider CreateSeeded(int seed)
    {
        return new SystemRandomProvider(new Random(seed));
    }
}
