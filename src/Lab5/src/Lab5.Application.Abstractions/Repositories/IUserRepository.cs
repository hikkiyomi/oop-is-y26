using Lab5.Application.Models;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task AddUser(string username, string adminPassword);

    Task<User?> FindUserByUsername(string username);
}