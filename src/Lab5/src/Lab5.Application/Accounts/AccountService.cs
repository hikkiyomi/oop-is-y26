using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Exceptions;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models;

namespace Lab5.Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IUserHandler _userHandler;
    private readonly IAccountHandler _accountHandler;
    private readonly IAccountRepository _accountRepository;
    private readonly IOperationRepository _operationRepository;

    public AccountService(
        IUserHandler userHandler,
        IAccountHandler accountHandler,
        IAccountRepository accountRepository,
        IOperationRepository operationRepository)
    {
        _userHandler = userHandler;
        _accountHandler = accountHandler;
        _accountRepository = accountRepository;
        _operationRepository = operationRepository;
    }

    public CreateAccountResult CreateAccount(string number, string pin)
    {
        if (_userHandler.User is null)
        {
            return new CreateAccountResult.Failure();
        }

        _accountRepository.AddAccount(
            _userHandler.User.Username,
            number,
            pin,
            balance: 0).GetAwaiter().GetResult();

        LogOperation(
            username: _userHandler.User.Username,
            activity: "Creating account",
            account: number);

        return new CreateAccountResult.Success();
    }

    public AccountLoginResult Login(string number, string pin)
    {
        if (_userHandler.User is null)
        {
            throw new AccountException(
                "Trying to log into account with non-existing user");
        }

        Task<BankAccount?> task
            = _accountRepository.FindAccountByUsernameAndNumber(
                _userHandler.User.Username,
                number);

        BankAccount? account = task.Result;

        if (account is null)
        {
            return new AccountLoginResult.Failure();
        }

        LogOperation(
            username: _userHandler.User.Username,
            activity: "Account log in",
            account: number);

        _accountHandler.Account = account;

        return new AccountLoginResult.Success();
    }

    public int GetBalance()
    {
        if (_accountHandler.Account is null)
        {
            throw new AccountException(
                "Trying to get balance of non-existing account");
        }

        return _accountHandler.Account.Balance;
    }

    public DepositResult Deposit(int deposit)
    {
        if (_userHandler.User is null)
        {
            throw new AccountException(
                "Trying to deposit into an account of non-existing user");
        }

        if (_accountHandler.Account is null)
        {
            throw new AccountException(
                "Trying to deposit into non-existing account");
        }

        _accountHandler.Account = _accountHandler.Account with
        {
            Balance = _accountHandler.Account.Balance + deposit,
        };

        _accountRepository.ChangeBalance(
                _userHandler.User.Username,
                _accountHandler.Account.Number,
                _accountHandler.Account.Balance)
            .GetAwaiter().GetResult();

        LogOperation(
            username: _userHandler.User.Username,
            activity: $"Deposit: {deposit}. New balance: {_accountHandler.Account.Balance}",
            account: _accountHandler.Account.Number);

        return new DepositResult.Success();
    }

    public WithdrawResult Withdraw(int withdraw)
    {
        if (_userHandler.User is null)
        {
            throw new AccountException(
                "Trying to withdraw from an account of non-existing user");
        }

        if (_accountHandler.Account is null)
        {
            throw new AccountException(
                "Trying to withdraw from non-existing account");
        }

        if (_accountHandler.Account.Balance < withdraw)
        {
            return new WithdrawResult.Failure();
        }

        _accountHandler.Account = _accountHandler.Account with
        {
            Balance = _accountHandler.Account.Balance - withdraw,
        };

        _accountRepository.ChangeBalance(
                _userHandler.User.Username,
                _accountHandler.Account.Number,
                _accountHandler.Account.Balance)
            .GetAwaiter().GetResult();

        LogOperation(
            username: _userHandler.User.Username,
            activity: $"Withdrawal: {withdraw}. New balance: {_accountHandler.Account.Balance}",
            account: _accountHandler.Account.Number);

        return new WithdrawResult.Success();
    }

    public void Logout()
    {
        if (_accountHandler.Account is null)
        {
            throw new AccountException(
                "Trying to log out from non-existing account");
        }

        _accountHandler.Account = null;
    }

    private void LogOperation(
        string username,
        string activity,
        string account)
    {
        _operationRepository.AddOperation(
            username,
            activity,
            account)
            .GetAwaiter().GetResult();
    }
}