using Lab5.Application.Models.Operations;

namespace Lab5.Application.Abstractions.Repositories;

public interface IOperationRepository
{
    Task AddOperation(
        string username,
        string activity,
        string account,
        OperationResult result);

    Task<IReadOnlyCollection<Operation>> Fetch(string username);
}