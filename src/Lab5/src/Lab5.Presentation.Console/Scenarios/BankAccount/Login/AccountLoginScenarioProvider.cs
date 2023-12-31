using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models;

namespace Lab5.Presentation.Console.Scenarios.BankAccount.Login;

public class AccountLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserHandler _userHandler;
    private readonly IAccountHandler _accountHandler;
    private readonly IAccountService _accountService;

    public AccountLoginScenarioProvider(
        IUserHandler userHandler,
        IAccountHandler accountHandler,
        IAccountService accountService)
    {
        _userHandler = userHandler;
        _accountHandler = accountHandler;
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_userHandler.User is null
            || _accountHandler.Account is not null
            || !_userHandler.User.Mode.Equals(Mode.User))
        {
            scenario = null;

            return false;
        }

        scenario = new AccountLoginScenario(_accountService);

        return true;
    }
}