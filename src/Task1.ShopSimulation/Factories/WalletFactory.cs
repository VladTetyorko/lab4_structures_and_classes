namespace Task1.ShopSimulation.Factories;

using Finance;

internal static class WalletFactory
{
    public static IWallet Create(decimal initialBalance)
    {
        return new Wallet(initialBalance);
    }
}
