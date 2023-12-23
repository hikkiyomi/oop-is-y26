using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.ModeSelectings.Admin;

public class AdminSelectScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly IUserHandler _userHandler;

    public AdminSelectScenarioProvider(IUserService userService, IUserHandler userHandler)
    {
        _userService = userService;
        _userHandler = userHandler;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_userHandler.User is null || _userHandler.User.Mode is not null)
        {
            scenario = null;

            return false;
        }

        scenario = new AdminSelectScenario(_userService);

        return true;
    }
}