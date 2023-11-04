using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class DisplayScreen : IMessageEndpoint
{
    private readonly IDisplayDriver _driver;
    private readonly Color _color;

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

    public void Interact(Message message)
    {
        _driver.Clear();
        _driver.ChangeColor(_color);
        _driver.Print(message);
    }
}