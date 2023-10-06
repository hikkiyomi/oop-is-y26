using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class HealthPoints : IConsumable
{
    public HealthPoints(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException(
                "Health value cannot be negative",
                nameof(value));
        }

        Value = value;
    }

    public int Value { get; }

    public static HealthPoints operator -(HealthPoints? left, HealthPoints? right)
    {
        if (left is null)
        {
            throw new ArgumentNullException(
                nameof(left),
                "Missing mandatory left parameter while subtracting health");
        }

        if (right is null)
        {
            throw new ArgumentNullException(
                nameof(right),
                "Missing mandatory right parameter while subtracting health");
        }

        return new HealthPoints(left.Value - right.Value);
    }

    public static HealthPoints Subtract(HealthPoints left, HealthPoints right)
    {
        return left - right;
    }
}