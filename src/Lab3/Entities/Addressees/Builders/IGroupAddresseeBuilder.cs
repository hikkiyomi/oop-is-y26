namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Builders;

public interface IGroupAddresseeBuilder
{
    IGroupAddresseeBuilder AddAddressee(IAddressee addressee);
    GroupAddressee Build();
}