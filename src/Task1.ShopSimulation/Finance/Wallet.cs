namespace Task1.ShopSimulation.Finance;

using Exceptions;

internal sealed class Wallet : IWallet
{
    private const decimal ZeroAmount = 0m;

    private decimal _balance;

    public Wallet(decimal initialBalance)
    {
        _balance = initialBalance;
    }

    public decimal Balance => _balance;

    public bool CanAfford(decimal amount) => amount <= _balance;

    public void Withdraw(decimal amount)
    {
        RequirePositive(amount);

        if (!CanAfford(amount))
        {
            throw ShopExceptionFactory.InsufficientFunds(amount, _balance);
        }

        _balance -= amount;
    }

    public void Deposit(decimal amount)
    {
        RequirePositive(amount);
        _balance += amount;
    }

    private static void RequirePositive(decimal amount)
    {
        if (amount <= ZeroAmount)
        {
            throw ShopExceptionFactory.NonPositiveAmount(amount);
        }
    }
}
