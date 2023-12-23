using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Exceptions;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models;
using Lab5.Application.Models.Operations;

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
            account: number,
            OperationResult.Success);

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
            LogOperation(
                username: _userHandler.User.Username,
                activity: "Account log in",
                account: number,
                result: OperationResult.Failure);

            return new AccountLoginResult.Failure();
        }

        LogOperation(
            username: _userHandler.User.Username,
            activity: "Account log in",
            account: number,
            result: OperationResult.Success);

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

    private void LogOperation(
        string username,
        string activity,
        string account,
        OperationResult result)
    {
        _operationRepository.AddOperation(
            username,
            activity,
            account,
            result).GetAwaiter().GetResult();
    }
}