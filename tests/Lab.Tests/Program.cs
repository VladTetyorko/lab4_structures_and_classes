using Lab.Tests;
using Lab.Tests.Task1.ShopSimulation;
using Lab.Tests.Task2.SocialNetwork;

const int NoFailures = 0;
const int FailureExitCode = 1;
const int SuccessExitCode = 0;

TestRunner testRunner = new TestRunner();

testRunner.Run(typeof(ProductCatalogTests));
testRunner.Run(typeof(WarehouseTests));
testRunner.Run(typeof(CashRegisterTests));
testRunner.Run(typeof(PersonNameTests));
testRunner.Run(typeof(CustomerTests));
testRunner.Run(typeof(TransactionTests));
testRunner.Run(typeof(ShopTests));
testRunner.Run(typeof(ShoppingSimulationTests));
testRunner.Run(typeof(CustomerRankingTests));
testRunner.Run(typeof(ShopConsoleApplicationTests));
testRunner.Run(typeof(UserProfileTests));
testRunner.Run(typeof(PostManagementTests));
testRunner.Run(typeof(PostReactionTests));
testRunner.Run(typeof(SeedDataTests));
testRunner.Run(typeof(SocialNetworkConsoleApplicationTests));
testRunner.PrintSummary();

if (testRunner.FailureCount > NoFailures)
{
    return FailureExitCode;
}

return SuccessExitCode;
