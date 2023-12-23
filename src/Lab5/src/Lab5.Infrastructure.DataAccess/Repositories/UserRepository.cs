using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task AddUser(string username, string adminPassword)
    {
        const string query = """
                             INSERT INTO Users(user_name, admin_password)
                             VALUES (:username, :adminPassword);
                             """;

        NpgsqlConnection connection =
            await _connectionProvider
                .GetConnectionAsync(default)
                .ConfigureAwait(false);

        using var command = new NpgsqlCommand(query, connection);

        command.Parameters.AddWithValue("username", username);
        command.Parameters.AddWithValue("adminPassword", adminPassword);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<User?> FindUserByUsername(string username)
    {
        const string query = """
                             SELECT
                                user_id,
                                user_name,
                                admin_password
                             FROM Users
                             WHERE user_name = :username;
                             """;

        NpgsqlConnection connection =
            await _connectionProvider
                .GetConnectionAsync(default)
                .ConfigureAwait(false);

        using var command = new NpgsqlCommand(query, connection);
        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        return await reader.ReadAsync().ConfigureAwait(false)
            ? new User(
                Username: reader.GetString(1),
                AdminPassword: reader.GetString(2),
                Mode: null)
            : null;
    }
}