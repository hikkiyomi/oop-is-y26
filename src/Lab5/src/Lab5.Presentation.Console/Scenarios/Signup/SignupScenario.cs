using Lab5.Application.Contracts.Exceptions;
using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Signup;

public class SignupScenario : IScenario
{
    private readonly IUserService _userService;

    public SignupScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Sign up";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter username: ");
        string adminPassword = AnsiConsole.Ask<string>("Enter admin mode password: ");

        SignupResult result = _userService.Signup(username, adminPassword);

        string message = result switch
        {
            SignupResult.Success => "Successfully signed up",
            SignupResult.Failure => "Could not sign up",
            _ => throw new SignupException("Unexpected sign up result"),
        };

        AnsiConsole.WriteLine($"{message}\n--------\n");
    }
}