namespace Task1.ShopSimulation.Transactions;

internal sealed class Transaction
{
    private readonly IReadOnlyList<ITransactionStep> _steps;

    public Transaction(IReadOnlyList<ITransactionStep> steps)
    {
        _steps = steps;
    }

    public void Commit()
    {
        Stack<ITransactionStep> completedSteps = new Stack<ITransactionStep>();

        try
        {
            foreach (ITransactionStep step in _steps)
            {
                step.Execute();
                completedSteps.Push(step);
            }
        }
        catch
        {
            RollbackAll(completedSteps);
            throw;
        }
    }

    private static void RollbackAll(Stack<ITransactionStep> completedSteps)
    {
        while (completedSteps.Count > 0)
        {
            completedSteps.Pop().Rollback();
        }
    }
}
