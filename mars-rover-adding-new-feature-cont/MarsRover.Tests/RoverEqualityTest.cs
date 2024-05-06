using NUnit.Framework;

namespace MarsRover.Tests;

public class RoverEqualityTest
{
    [Test]
    public void Equal_Rovers()
    {
        Assert.That(RoverFacing("N"), Is.EqualTo(RoverFacing("N")));
    }


    [Test]
    public void Not_Equal_Rovers()
    {
        Assert.That(RoverFacing("N"), Is.Not.EqualTo(new Rover(1, 1, "S")));
        Assert.That(RoverFacing("N"), Is.Not.EqualTo(new Rover(1, 2, "N")));
        Assert.That(RoverFacing("N"), Is.Not.EqualTo(new Rover(0, 1, "N")));
    }

    private Rover RoverFacing(string direction)
    {
        return RoverBuilder.ARover().Facing(direction).Build();
    }


}

internal class RoverBuilder
{
    private string direction = string.Empty;
    private int x = 1;
    private int y = 1;

    public static RoverBuilder ARover()
    {
        return new RoverBuilder();
    }

    public RoverBuilder Facing(string direction)
    {
        this.direction = direction;
        return this;
    }

    public Rover Build()
    {
        return new Rover(x, y, direction);
    }
}