using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Attributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public class PcCase
    : IComponent,
    IPrototype<PcCase>,
    ISized
{
    private readonly IList<IFormFactor> _supportedFormFactors;

    public PcCase(
        Dimensions size,
        Dimensions maxGpuSize,
        Dimensions maxCoolingSize,
        IEnumerable<IFormFactor> supportedFormFactors)
    {
        Size = size;
        MaxGpuSize = maxGpuSize;
        MaxCoolingSize = maxCoolingSize;
        _supportedFormFactors = supportedFormFactors.ToList();
    }

    public Dimensions Size { get; }
    public Dimensions MaxGpuSize { get; }
    public Dimensions MaxCoolingSize { get; }

    public IReadOnlyCollection<IFormFactor> SupportedFormFactors
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
}