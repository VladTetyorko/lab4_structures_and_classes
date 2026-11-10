using System.Reflection;

namespace Lab.Tests;

public sealed class TestRunner
{
    private const string TestMethodPrefix = "Should";
    private const string PassedMark = "PASS  ";
    private const string FailedMark = "FAIL  ";
    private const string MemberSeparator = ".";
    private const string ReasonSeparator = " -> ";
    private const string SummaryPrefix = "Passed: ";
    private const string SummaryMiddle = "   Failed: ";
    private const int FirstIndex = 0;
    private const int NoParameters = 0;

    private int _passedCount;
    private int _failedCount;

    public int FailureCount => _failedCount;

    public void Run(Type testClassType)
    {
        object? testInstance = Activator.CreateInstance(testClassType);

        if (testInstance == null)
        {
            return;
        }

        MethodInfo[] methods = testClassType.GetMethods(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        for (int index = FirstIndex; index < methods.Length; index++)
        {
            if (IsTestMethod(methods[index]))
            {
                RunSingle(testClassType, testInstance, methods[index]);
            }
        }
    }

    public void PrintSummary()
    {
        Console.WriteLine(SummaryPrefix + _passedCount + SummaryMiddle + _failedCount);
    }

    private void RunSingle(Type testClassType, object testInstance, MethodInfo method)
    {
        string testName = testClassType.Name + MemberSeparator + method.Name;

        try
        {
            method.Invoke(testInstance, null);
            _passedCount++;
            Console.WriteLine(PassedMark + testName);
        }
        catch (TargetInvocationException exception)
        {
            _failedCount++;
            Console.WriteLine(FailedMark + testName + ReasonSeparator + DescribeFailure(exception));
        }
    }

    private static bool IsTestMethod(MethodInfo method)
    {
        if (method.ReturnType != typeof(void))
        {
            return false;
        }

        if (method.GetParameters().Length != NoParameters)
        {
            return false;
        }

        return method.Name.Length >= TestMethodPrefix.Length
               && method.Name.Substring(FirstIndex, TestMethodPrefix.Length) == TestMethodPrefix;
    }

    private static string DescribeFailure(TargetInvocationException exception)
    {
        if (exception.InnerException == null)
        {
            return exception.Message;
        }

        return exception.InnerException.Message;
    }
}
