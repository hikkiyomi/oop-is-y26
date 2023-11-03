namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public interface IDisplayDriver
{
    void Clear();
    void SetColor();
    void Print(string text);
}