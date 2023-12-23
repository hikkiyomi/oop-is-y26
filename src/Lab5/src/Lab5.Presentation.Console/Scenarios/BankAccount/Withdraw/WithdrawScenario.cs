using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Exceptions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.BankAccount.Withdraw;

public class WithdrawScenario : IScenario
{
    private readonly IAccountService _accountService;

    public WithdrawScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Withdraw money";

    public void Run()
    {
        int withdraw = AnsiConsole.Ask<int>("How much to withdraw: ");
        WithdrawResult result = _accountService.Withdraw(withdraw);

        string message = result switch
        {
            WithdrawResult.Success => $"Successfully withdrawn {withdraw}",
            WithdrawResult.Failure => "An error occurred",
            _ => throw new AccountException("Unexpected result"),
        };

        AnsiConsole.WriteLine($"{message}\n--------\n");
    }
}