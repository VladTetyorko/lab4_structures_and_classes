namespace Task1.ShopSimulation.Finance;

internal interface IWallet
{
    decimal Balance { get; }

    bool CanAfford(decimal amount);

    void Withdraw(decimal amount);

    void Deposit(decimal amount);
}
