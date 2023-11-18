using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Chains;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

public class CommandContext
{
    private readonly Dictionary<string, ParameterContext> _contextByShortName;
    private readonly Dictionary<string, ParameterContext> _contextByFullName;

    public CommandContext(
        CommandIdentifier id,
        Action<object[]> action,
        ParserChain chain,
        IEnumerable<ParameterDto> dataTransferObjects)
    {
        Id = id;
        Action = action;
        Chain = chain;

        IEnumerable<ParameterDto> transferObjects = dataTransferObjects.ToList();

        _contextByShortName = transferObjects
            .Where(dto => dto.ShortName is not null)
            .Select(dto =>
            {
                // Я пытался сделать без этого ассерта, но анализатор настаивал на этой строчке кода.
                Debug.Assert(dto.ShortName != null, "dto.ShortName != null");

                if (dto.ShortName.Length != 1)
                {
                    throw new CommandContextException("Length of short name should be equal to 1.");
                }

                return new FullParameterDto(dto.ShortName, dto.FullName, dto.Context);
            })
            .ToDictionary(
            dto => dto.ShortName,
            dto => dto.Context);

        _contextByFullName = transferObjects
            .ToDictionary(
                dto => dto.FullName,
                dto => dto.Context);
    }

    public CommandIdentifier Id { get; }
    public Action<object[]> Action { get; }
    public ParserChain Chain { get; }

    public ParameterContext GetParameterByShortName(string shortName)
    {
        if (shortName.Length != 1)
        {
            throw new CommandContextException("Length of short name should be equal to 1.");
        }

        return _contextByShortName.TryGetValue(shortName, out ParameterContext? value)
            ? value
            : throw new CommandContextException("Trying to get a non-existing parameter by short name.");
    }

    public ParameterContext GetParameterByFullName(string fullName)
    {
        return _contextByFullName.TryGetValue(fullName, out ParameterContext? value)
            ? value
            : throw new CommandContextException("Trying to get a non-existing parameter by full name.");
    }
}