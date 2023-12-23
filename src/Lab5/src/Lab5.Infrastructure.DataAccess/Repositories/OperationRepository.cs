using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Operations;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task AddOperation(
        string username,
        string activity,
        string account,
        OperationResult result)
    {
        const string query = """
                             INSERT INTO OperationHistory(user_name, activity, account_id, operation_result)
                             VALUES (:user_name, :activity, :account_id, :operation_result);
                             """;

        NpgsqlConnection connection =
            await _connectionProvider
                .GetConnectionAsync(default)
                .ConfigureAwait(false);

        using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("user_name", username);
        command.Parameters.AddWithValue("activity", activity);
        command.Parameters.AddWithValue("account_id", account);
        command.Parameters.AddWithValue("operation_result", result);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<IReadOnlyCollection<Operation>> Fetch(string username)
    {
        const string query = """
                             SELECT
                                user_name,
                                activity,
                                account_id,
                                operation_result
                             FROM OperationHistory
                             WHERE user_name = :user_name;
                             """;

        NpgsqlConnection connection =
            await _connectionProvider
                .GetConnectionAsync(default)
                .ConfigureAwait(false);

        using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("user_name", username);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
        var operations = new List<Operation>();

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            operations.Add(new Operation(
                Username: reader.GetString(0),
                Activity: reader.GetString(1),
                Account: reader.GetString(2),
                Result: await reader.GetFieldValueAsync<OperationResult>(4).ConfigureAwait(false)));
        }

        return operations.AsReadOnly();
    }
}