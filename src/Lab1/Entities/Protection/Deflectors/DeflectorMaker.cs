using System;
using Itmo.ObjectOrientedProgramming.Lab1.Common.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protection.Deflectors;

public static class DeflectorMaker
{
    private const int MinModificationHealth = 0;
    private const int MaxModificationHealth = 3;

    public static IDeflector Create<T>(DeflectorModification modification)
        where T : class, IDeflector, new()
    {
        return modification switch
        {
            DeflectorModification.WithModification => new T().Create(MaxModificationHealth),
            DeflectorModification.WithoutModification => new T().Create(MinModificationHealth),
            _ => throw new DeflectorException(
                nameof(modification),
                new ArgumentException(
                    "Trying to install unknown modification on deflector.")),
        };
    }
}