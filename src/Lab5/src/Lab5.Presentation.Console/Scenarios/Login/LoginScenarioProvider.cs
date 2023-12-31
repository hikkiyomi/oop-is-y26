using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class LoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly IUserHandler _userHandler;

    public LoginScenarioProvider(IUserService userService, IUserHandler userHandler)
    {
        _userService = userService;
        _userHandler = userHandler;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_userHandler.User is not null)
        {
            scenario = null;

            return false;
        }

        scenario = new LoginScenario(_userService);

        return true;
    }
}