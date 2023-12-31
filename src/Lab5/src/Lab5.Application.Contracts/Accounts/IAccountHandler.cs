using Lab5.Application.Models;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountHandler
{
    BankAccount? Account { get; set; }
}