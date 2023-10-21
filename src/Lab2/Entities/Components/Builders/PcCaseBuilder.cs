using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentParts;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Builders;

public class PcCaseBuilder
{
    private readonly List<IFormFactor> _supportedFormFactors = new List<IFormFactor>();
    private Dimensions _size;
    private Dimensions _maxGpuSize;
    private Dimensions _maxCoolingSize;

    public PcCaseBuilder AddSupportedFormFactor(IFormFactor formFactor)
    {
        _supportedFormFactors.Add(formFactor);

        return this;
    }

    public PcCaseBuilder SetSize(int length, int width, int height)
    {
        _size = new Dimensions(length, width, height);

        return this;
    }

    public PcCaseBuilder SetMaxGpuSize(int length, int width, int height)
    {
        _maxGpuSize = new Dimensions(length, width, height);

        return this;
    }

    public PcCaseBuilder SetMaxCoolingSystemSize(int length, int width, int height)
    {
        _maxCoolingSize = new Dimensions(length, width, height);

        return this;
    }

    public PcCase Build()
    {
        return new PcCase(
            _size ?? throw new PcCaseValidationException("PC Case should have sizes."),
            _maxGpuSize ?? throw new PcCaseValidationException("PC Case should have a maximum GPU sizes."),
            _maxCoolingSize ?? throw new PcCaseValidationException("PC Case should have a maximum cooling system sizes."),
            _supportedFormFactors);
    }
}