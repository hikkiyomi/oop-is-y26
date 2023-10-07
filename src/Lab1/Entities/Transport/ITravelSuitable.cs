using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.RouteRelated;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

public interface ITravelSuitable
{
    TravelResult Travel(IRouteSegment segment);
}