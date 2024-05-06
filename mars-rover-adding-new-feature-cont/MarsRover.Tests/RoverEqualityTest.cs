using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverEqualityTest
{
    [Test]
    public void Equal_Rovers()
    {
        Assert.That(
            ARover().Facing("N").WithCoordinates(1, 1).Build(),
            Is.EqualTo(ARover().Facing("N").WithCoordinates(1, 1).Build()));
    }

    [Test]
    public void Not_Equal_Rovers()
    {
        Assert.That(
            ARover().Facing("N").WithCoordinates(1, 1).Build(),
            Is.Not.EqualTo(ARover().Facing("S").Build()));

        Assert.That(
            ARover().Facing("N").WithCoordinates(1, 1).Build(),
            Is.Not.EqualTo(ARover().Facing("N").WithCoordinates(1, 2).Build()));

        Assert.That(
            ARover().Facing("N").WithCoordinates(1, 1).Build(),
            Is.Not.EqualTo(ARover().Facing("N").WithCoordinates(0, 1).Build()));
    }
}

internal class RoverBuilder
{
    private string direction = string.Empty;
    private int x = 0;
    private int y = 0;

    public static RoverBuilder ARover()
    {
        return new RoverBuilder();
    }

    public RoverBuilder Facing(string direction)
    {
        this.direction = direction;
        return this;
    }

    public RoverBuilder WithCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
        return this;
    }

    public Rover Build()
    {
        return new Rover(x, y, direction);
    }

    public static Rover RoverFacing(string direction)
    {
        return ARover().Facing(direction).Build();
    }

}