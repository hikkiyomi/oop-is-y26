using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record FullParameterDto(
    string ShortName,
    string FullName,
    ParameterContext Context);