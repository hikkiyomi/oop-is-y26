using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.Logout;

public class LogoutScenarioProvider : IScenarioProvider
{
    private readonly IUserHandler _userHandler;
    private readonly IUserService _userService;

    public LogoutScenarioProvider(IUserHandler userHandler, IUserService userService)
    {
        _userHandler = userHandler;
        _userService = userService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_userHandler.User is null)
        {
            scenario = null;

            return false;
        }

        scenario = new LogoutScenario(_userService);

        return true;
    }
}