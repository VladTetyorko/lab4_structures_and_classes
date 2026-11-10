namespace Task1.ShopSimulation.Simulation;

public sealed class SimulationResult
{
    internal SimulationResult(int purchaseCount, int rejectionCount)
    {
        PurchaseCount = purchaseCount;
        RejectionCount = rejectionCount;
    }

    public int PurchaseCount { get; }

    public int RejectionCount { get; }
}
