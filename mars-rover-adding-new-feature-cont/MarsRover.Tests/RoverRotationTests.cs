using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverRotationTests
{
    [Test]
    public void Facing_North_Rotate_Left()
    {
        var rover = CreateRoverAtInitialFacingTo("N");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(CreateRoverAtInitialFacingTo("W")));
    }

    [Test]
    public void Facing_North_Rotate_Right()
    {
        var rover = CreateRoverAtInitialFacingTo("N");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(CreateRoverAtInitialFacingTo("E")));
    }

    [Test]
    public void Facing_South_Rotate_Left()
    {
        var rover = CreateRoverAtInitialFacingTo("S");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(CreateRoverAtInitialFacingTo("E")));
    }

    [Test]
    public void Facing_South_Rotate_Right()
    {
        var rover = CreateRoverAtInitialFacingTo("S");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(CreateRoverAtInitialFacingTo("W")));
    }

    [Test]
    public void Facing_West_Rotate_Left()
    {
        var rover = CreateRoverAtInitialFacingTo("W");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(CreateRoverAtInitialFacingTo("S")));
    }

    [Test]
    public void Facing_West_Rotate_Right()
    {
        var rover = CreateRoverAtInitialFacingTo("W");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(CreateRoverAtInitialFacingTo("N")));
    }

    [Test]
    public void Facing_East_Rotate_Left()
    {
        var rover = CreateRoverAtInitialFacingTo("E");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(CreateRoverAtInitialFacingTo("N")));
    }

    [Test]
    public void Facing_East_Rotate_Right()
    {
        var rover = CreateRoverAtInitialFacingTo("E");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(CreateRoverAtInitialFacingTo("S")));
    }
}