using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Modifications;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.RouteRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Tests
{
    [Theory]
    [ClassData(typeof(FirstTestDataGenerator))]
    public void ShuttleAndAugurShouldBeLost(
        RouteSegment segment,
        Shuttle shuttle,
        Augur augur)
    {
        TravelResult resultShuttle = segment.Traverse(shuttle);
        TravelResult resultAugur = segment.Traverse(augur);

        Assert.IsType<TravelResult.LostInSpace>(resultShuttle);
        Assert.IsType<TravelResult.LostInSpace>(resultAugur);
    }

    [Theory]
    [ClassData(typeof(SecondTestDataGenerator))]
    public void WaklasCrewShouldBeDeadAndModifiedWaklasShouldBeGood(
        RouteSegment segment,
        Waklas shipWithoutPhotonDeflector,
        Waklas shipWithPhotonDeflector)
    {
        TravelResult resultFirst = segment.Traverse(shipWithoutPhotonDeflector);
        TravelResult resultSecond = segment.Traverse(shipWithPhotonDeflector);

        Assert.IsType<TravelResult.CrewDeath>(resultFirst);
        Assert.IsType<TravelResult.Success>(resultSecond);
    }

    [Theory]
    [ClassData(typeof(ThirdTestDataGenerator))]
    public void WaklasShouldBeDeadAugurShouldLoseShieldMeridianShouldBeOk(
        RouteSegment segment,
        Waklas waklas,
        Augur augur,
        Meridian meridian)
    {
        TravelResult resultWaklas = segment.Traverse(waklas);
        TravelResult resultAugur = segment.Traverse(augur);
        TravelResult resultMeridian = segment.Traverse(meridian);

        Assert.IsType<TravelResult.Destroyed>(resultWaklas);
        Assert.IsType<TravelResult.Success>(resultAugur);
        Assert.True(augur.Deflector?.IsBroken);
        Assert.IsType<TravelResult.Success>(resultMeridian);
        Assert.True(!meridian.Deflector?.IsBroken);
    }

    [Fact]
    public void ShuttleAndWaklasInSpaceShouldChooseShuttle()
    {
        var segment = new RouteSegment(
            20,
            new Space(System.Array.Empty<IObstacle>()));

        TravelResult resultShuttle = segment.Traverse(new Shuttle());
        TravelResult resultWaklas = segment.Traverse(new Waklas(null));

        Assert.IsType<TravelResult.Success>(resultShuttle);
        Assert.IsType<TravelResult.Success>(resultWaklas);

        int costShuttle = ((TravelResult.Success)resultShuttle).MoneySpent;
        int costWaklas = ((TravelResult.Success)resultWaklas).MoneySpent;

        Assert.True(costShuttle < costWaklas);
    }

    [Fact]
    public void AugurAndStellaInNebulaDensityShouldChooseStella()
    {
        var segment = new RouteSegment(
            50,
            new NebulaIncreasedDensity(System.Array.Empty<IObstacle>()));

        TravelResult resultAugur = segment.Traverse(new Augur(null));
        TravelResult resultStella = segment.Traverse(new Stella(null));

        Assert.IsType<TravelResult.LostInSpace>(resultAugur);
        Assert.IsType<TravelResult.Success>(resultStella);
    }

    [Fact]
    public void ShuttleAndWaklasInLongNebulaNeutrinoRoute()
    {
        var segment = new RouteSegment(
            1000,
            new NebulaNeutrinoParticles(System.Array.Empty<IObstacle>()));

        TravelResult resultShuttle = segment.Traverse(new Shuttle());
        TravelResult resultWaklas = segment.Traverse(new Waklas(null));

        Assert.IsType<TravelResult.Success>(resultShuttle);
        Assert.IsType<TravelResult.Success>(resultWaklas);

        int costShuttle = ((TravelResult.Success)resultShuttle).MoneySpent;
        int costWaklas = ((TravelResult.Success)resultWaklas).MoneySpent;

        Assert.True(costShuttle > costWaklas);
    }

    [Fact]
    public void StellaShouldBeDestroyedMeridianCrewShouldBeDeadWaklasShouldBeDestroyedAugurCrewShouldBeDead()
    {
        var route = new Route(new[]
        {
            new RouteSegment(
                10,
                new NebulaNeutrinoParticles(new[]
                {
                    new CosmoWhale(),
                })),
            new RouteSegment(
                100,
                new NebulaIncreasedDensity(new[]
                {
                    new AntiMatterBlast(),
                })),
            new RouteSegment(
                200,
                new NebulaIncreasedDensity(System.Array.Empty<IObstacle>())),
        });

        TravelResult resultStella = route.Traverse(new Stella(null));
        TravelResult resultMeridian = route.Traverse(new Meridian());
        TravelResult resultWaklas = route.Traverse(new Waklas(new PhotonDeflector()));
        TravelResult resultAugur = route.Traverse(new Augur(null));

        Assert.IsType<TravelResult.Destroyed>(resultStella);
        Assert.IsType<TravelResult.CrewDeath>(resultMeridian);
        Assert.IsType<TravelResult.Destroyed>(resultWaklas);
        Assert.IsType<TravelResult.CrewDeath>(resultAugur);
    }
}