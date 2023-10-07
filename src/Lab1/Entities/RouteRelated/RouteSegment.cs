using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.RouteRelated;

public class RouteSegment : IRouteSegment
{
    public RouteSegment(int distance, IEnvironment environment)
    {
        Distance = distance;
        Environment = environment;
    }

    public int Distance { get; }
    public IEnvironment Environment { get; }

    public TravelResult Traverse(ITravelSuitable transport)
    {
        return transport.Travel(this);
    }
}