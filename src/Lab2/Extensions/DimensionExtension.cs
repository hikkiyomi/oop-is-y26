using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Extensions;

public static class DimensionExtension
{
    public static bool IsLess(this Dimensions left, Dimensions right)
    {
        return left.Length <= right.Length
            && left.Width <= right.Width
            && left.Height <= right.Height;
    }
}