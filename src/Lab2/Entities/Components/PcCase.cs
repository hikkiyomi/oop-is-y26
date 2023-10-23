using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class PcCase
    : IComponent,
    IPrototype<PcCase>,
    ISized
{
    private readonly IList<FormFactor> _supportedFormFactors;

    public PcCase(
        Dimensions size,
        Dimensions maxGpuSize,
        Dimensions maxCoolingSize,
        IEnumerable<FormFactor> supportedFormFactors)
    {
        Size = size;
        MaxGpuSize = maxGpuSize;
        MaxCoolingSize = maxCoolingSize;
        _supportedFormFactors = supportedFormFactors.ToList();
    }

    public Dimensions Size { get; }
    public Dimensions MaxGpuSize { get; }
    public Dimensions MaxCoolingSize { get; }

    public IReadOnlyCollection<FormFactor> SupportedFormFactors
        => _supportedFormFactors.AsReadOnly();

    public PcCase Clone()
    {
        return new PcCase(
            Size,
            MaxGpuSize,
            MaxCoolingSize,
            _supportedFormFactors);
    }

    IComponent IPrototype<IComponent>.Clone()
    {
        return Clone();
    }

    public bool Equals(PcCase other)
    {
        return Size == other.Size
               && MaxGpuSize == other.MaxGpuSize
               && MaxCoolingSize == other.MaxCoolingSize
               && _supportedFormFactors.SequenceEqual(other._supportedFormFactors);
    }
}