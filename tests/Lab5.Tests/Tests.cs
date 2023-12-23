using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Accounts;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models;
using Lab5.Application.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Tests
{
    [Fact]
    public void WithdrawShouldBeOk()
    {
        var handler = new UserHandler();
        var accHandler = new AccountHandler();
        IAccountRepository? repo = Substitute.For<IAccountRepository>();
        IOperationRepository? operations = Substitute.For<IOperationRepository>();
        int counter = 0;

        handler.User = new User("user", "1234", Mode.User);
        accHandler.Account = new BankAccount("user", "1234", "1234", 13);

        var service = new AccountService(
            handler,
            accHandler,
            repo,
            operations);

        repo.When(x => x.ChangeBalance("user", "1234", 12))
            .Do(_ => counter++);

        service.Withdraw(1);

        Assert.Equal(1, counter);
    }

    [Fact]
    public void WithdrawShouldBeImpossible()
    {
        var handler = new UserHandler();
        var accHandler = new AccountHandler();
        IAccountRepository? repo = Substitute.For<IAccountRepository>();
        IOperationRepository? operations = Substitute.For<IOperationRepository>();

        handler.User = new User("user", "1234", Mode.User);
        accHandler.Account = new BankAccount("user", "1234", "1234", 13);

        var service = new AccountService(
            handler,
            accHandler,
            repo,
            operations);

        WithdrawResult result = service.Withdraw(14);

        Assert.IsType<WithdrawResult.Failure>(result);
    }

    [Fact]
    public void DepositShouldBeOk()
    {
        var handler = new UserHandler();
        var accHandler = new AccountHandler();
        IAccountRepository? repo = Substitute.For<IAccountRepository>();
        IOperationRepository? operations = Substitute.For<IOperationRepository>();
        int counter = 0;

        handler.User = new User("user", "1234", Mode.User);
        accHandler.Account = new BankAccount("user", "1234", "1234", 13);

        var service = new AccountService(
            handler,
            accHandler,
            repo,
            operations);

        repo.When(x => x.ChangeBalance("user", "1234", 14))
            .Do(_ => counter++);

        service.Deposit(1);

        Assert.Equal(1, counter);
    }
}