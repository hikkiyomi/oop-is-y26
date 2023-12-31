using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Accounts;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Tests
{
    [Theory]
    [ClassData(typeof(TestGenerator))]
    public void WithdrawShouldBeOk(
        UserHandler userHandler,
        AccountHandler accountHandler)
    {
        IAccountRepository? repo = Substitute.For<IAccountRepository>();
        IOperationRepository? operations = Substitute.For<IOperationRepository>();
        var service = new AccountService(userHandler, accountHandler, repo, operations);
        int counter = 0;

        repo.When(x => x.ChangeBalance("user", "1234", 12))
            .Do(_ => counter++);

        service.Withdraw(1);

        Assert.Equal(1, counter);
    }

    [Theory]
    [ClassData(typeof(TestGenerator))]
    public void WithdrawShouldBeImpossible(
        UserHandler userHandler,
        AccountHandler accountHandler)
    {
        IAccountRepository? repo = Substitute.For<IAccountRepository>();
        IOperationRepository? operations = Substitute.For<IOperationRepository>();
        var service = new AccountService(userHandler, accountHandler, repo, operations);

        WithdrawResult result = service.Withdraw(14);

        Assert.IsType<WithdrawResult.Failure>(result);
    }

    [Theory]
    [ClassData(typeof(TestGenerator))]
    public void DepositShouldBeOk(
        UserHandler userHandler,
        AccountHandler accountHandler)
    {
        IAccountRepository? repo = Substitute.For<IAccountRepository>();
        IOperationRepository? operations = Substitute.For<IOperationRepository>();
        var service = new AccountService(userHandler, accountHandler, repo, operations);
        int counter = 0;

        repo.When(x => x.ChangeBalance("user", "1234", 14))
            .Do(_ => counter++);

        service.Deposit(1);

        Assert.Equal(1, counter);
    }
}