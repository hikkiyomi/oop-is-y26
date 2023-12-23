using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Operations;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Operations;

public class CheckOperationsScenario : IScenario
{
    private readonly IUserService _userService;

    public CheckOperationsScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Check operation history";

    public void Run()
    {
        IReadOnlyCollection<Operation> result = _userService.FetchOperationHistory();

        foreach (Operation item in result)
        {
            AnsiConsole.WriteLine(
                $"{item.Username} | {item.Activity} | {item.Account}\n");
        }

        AnsiConsole.WriteLine("--------\n");
        AnsiConsole.Ask<string>("Ok");
    }
}