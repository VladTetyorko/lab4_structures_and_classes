namespace Task1.ShopSimulation.Transactions;

using Finance;

internal sealed class RegisterSaleStep : ITransactionStep
{
    private readonly ICashRegister _cashRegister;
    private readonly Receipt _receipt;

    public RegisterSaleStep(ICashRegister cashRegister, Receipt receipt)
    {
        _cashRegister = cashRegister;
        _receipt = receipt;
    }

    public void Execute() => _cashRegister.Register(_receipt);

    public void Rollback() => _cashRegister.Cancel(_receipt);
}
