using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record ParseInfoDto(
    CommandIdentifier Id,
    Dictionary<string, string> Context,
    Action<object[]> OriginalCommand,
    Action CommandToInvoke);