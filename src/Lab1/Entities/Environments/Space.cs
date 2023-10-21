using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class Space : IEnvironment
{
    public Space(IReadOnlyCollection<IObstacle> obstacles)
    {
        Obstacles = obstacles;
        EngineRestriction = EngineType.Impulse;
    }

    public EngineType EngineRestriction { get; }
    public IReadOnlyCollection<IObstacle> Obstacles { get; }
}