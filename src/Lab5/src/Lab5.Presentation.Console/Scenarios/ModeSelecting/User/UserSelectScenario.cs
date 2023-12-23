using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ModeSelecting.User;

public class UserSelectScenario : IScenario
{
    private readonly IUserService _userService;

    public UserSelectScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Enter user mode";

    public void Run()
    {
        _userService.EnterUserMode();

        AnsiConsole.WriteLine("Successfully entered user mode\n--------\n");
    }
}