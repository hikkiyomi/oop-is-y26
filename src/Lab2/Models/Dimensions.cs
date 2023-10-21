using Itmo.ObjectOrientedProgramming.Lab2.Common.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Dimensions
{
    public Dimensions(int length, int width, int height)
    {
        if (length < 0)
        {
            throw new DimensionsException(
                "Length cannot be negative.");
        }

        if (width < 0)
        {
            throw new DimensionsException(
                "Width cannot be negative.");
        }

        if (height < 0)
        {
            throw new DimensionsException(
                "Height cannot be negative.");
        }

        Length = length;
        Width = width;
        Height = height;
    }

    public int Length { get; }

    public int Width { get; }

    public int Height { get; }
}