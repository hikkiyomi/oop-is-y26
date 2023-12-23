using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.BankAccount.CheckBalance;

public class CheckBalanceScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CheckBalanceScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Check balance";

    public void Run()
    {
        int balance = _accountService.GetBalance();

        AnsiConsole.WriteLine($"Current account balance: {balance}\n--------\n");
    }
}