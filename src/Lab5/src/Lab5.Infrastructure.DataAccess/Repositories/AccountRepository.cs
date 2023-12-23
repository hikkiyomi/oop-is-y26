using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task AddAccount(string username, string number, string pin, int balance)
    {
        const string query = """
                             INSERT INTO BankAccount(user_name, number, pin, balance)
                             VALUES (:user_name, :number, :pin, :balance)
                             """;

        NpgsqlConnection connection =
            await _connectionProvider
                .GetConnectionAsync(default)
                .ConfigureAwait(false);

        using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("user_name", username);
        command.Parameters.AddWithValue("number", number);
        command.Parameters.AddWithValue("pin", pin);
        command.Parameters.AddWithValue("balance", balance);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}