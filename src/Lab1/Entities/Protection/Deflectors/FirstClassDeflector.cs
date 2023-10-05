using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public class FirstClassDeflector : IDeflector
{
    private const int DefaultHealth = 1000;

    private FirstClassDeflector(int health, int modificationHealth)
    {
        Health = new HealthPoints(health);
        ModificationHealth = new HealthPoints(modificationHealth);
    }

    public HealthPoints Health { get; }
    public HealthPoints ModificationHealth { get; }

    public IDeflector Create(int modificationHealth)
    {
        return new FirstClassDeflector(DefaultHealth, modificationHealth);
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}