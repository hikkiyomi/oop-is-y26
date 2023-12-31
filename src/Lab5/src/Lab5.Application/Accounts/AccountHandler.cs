using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models;

namespace Lab5.Application.Accounts;

public class AccountHandler : IAccountHandler
{
    public BankAccount? Account { get; set; }
}