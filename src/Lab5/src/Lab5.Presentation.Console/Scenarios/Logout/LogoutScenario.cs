using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Logout;

public class LogoutScenario : IScenario
{
    private readonly IUserService _userService;

    public LogoutScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Log out";

    public void Run()
    {
        _userService.Logout();

        AnsiConsole.WriteLine("Successfully logged out\n--------\n");
    }
}