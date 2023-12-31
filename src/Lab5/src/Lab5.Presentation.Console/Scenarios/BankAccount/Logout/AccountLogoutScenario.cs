using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.BankAccount.Logout;

public class AccountLogoutScenario : IScenario
{
    private readonly IAccountService _accountService;

    public AccountLogoutScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Log out from an account";

    public void Run()
    {
        _accountService.Logout();

        AnsiConsole.WriteLine("Successfully logged out\n--------\n");
        AnsiConsole.Ask<string>("Ok");
    }
}