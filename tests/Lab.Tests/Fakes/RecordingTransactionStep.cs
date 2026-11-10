using Task1.ShopSimulation.Transactions;

namespace Lab.Tests.Fakes;

internal sealed class RecordingTransactionStep : ITransactionStep
{
    private const string ExecuteSuffix = ":execute";
    private const string RollbackSuffix = ":rollback";

    private readonly string _name;
    private readonly List<string> _journal;
    private readonly bool _failsOnExecute;

    public RecordingTransactionStep(string name, List<string> journal, bool failsOnExecute)
    {
        _name = name;
        _journal = journal;
        _failsOnExecute = failsOnExecute;
    }

    public void Execute()
    {
        if (_failsOnExecute)
        {
            throw new InvalidOperationException(_name);
        }

        _journal.Add(_name + ExecuteSuffix);
    }

    public void Rollback()
    {
        _journal.Add(_name + RollbackSuffix);
    }
}
