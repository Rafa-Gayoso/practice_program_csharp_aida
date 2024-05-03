using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverRotationTests
{
    [Test]
    public void Facing_North_Rotate_Left()
    {
        var rover = CreateRoverFacingTo("N");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(CreateRoverFacingTo("W")));
    }

    [Test]
    public void Facing_North_Rotate_Right()
    {
        var rover = CreateRoverFacingTo("N");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(CreateRoverFacingTo("E")));
    }

    [Test]
    public void Facing_South_Rotate_Left()
    {
        var rover = CreateRoverFacingTo("S");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(CreateRoverFacingTo("E")));
    }

    [Test]
    public void Facing_South_Rotate_Right()
    {
        var rover = CreateRoverFacingTo("S");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(CreateRoverFacingTo("W")));
    }

    [Test]
    public void Facing_West_Rotate_Left()
    {
        var rover = CreateRoverFacingTo("W");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(CreateRoverFacingTo("S")));
    }

    [Test]
    public void Facing_West_Rotate_Right()
    {
        var rover = CreateRoverFacingTo("W");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(CreateRoverFacingTo("N")));
    }

    [Test]
    public void Facing_East_Rotate_Left()
    {
        var rover = CreateRoverFacingTo("E");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(CreateRoverFacingTo("N")));
    }

    [Test]
    public void Facing_East_Rotate_Right()
    {
        var rover = CreateRoverFacingTo("E");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(CreateRoverFacingTo("S")));
    }

    private static Rover CreateRoverFacingTo(string direction)
    {
        return ARover().WithDirection(direction).Build();
    }
}