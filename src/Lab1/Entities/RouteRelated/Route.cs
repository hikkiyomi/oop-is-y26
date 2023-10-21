using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.RouteRelated;

public class Route : ITraversable
{
    private readonly IReadOnlyCollection<IRouteSegment> _segments;

    public Route(IReadOnlyCollection<IRouteSegment> segments)
    {
        _segments = segments;
    }

    public TravelResult Traverse(ITravelSuitable transport)
    {
        int timeSpent = 0;
        int moneySpent = 0;

        foreach (IRouteSegment segment in _segments)
        {
            TravelResult result = segment.Traverse(transport);

            if (result is TravelResult.Success successfulResult)
            {
                timeSpent += successfulResult.TimeSpent;
                moneySpent += successfulResult.MoneySpent;
            }
            else
            {
                return result;
            }
        }

        return new TravelResult.Success(timeSpent, moneySpent);
    }
}