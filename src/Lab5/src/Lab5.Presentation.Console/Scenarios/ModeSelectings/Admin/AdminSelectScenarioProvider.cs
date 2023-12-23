using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.ModeSelectings.Admin;

public class AdminSelectScenarioProvider : IScenarioProvider
{
    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        throw new NotImplementedException();
    }
}