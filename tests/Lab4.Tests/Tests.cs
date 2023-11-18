using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests
{
    [Theory]
    [ClassData(typeof(DisconnectedWorkplaceGenerator))]
    public void ConnectCommandShouldBeOk(Workplace workplace)
    {
        ParseInfoDto command = workplace.GetExecutionInfo("connect /home/wawowewo/ --mode=local");

        Assert.Equal("connect", command.Id.MainSignature);
        Assert.Equal(string.Empty, command.Id.ActionSignature);
        Assert.Single(command.Context);
        Assert.Equal("local", command.Context["mode"]);
    }

    [Theory]
    [ClassData(typeof(ConnectedWorkplaceGenerator))]
    public void DisconnectCommandShouldBeOk(Workplace workplace)
    {
        ParseInfoDto command = workplace.GetExecutionInfo("disconnect");

        Assert.Equal("disconnect", command.Id.MainSignature);
        Assert.Equal(string.Empty, command.Id.ActionSignature);
        Assert.Empty(command.Context);
    }

    [Theory]
    [ClassData(typeof(ConnectedWorkplaceGenerator))]
    public void GotoCommandShouldBeOk(Workplace workplace)
    {
        ParseInfoDto command = workplace.GetExecutionInfo("tree goto ..");

        Assert.Equal("tree", command.Id.MainSignature);
        Assert.Equal("goto", command.Id.ActionSignature);
        Assert.Empty(command.Context);
        Assert.Single(command.Positionals);
        Assert.Equal("..", command.Positionals[0]);
    }

    [Theory]
    [ClassData(typeof(ConnectedWorkplaceGenerator))]
    public void ListCommandShouldBeOk(Workplace workplace)
    {
        ParseInfoDto command = workplace.GetExecutionInfo("tree list -d=3");

        Assert.Equal("tree", command.Id.MainSignature);
        Assert.Equal("list", command.Id.ActionSignature);
        Assert.Single(command.Context);
        Assert.Empty(command.Positionals);
        Assert.Equal("3", command.Context["depth"]);
    }

    [Theory]
    [ClassData(typeof(ConnectedWorkplaceGenerator))]
    public void ShowCommandShouldBeOk(Workplace workplace)
    {
        ParseInfoDto command = workplace.GetExecutionInfo("file show /home/wawowewo/UMLs/oop-lab-4/real_text.txt --mode=console");

        Assert.Equal("file", command.Id.MainSignature);
        Assert.Equal("show", command.Id.ActionSignature);
        Assert.Single(command.Context);
        Assert.Single(command.Positionals);
        Assert.Equal("console", command.Context["mode"]);
        Assert.Equal("/home/wawowewo/UMLs/oop-lab-4/real_text.txt", command.Positionals[0]);
    }

    [Theory]
    [ClassData(typeof(ConnectedWorkplaceGenerator))]
    public void MoveCommandShouldBeOk(Workplace workplace)
    {
        ParseInfoDto command =
            workplace.GetExecutionInfo("file move /home/wawowewo/UMLs/oop-lab-4/real_text.txt /home/wawowewo/UMLs/real_text.txt");

        Assert.Equal("file", command.Id.MainSignature);
        Assert.Equal("move", command.Id.ActionSignature);
        Assert.Empty(command.Context);
        Assert.Equal(2, command.Positionals.Count);
        Assert.Equal("/home/wawowewo/UMLs/oop-lab-4/real_text.txt", command.Positionals[0]);
        Assert.Equal("/home/wawowewo/UMLs/real_text.txt", command.Positionals[1]);
    }

    [Theory]
    [ClassData(typeof(ConnectedWorkplaceGenerator))]
    public void CopyCommandShouldBeOk(Workplace workplace)
    {
        ParseInfoDto command =
            workplace.GetExecutionInfo("file copy /home/wawowewo/UMLs/oop-lab-4/real_text.txt /home/wawowewo/UMLs/real_text.txt");

        Assert.Equal("file", command.Id.MainSignature);
        Assert.Equal("copy", command.Id.ActionSignature);
        Assert.Empty(command.Context);
        Assert.Equal(2, command.Positionals.Count);
        Assert.Equal("/home/wawowewo/UMLs/oop-lab-4/real_text.txt", command.Positionals[0]);
        Assert.Equal("/home/wawowewo/UMLs/real_text.txt", command.Positionals[1]);
    }

    [Theory]
    [ClassData(typeof(ConnectedWorkplaceGenerator))]
    public void DeleteCommandShouldBeOk(Workplace workplace)
    {
        ParseInfoDto command = workplace.GetExecutionInfo("file delete /home/wawowewo/UMLs/oop-lab-4/real_text.txt");

        Assert.Equal("file", command.Id.MainSignature);
        Assert.Equal("delete", command.Id.ActionSignature);
        Assert.Empty(command.Context);
        Assert.Single(command.Positionals);
        Assert.Equal("/home/wawowewo/UMLs/oop-lab-4/real_text.txt", command.Positionals[0]);
    }

    [Theory]
    [ClassData(typeof(ConnectedWorkplaceGenerator))]
    public void RenameCommandShouldBeOk(Workplace workplace)
    {
        ParseInfoDto command =
            workplace.GetExecutionInfo("file rename /home/wawowewo/UMLs/oop-lab-4/real_text.txt kek_text.txt");

        Assert.Equal("file", command.Id.MainSignature);
        Assert.Equal("rename", command.Id.ActionSignature);
        Assert.Empty(command.Context);
        Assert.Equal(2, command.Positionals.Count);
        Assert.Equal("/home/wawowewo/UMLs/oop-lab-4/real_text.txt", command.Positionals[0]);
        Assert.Equal("kek_text.txt", command.Positionals[1]);
    }
}