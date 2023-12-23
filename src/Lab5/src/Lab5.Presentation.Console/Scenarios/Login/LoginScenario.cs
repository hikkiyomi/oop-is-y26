using Lab5.Application.Contracts.Exceptions;
using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Log in";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter username: ");
        LoginResult result = _userService.Login(username);

        string message = result switch
        {
            LoginResult.Success => "Successfully logged in",
            LoginResult.Failure => "Could not log in",
            _ => throw new LoginException("Unexpected log in result"),
        };

        AnsiConsole.WriteLine($"{message}\n--------\n");
    }
}