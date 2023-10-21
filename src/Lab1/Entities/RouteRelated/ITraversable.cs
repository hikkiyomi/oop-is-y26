using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.RouteRelated;

public interface ITraversable
{
    TravelResult Traverse(ITravelSuitable transport);
}