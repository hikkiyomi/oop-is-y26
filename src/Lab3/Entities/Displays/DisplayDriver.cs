using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class DisplayDriver : IDisplayDriver
{
    private Color _color;

    public void Clear()
    {
        Console.Clear();
    }

    public void ChangeColor(Color color)
    {
        _color = color;
    }

    public void Print(Message message)
    {
        Console.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(message.ToString()));
    }
}