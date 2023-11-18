using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeComponents;

public interface ITreeNode
{
    void Print(IOutputMode mode);
}