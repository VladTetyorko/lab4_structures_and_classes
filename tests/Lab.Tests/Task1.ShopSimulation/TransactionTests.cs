using Lab.Tests.Fakes;
using Task1.ShopSimulation.Factories;
using Task1.ShopSimulation.Transactions;

namespace Lab.Tests.Task1.ShopSimulation;

public sealed class TransactionTests
{
    public void ShouldExecuteEveryStepInOrder()
    {
        List<string> journal = new List<string>();
        Transaction transaction = TransactionFactory.Create(new ITransactionStep[]
        {
            new RecordingTransactionStep("first", journal, false),
            new RecordingTransactionStep("second", journal, false)
        });

        transaction.Commit();

        Assertions.AreEqual("first:execute,second:execute", string.Join(",", journal));
    }

    public void ShouldRollbackCompletedStepsInReverseOrderWhenStepFails()
    {
        List<string> journal = new List<string>();
        Transaction transaction = TransactionFactory.Create(new ITransactionStep[]
        {
            new RecordingTransactionStep("first", journal, false),
            new RecordingTransactionStep("second", journal, false),
            new RecordingTransactionStep("third", journal, true)
        });

        Assertions.Throws<InvalidOperationException>(transaction.Commit, "the failing step error is rethrown");
        Assertions.AreEqual("first:execute,second:execute,second:rollback,first:rollback", string.Join(",", journal));
    }
}
