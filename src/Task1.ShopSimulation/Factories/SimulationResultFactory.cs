namespace Task1.ShopSimulation.Factories;

using Simulation;

internal static class SimulationResultFactory
{
    public static SimulationResult Create(int purchaseCount, int rejectionCount)
    {
        return new SimulationResult(purchaseCount, rejectionCount);
    }
}
