using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Exceptions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.BankAccount.Deposit;

public class DepositScenario : IScenario
{
    private readonly IAccountService _accountService;

    public DepositScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Deposit money";

    public void Run()
    {
        int deposit = AnsiConsole.Ask<int>("How much to deposit: ");
        DepositResult result = _accountService.Deposit(deposit);

        string message = result switch
        {
            DepositResult.Success => $"Successfully deposited {deposit}",
            DepositResult.Failure => "An error occurred",
            _ => throw new AccountException("Unexpected result"),
        };

        AnsiConsole.WriteLine($"{message}\n--------\n");
        AnsiConsole.Ask<string>("Ok");
    }
}