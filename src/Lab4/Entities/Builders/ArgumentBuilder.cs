using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Builders;

public class ArgumentBuilder : IArgumentBuilder
{
    private string? _mainSignature;
    private string? _actionSignature;
    private Dictionary<string, string> _parameters = new();

    public ArgumentBuilder SetMainSignature(string signature)
    {
        _mainSignature = signature;

        return this;
    }

    public ArgumentBuilder SetActionSignature(string signature)
    {
        _actionSignature = signature;

        return this;
    }

    public ArgumentBuilder AddParameterValue(string parameter, string value)
    {
        if (_parameters.ContainsKey(parameter))
        {
            throw new ArgumentBuilderException("Some parameter was repeated.");
        }

        _parameters[parameter] = value;

        return this;
    }

    public ArgumentContext Build()
    {
        if (_mainSignature is null)
        {
            throw new ArgumentBuilderException("Main signature should not be null.");
        }

        if (_actionSignature is null)
        {
            throw new ArgumentBuilderException("Action signature should not be null.");
        }

        return new ArgumentContext(
            new CommandIdentifier(_mainSignature, _actionSignature),
            _parameters);
    }
}