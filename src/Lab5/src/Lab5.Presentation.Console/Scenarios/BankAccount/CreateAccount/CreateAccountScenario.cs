using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Exceptions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.BankAccount.CreateAccount;

public class CreateAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CreateAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Create balance";

    public void Run()
    {
        string number = AnsiConsole.Ask<string>("Enter account number: ");
        string pin = AnsiConsole.Ask<string>("Enter PIN: ");

        CreateAccountResult result = _accountService.CreateAccount(number, pin);

        string message = result switch
        {
            CreateAccountResult.Success => "Successfully created new account",
            CreateAccountResult.Failure => "Could not create new account",
            _ => throw new AccountException("Unexpected account result"),
        };

        AnsiConsole.WriteLine($"{message}\n--------\n");
        AnsiConsole.Ask<string>("Ok");
    }
}