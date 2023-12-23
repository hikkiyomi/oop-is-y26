using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models;

namespace Lab5.Presentation.Console.Scenarios.BankAccount.CheckBalance;

public class CheckBalanceScenarioProvider : IScenarioProvider
{
    private readonly IUserHandler _userHandler;
    private readonly IAccountHandler _accountHandler;
    private readonly IAccountService _accountService;

    public CheckBalanceScenarioProvider(IUserHandler userHandler, IAccountHandler accountHandler, IAccountService accountService)
    {
        _userHandler = userHandler;
        _accountHandler = accountHandler;
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_userHandler.User is null
            || _accountHandler.Account is null
            || !_userHandler.User.Mode.Equals(Mode.User))
        {
            scenario = null;

            return false;
        }

        scenario = new CheckBalanceScenario(_accountService);

        return true;
    }
}