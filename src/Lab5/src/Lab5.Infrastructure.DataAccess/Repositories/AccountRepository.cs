using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models;
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

        NpgsqlConnection connection
            = await _connectionProvider
                .GetConnectionAsync(default)
                .ConfigureAwait(false);

        using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("user_name", username);
        command.Parameters.AddWithValue("number", number);
        command.Parameters.AddWithValue("pin", pin);
        command.Parameters.AddWithValue("balance", balance);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<BankAccount?> FindAccountByUsernameAndNumber(string username, string number)
    {
        const string query = """
                             SELECT
                                user_name,
                                number,
                                pin,
                                balance
                             FROM BankAccount
                             WHERE user_name = :user_name AND number = :number;
                             """;

        NpgsqlConnection connection
            = await _connectionProvider
                .GetConnectionAsync(default)
                .ConfigureAwait(false);

        using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("user_name", username);
        command.Parameters.AddWithValue("number", number);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        return await reader.ReadAsync().ConfigureAwait(false)
            ? new BankAccount(
                Username: reader.GetString(0),
                Number: reader.GetString(1),
                Pin: reader.GetString(2),
                Balance: reader.GetInt32(3))
            : null;
    }

    public async Task ChangeBalance(string username, string number, int newBalance)
    {
        const string query = """
                             UPDATE BankAccount
                             SET balance = :balance
                             WHERE user_name = :user_name AND number = :number;
                             """;

        NpgsqlConnection connection
            = await _connectionProvider
                .GetConnectionAsync(default)
                .ConfigureAwait(false);

        using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("user_name", username);
        command.Parameters.AddWithValue("number", number);
        command.Parameters.AddWithValue("balance", newBalance);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}