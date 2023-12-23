using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.Logout;

public class LogoutScenarioProvider : IScenarioProvider
{
    private readonly IUserHandler _userHandler;
    private readonly IUserService _userService;
    private readonly IAccountHandler _accountHandler;

    public LogoutScenarioProvider(
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
        if (_userHandler.User is null || _accountHandler.Account is not null)
        {
            scenario = null;

            return false;
        }

        scenario = new LogoutScenario(_userService);

        return true;
    }
}