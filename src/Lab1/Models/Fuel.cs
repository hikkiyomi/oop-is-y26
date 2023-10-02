using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Fuel : IConsumable
{
    public Fuel(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException(
                "Fuel value cannot be negative or zero",
                nameof(value));
        }

        Value = value;
    }

    public int Value { get; set; }

    public static Fuel operator -(Fuel? left, Fuel? right)
    {
        if (left is null)
        {
            throw new ArgumentNullException(
                nameof(left),
                "Missing mandatory left parameter while subtracting fuel");
        }

        if (right is null)
        {
            throw new ArgumentNullException(
                nameof(right),
                "Missing mandatory right parameter while subtracting fuel");
        }

        int value = left.Value - right.Value;

        return new Fuel(value);
    }

    public static Fuel Subtract(Fuel left, Fuel right)
    {
        return left - right;
    }
}