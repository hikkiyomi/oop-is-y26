using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NebulaNeutrinoParticles : IEnvironment
{
    public NebulaNeutrinoParticles(IReadOnlyCollection<IObstacle> obstacles)
    {
        Obstacles = obstacles;
        EngineRestriction = EngineType.Impulse;
    }

    public EngineType EngineRestriction { get; }
    public IReadOnlyCollection<IObstacle> Obstacles { get; }
}