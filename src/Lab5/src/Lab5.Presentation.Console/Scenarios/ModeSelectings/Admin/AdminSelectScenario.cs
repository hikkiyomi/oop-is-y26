using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ModeSelectings.Admin;

public class AdminSelectScenario : IScenario
{
    private readonly IUserService _userService;

    public AdminSelectScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Enter admin mode";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter admin password: ");

        _userService.EnterAdminMode(password);

        AnsiConsole.WriteLine("Successfully entered admin mode\n--------\n");
    }
}