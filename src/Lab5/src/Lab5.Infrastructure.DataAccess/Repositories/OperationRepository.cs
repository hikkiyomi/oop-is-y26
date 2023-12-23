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
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("user_name", username);
        command.Parameters.AddWithValue("activity", activity);
        command.Parameters.AddWithValue("account_d", account);
        command.Parameters.AddWithValue("operation_result", result);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}