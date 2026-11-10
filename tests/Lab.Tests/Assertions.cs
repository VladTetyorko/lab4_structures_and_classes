using System.Globalization;

namespace Lab.Tests;

public static class Assertions
{
    private const string ExpectedLabel = "expected \"";
    private const string ActualLabel = "\" but was \"";
    private const string ClosingLabel = "\"";
    private const string TrueConditionLabel = "expected true: ";
    private const string FalseConditionLabel = "expected false: ";
    private const string ThrowsLabel = "expected exception ";
    private const string NothingThrownLabel = " but nothing was thrown: ";

    public static void AreEqual(string expected, string actual)
    {
        if (expected != actual)
        {
            throw new AssertionException(ExpectedLabel + expected + ActualLabel + actual + ClosingLabel);
        }
    }

    public static void AreEqual(int expected, int actual)
    {
        AreEqual(expected.ToString(CultureInfo.InvariantCulture), actual.ToString(CultureInfo.InvariantCulture));
    }

    public static void AreEqual(decimal expected, decimal actual)
    {
        AreEqual(expected.ToString(CultureInfo.InvariantCulture), actual.ToString(CultureInfo.InvariantCulture));
    }

    public static void IsTrue(bool condition, string description)
    {
        if (!condition)
        {
            throw new AssertionException(TrueConditionLabel + description);
        }
    }

    public static void IsFalse(bool condition, string description)
    {
        if (condition)
        {
            throw new AssertionException(FalseConditionLabel + description);
        }
    }

    public static TException Throws<TException>(Action action, string description) where TException : Exception
    {
        try
        {
            action();
        }
        catch (TException exception)
        {
            return exception;
        }

        throw new AssertionException(ThrowsLabel + typeof(TException).Name + NothingThrownLabel + description);
    }
}
