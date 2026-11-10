namespace Task1.ShopSimulation.Transactions;

internal interface ITransactionStep
{
    void Execute();

    void Rollback();
}
