using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Chains;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

public class CommandContext
{
    private readonly Dictionary<string, string> _fullNameByShortName = new();
    private readonly Dictionary<string, ParameterContext> _contextByFullName;

    private CommandContext(
        CommandIdentifier id,
        Action<object[]> action,
        ParserChain chain,
        IEnumerable<ParameterContext> dataTransferObjects)
    {
        Id = id;
        Action = action;
        Chain = chain;

        IEnumerable<ParameterContext> transferObjects = dataTransferObjects.ToList();

        _contextByFullName = transferObjects
            .ToDictionary(
                dto => dto.FullName,
                dto => dto);

        foreach (ParameterContext dto in transferObjects
                     .Where(dto => dto.ShortName is not null))
        {
            // Анализатор заставил меня написать эту строчку.
            // А как по-другому?)
            Debug.Assert(dto.ShortName is not null, "dto.ShortName is not null");
            _fullNameByShortName.Add(dto.ShortName, dto.FullName);
        }
    }

    public static ICommandMainSignatureBuilder Builder => new CommandContextBuilder();
    public CommandIdentifier Id { get; }
    public Action<object[]> Action { get; }
    public ParserChain Chain { get; }

    public string GetParameterFullName(string name)
    {
        return _fullNameByShortName.TryGetValue(name, out string? value)
            ? value
            : name;
    }

    public ParameterContext? FindParameterByName(string name)
    {
        ParameterContext? byFullName = FindParameterByFullName(name);
        ParameterContext? byShortName = FindParameterByShortName(name);

        if (byFullName is null && byShortName is null)
        {
            return null;
        }

        return byFullName ?? byShortName;
    }

    private ParameterContext? FindParameterByFullName(string fullName)
    {
        return _contextByFullName.TryGetValue(fullName, out ParameterContext? value)
            ? value
            : null;
    }

    private ParameterContext? FindParameterByShortName(string shortName)
    {
        if (shortName.Length != 1)
        {
            return null;
        }

        if (!_fullNameByShortName.TryGetValue(shortName, out string? value))
        {
            throw new CommandContextException($"No such short name as {shortName}");
        }

        return FindParameterByFullName(value);
    }

    private class CommandContextBuilder
        : ICommandMainSignatureBuilder,
            ICommandActionSignatureBuilder,
            ICommandParameterBuilder,
            ICommandFinalizerBuilder
    {
        private readonly List<ParameterContext> _parameters = new();
        private string? _mainSignature;
        private string? _actionSignature;
        private Action<object[]>? _action;

        public ICommandActionSignatureBuilder SetMainSignature(string signature)
        {
            _mainSignature = signature;

            return this;
        }

        public ICommandParameterBuilder SetActionSignature(string signature)
        {
            _actionSignature = signature;

            return this;
        }

        public ICommandParameterBuilder AddParameter(string shortName, string fullName)
        {
            if (shortName.Length != 1)
            {
                throw new CommandContextException("Length of short name should be equal to 1.");
            }

            _parameters.Add(new ParameterContext(shortName, fullName));

            return this;
        }

        public ICommandParameterBuilder AddParameter(string fullName)
        {
            _parameters.Add(new ParameterContext(fullName));

            return this;
        }

        public ICommandFinalizerBuilder SetAction(Action<object[]> action)
        {
            _action = action;

            return this;
        }

        public CommandContext Build()
        {
            if (_mainSignature is null)
            {
                throw new CommandContextException("Main signature cannot be null.");
            }

            if (_actionSignature is null)
            {
                throw new CommandContextException("Action signature cannot be null.");
            }

            if (_action is null)
            {
                throw new CommandContextException("Action cannot be null.");
            }

            var chainMainSignature = new ParserChain(_mainSignature);
            var chainActionSignature = new ParserChain(_actionSignature);
            var chainParameters = new ParserChain("parameterNode");

            foreach (ParameterContext param in _parameters)
            {
                chainActionSignature.AddNext(param.FullName, chainParameters);
            }

            chainMainSignature.AddNext(_actionSignature, chainActionSignature);

            return new CommandContext(
                new CommandIdentifier(_mainSignature, _actionSignature),
                _action,
                chainMainSignature,
                _parameters);
        }
    }
}