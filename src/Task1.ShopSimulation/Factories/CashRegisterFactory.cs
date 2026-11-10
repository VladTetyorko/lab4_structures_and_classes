namespace Task1.ShopSimulation.Factories;

using Finance;

internal static class CashRegisterFactory
{
    public static ICashRegister Create()
    {
        return new CashRegister();
    }
}
