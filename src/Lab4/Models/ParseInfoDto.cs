using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record ParseInfoDto(
    CommandIdentifier Id,
    Dictionary<string, string> Context,
    ReadOnlyCollection<string> Positionals,
    Action<object[]> OriginalCommand,
    Action CommandToInvoke);