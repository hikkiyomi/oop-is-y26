using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class DisplayDriver : IDisplayDriver
{
    public Color Color { get; private set; }

    public void Clear()
    {
        throw new System.NotImplementedException();
    }

    public void ChangeColor(Color color)
    {
        Color = color;
    }

    public void Print(Message message)
    {
        throw new System.NotImplementedException();
    }
}