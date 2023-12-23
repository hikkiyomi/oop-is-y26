namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    CreateAccountResult CreateAccount(string number, string pin);

    AccountLoginResult Login(string number, string pin);

    int GetBalance();

    DepositResult Deposit(int deposit);
}