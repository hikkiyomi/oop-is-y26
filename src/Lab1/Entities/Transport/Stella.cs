using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineRelated.EngineCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Transport;

public class Stella : Spaceship
{
    public Stella(DeflectorModification? deflectorModification)
        : base(
            new[]
            {
                new Engine(
                    new ConstantConsume(),
                    new Fuel(10),
                    EngineType.Impulse),
                new Engine(
                    new LogarithmicConsume(),
                    new Fuel(10),
                    EngineType.Jump),
            },
            new DeflectorClass1(deflectorModification),
            new ArmorClass1())
    {
    }
}