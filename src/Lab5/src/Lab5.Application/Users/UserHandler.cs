using Lab5.Application.Contracts.Users;
using Lab5.Application.Models;

namespace Lab5.Application.Users;

public class UserHandler : IUserHandler
{
    public User? User { get; set; }
}