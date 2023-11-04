using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class DisplayDriver : IDisplayDriver
{
    private readonly IWriter _writer;
    private Color _color;

    public DisplayDriver(IWriter writer)
    {
        _writer = writer;
    }

    public string FormText(Message message)
        => Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(message.ToString());

    public void Clear()
    {
        _writer.Clear();
    }

    public void ChangeColor(Color color)
    {
        _color = color;
    }

    public void Print(Message message)
    {
        _writer.Write(FormText(message));
    }
}