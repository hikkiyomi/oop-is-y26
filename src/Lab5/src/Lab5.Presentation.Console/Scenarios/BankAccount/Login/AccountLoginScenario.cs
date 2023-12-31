using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Exceptions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.BankAccount.Login;

public class AccountLoginScenario : IScenario
{
    private readonly IAccountService _accountService;

    public AccountLoginScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Log into account";

    public void Run()
    {
        string number = AnsiConsole.Ask<string>("Enter card number: ");
        string pin = AnsiConsole.Ask<string>("Enter PIN: ");

        AccountLoginResult result = _accountService.Login(number, pin);

        string message = result switch
        {
            AccountLoginResult.Success => "Successfully logged into account",
            AccountLoginResult.Failure => "Could not log into account",
            _ => throw new LoginException("Unexpected result"),
        };

        AnsiConsole.WriteLine($"{message}\n--------\n");
        AnsiConsole.Ask<string>("Ok");
    }
}