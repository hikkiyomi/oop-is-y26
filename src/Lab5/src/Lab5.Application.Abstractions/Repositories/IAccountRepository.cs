using Lab5.Application.Models;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Task AddAccount(string username, string number, string pin, int balance);

    Task<BankAccount?> FindAccountByUsernameAndNumber(string username, string number);
}