namespace Lab5.Application.Models.Operations;

public record Operation(
    string Username,
    string Activity,
    string Account,
    OperationResult Result);