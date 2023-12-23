using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models;

namespace Lab5.Presentation.Console.Scenarios.BankAccount.CreateAccount;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly IUserHandler _userHandler;
    private readonly IAccountService _accountService;
    private readonly IAccountHandler _accountHandler;

    public CreateAccountScenarioProvider(
        IUserHandler userHandler,
        IAccountService accountService,
        IAccountHandler accountHandler)
    {
        _userHandler = userHandler;
        _accountService = accountService;
        _accountHandler = accountHandler;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_userHandler.User is null
            || _userHandler.User.Mode.Equals(Mode.User)
            || _accountHandler.Account is not null)
        {
            scenario = null;

            return false;
        }

        scenario = new CreateAccountScenario(_accountService);

        return true;
    }
}