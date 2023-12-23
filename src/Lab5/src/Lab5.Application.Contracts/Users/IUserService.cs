namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    SignupResult Signup(string username, string adminPassword);
    LoginResult Login(string username);
}