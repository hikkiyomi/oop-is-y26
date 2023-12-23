using Lab5.Presentation.Console.Scenarios.BankAccount.CheckBalance;
using Lab5.Presentation.Console.Scenarios.BankAccount.CreateAccount;
using Lab5.Presentation.Console.Scenarios.BankAccount.Deposit;
using Lab5.Presentation.Console.Scenarios.BankAccount.Login;
using Lab5.Presentation.Console.Scenarios.BankAccount.Logout;
using Lab5.Presentation.Console.Scenarios.BankAccount.Withdraw;
using Lab5.Presentation.Console.Scenarios.Login;
using Lab5.Presentation.Console.Scenarios.Logout;
using Lab5.Presentation.Console.Scenarios.ModeSelecting.Admin;
using Lab5.Presentation.Console.Scenarios.ModeSelecting.User;
using Lab5.Presentation.Console.Scenarios.Operations;
using Lab5.Presentation.Console.Scenarios.Signup;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AccountLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AccountLogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawScenarioProvider>();

        collection.AddScoped<IScenarioProvider, SignupScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutScenarioProvider>();

        collection.AddScoped<IScenarioProvider, AdminSelectScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UserSelectScenarioProvider>();

        collection.AddScoped<IScenarioProvider, CheckOperationsScenarioProvider>();

        return collection;
    }
}