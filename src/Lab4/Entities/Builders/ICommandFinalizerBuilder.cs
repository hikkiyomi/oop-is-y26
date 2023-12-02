using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

public interface ICommandFinalizerBuilder
{
    CommandContext Build();
}