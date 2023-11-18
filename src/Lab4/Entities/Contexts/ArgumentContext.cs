using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

public record ArgumentContext(
    CommandIdentifier Id,
    Dictionary<string, string> Parameters);