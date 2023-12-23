namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    CreateAccountResult CreateAccount(string number, string pin);
}