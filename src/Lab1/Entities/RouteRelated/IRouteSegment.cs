using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.RouteRelated;

public interface IRouteSegment : ITraversable
{
    int Distance { get; }
    IEnvironment Environment { get; }
}