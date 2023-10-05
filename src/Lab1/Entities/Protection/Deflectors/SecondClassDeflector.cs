using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public class SecondClassDeflector : IDeflector
{
    private const int DefaultHealth = 1000;

    private SecondClassDeflector(int health, int modificationHealth)
    {
        Health = new HealthPoints(health);
        ModificationHealth = new HealthPoints(modificationHealth);
    }

    public HealthPoints Health { get; }
    public HealthPoints ModificationHealth { get; }

    public IDeflector Create(int modificationHealth)
    {
        return new SecondClassDeflector(DefaultHealth, modificationHealth);
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}