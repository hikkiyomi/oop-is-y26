using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Exceptions;
using Lab5.Application.Models;
using Lab5.Application.Models.Operations;
using User = Lab5.Application.Models.User;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IOperationRepository _operationRepository;
    private readonly IUserHandler _userHandler;

    public UserService(
        IUserRepository userRepository,
        IOperationRepository operationRepository,
        IUserHandler userHandler)
    {
        _userRepository = userRepository;
        _operationRepository = operationRepository;
        _userHandler = userHandler;
    }

    public SignupResult Signup(string username, string adminPassword)
    {
        _userRepository.AddUser(username, adminPassword).GetAwaiter().GetResult();

        LogOperation(
            username: username,
            activity: "Sign up",
            account: string.Empty,
            result: new OperationResult.Success());

        return new SignupResult.Success();
    }

    public LoginResult Login(string username)
    {
        Task<User?> task = _userRepository.FindUserByUsername(username);
        User? user = task.Result;

        if (user is null)
        {
            LogOperation(
                username: username,
                activity: "Log in",
                account: string.Empty,
                result: new OperationResult.Failure());

            return new LoginResult.Failure();
        }

        LogOperation(
            username: username,
            activity: "Log in",
            account: string.Empty,
            result: new OperationResult.Success());

        _userHandler.User = user;

        return new LoginResult.Success();
    }

    public void EnterUserMode()
    {
        if (_userHandler.User is null)
        {
            throw new UserHandlerException(
                "Could not enter user mode");
        }

        _userHandler.User = _userHandler.User with { Mode = Mode.User };
    }

    public void EnterAdminMode(string providedPassword)
    {
        if (_userHandler.User is null)
        {
            throw new UserHandlerException(
                "Could not enter admin mode");
        }

        if (!_userHandler.User.AdminPassword.Equals(providedPassword, StringComparison.Ordinal))
        {
            throw new UserHandlerException(
                "Wrong admin password. Shutting down the system");
        }

        _userHandler.User = _userHandler.User with { Mode = Mode.Admin };
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