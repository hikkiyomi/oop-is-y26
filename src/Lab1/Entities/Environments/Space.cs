using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class Space : IEnvironment
{
    public Space(EngineType engineRestriction, IReadOnlyCollection<IObstacle> obstacles)
    {
        EngineRestriction = engineRestriction;
        Obstacles = obstacles;
    }

    public EngineType EngineRestriction { get; }
    public IReadOnlyCollection<IObstacle> Obstacles { get; }
}