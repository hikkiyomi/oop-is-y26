using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface IBreakable : IHittable
{
    HealthPoints Health { get; }
    bool IsBroken { get; }
}