using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        CREATE TABLE Users
        (
            id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
            user_name TEXT NOT NULL,
            admin_password TEXT NOT NULL
        );
        
        CREATE TABLE OperationHistory
        (
            id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
            user_name TEXT NOT NULL,
            activity TEXT NOT NULL,
            account_id TEXT NOT NULL
        );
        
        CREATE TABLE BankAccount
        (
            id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
            user_name TEXT NOT NULL,
            number TEXT NOT NULL,
            pin TEXT NOT NULL,
            balance BIGINT NOT NULL
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        DROP TABLE Users;
        DROP TABLE OperationHistory;
        DROP TABLE BankAccount;
        """;
}