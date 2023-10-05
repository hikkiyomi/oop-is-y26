using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public class ThirdClassDeflector : IDeflector
{
    private const int DefaultHealth = 1000;

    private ThirdClassDeflector(int health, int modificationHealth)
    {
        Health = new HealthPoints(health);
        ModificationHealth = new HealthPoints(modificationHealth);
    }

    public HealthPoints Health { get; }
    public HealthPoints ModificationHealth { get; }

    public IDeflector Create(int modificationHealth)
    {
        return new ThirdClassDeflector(DefaultHealth, modificationHealth);
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}