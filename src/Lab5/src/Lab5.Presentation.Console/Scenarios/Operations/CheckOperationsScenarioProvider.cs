using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models;

namespace Lab5.Presentation.Console.Scenarios.Operations;

public class CheckOperationsScenarioProvider : IScenarioProvider
{
    private readonly IUserHandler _userHandler;
    private readonly IUserService _userService;
    private readonly IAccountHandler _accountHandler;

    public CheckOperationsScenarioProvider(
        IUserHandler userHandler,
        IUserService userService,
        IAccountHandler accountHandler)
    {
        _userHandler = userHandler;
        _userService = userService;
        _accountHandler = accountHandler;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_userHandler.User is null
            || _accountHandler.Account is null
            || !_userHandler.User.Mode.Equals(Mode.Admin))
        {
            scenario = null;

            return false;
        }

        scenario = new CheckOperationsScenario(_userService);

        return true;
    }
}