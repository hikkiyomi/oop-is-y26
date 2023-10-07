using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NebulaIncreasedDensity : IEnvironment
{
    public NebulaIncreasedDensity(IReadOnlyCollection<IObstacle> obstacles)
    {
        Obstacles = obstacles;
        EngineRestriction = EngineType.Jump;
    }

    public EngineType EngineRestriction { get; }
    public IReadOnlyCollection<IObstacle> Obstacles { get; }
}