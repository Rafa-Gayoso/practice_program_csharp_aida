using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverRotationTests
{
    [Test]
    public void Facing_North_Rotate_Left()
    {
        var rover = AnyRoverFacing("N");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("W")));
    }

    [Test]
    public void Facing_North_Rotate_Right()
    {
        var rover = AnyRoverFacing("N");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("E")));
    }

    [Test]
    public void Facing_South_Rotate_Left()
    {
        var rover = AnyRoverFacing("S");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("E")));
    }

    [Test]
    public void Facing_South_Rotate_Right()
    {
        var rover = AnyRoverFacing("S");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("W")));
    }

    [Test]
    public void Facing_West_Rotate_Left()
    {
        var rover = AnyRoverFacing("W");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("S")));
    }

    [Test]
    public void Facing_West_Rotate_Right()
    {
        var rover = AnyRoverFacing("W");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("N")));
    }

    [Test]
    public void Facing_East_Rotate_Left()
    {
        var rover = AnyRoverFacing("E");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("N")));
    }

    [Test]
    public void Facing_East_Rotate_Right()
    {
        var rover = AnyRoverFacing("E");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("S")));
    }
}