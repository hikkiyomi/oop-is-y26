using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record ParameterDto(
    string? ShortName,
    string FullName,
    ParameterContext Context);