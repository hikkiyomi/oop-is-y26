using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class DisplayScreen : IMessageEndpoint
{
    private readonly IDisplayDriver _driver;
    private Color _color;

    public DisplayScreen(
        IDisplayDriver driver,
        Color color,
        int priority)
    {
        _driver = driver;
        _color = color;
        Priority = priority;
    }

    public int Priority { get; }

    public void ChangeColor(Color color)
    {
        _color = color;
    }

    public void Interact(Message message)
    {
        _driver.Clear();
        _driver.ChangeColor(_color);
        _driver.Print(message);
    }
}