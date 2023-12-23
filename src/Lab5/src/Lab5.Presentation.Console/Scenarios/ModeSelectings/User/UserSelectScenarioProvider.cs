using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models;

namespace Lab5.Presentation.Console.Scenarios.ModeSelectings.User;

public class UserSelectScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly IUserHandler _userHandler;

    public UserSelectScenarioProvider(
        IUserService userService,
        IUserHandler userHandler)
    {
        _userService = userService;
        _userHandler = userHandler;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_userHandler.User is null || _userHandler.User.Mode == Mode.User)
        {
            scenario = null;

            return false;
        }

        scenario = new UserSelectScenario(_userService);

        return true;
    }
}