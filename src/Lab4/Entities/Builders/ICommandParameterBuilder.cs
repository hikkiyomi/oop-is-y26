using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

public interface ICommandParameterBuilder
{
    ICommandParameterBuilder AddParameter(string shortName, string fullName);
    ICommandParameterBuilder AddParameter(string fullName);
    ICommandFinalizerBuilder SetAction(Action<object[]> action);
}