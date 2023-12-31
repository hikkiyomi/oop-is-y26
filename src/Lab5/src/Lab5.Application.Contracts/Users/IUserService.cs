using Lab5.Application.Models.Operations;

namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    SignupResult Signup(string username, string adminPassword);

    LoginResult Login(string username);

    void EnterUserMode();

    void EnterAdminMode(string providedPassword);

    IReadOnlyCollection<Operation> FetchOperationHistory();

    void Logout();
}