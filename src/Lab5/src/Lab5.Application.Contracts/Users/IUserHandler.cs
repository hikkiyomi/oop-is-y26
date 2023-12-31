using Lab5.Application.Models;

namespace Lab5.Application.Contracts.Users;

public interface IUserHandler
{
    User? User { get; set; }
}