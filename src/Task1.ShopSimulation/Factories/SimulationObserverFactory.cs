namespace Task1.ShopSimulation.Factories;

using ConsoleUi;
using ConsoleUi.Views;
using Simulation;

public static class SimulationObserverFactory
{
    public static ISimulationObserver CreateSilent()
    {
        return new SilentSimulationObserver();
    }

    internal static ISimulationObserver CreateConsole(IShopView view)
    {
        return new ConsoleSimulationObserver(view);
    }
}
