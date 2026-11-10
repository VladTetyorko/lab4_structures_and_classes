namespace Task1.ShopSimulation.Finance;

using Reporting;

internal interface ICashRegister : IReportable
{
    decimal Profit { get; }

    int SalesCount { get; }

    void Register(Receipt receipt);

    void Cancel(Receipt receipt);
}
