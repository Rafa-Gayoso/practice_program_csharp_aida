using NUnit.Framework;
using static MarsRover.Tests.NasaRoverBuilder;

namespace MarsRover.Tests;

public class RoverRotationTests
{
    [Test]
    public void Facing_North_Rotate_Left()
    {
        var rover = ARover().FacingNorth().Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(ARover().FacingWest().Build()));
    }

    [Test]
    public void Facing_North_Rotate_Right()
    {
        var rover = ARover().FacingNorth().Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(ARover().FacingEast().Build()));
    }

    [Test]
    public void Facing_South_Rotate_Left()
    {
        var rover = ARover().FacingSouth().Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(ARover().FacingEast().Build()));
    }

    [Test]
    public void Facing_South_Rotate_Right()
    {
        var rover = ARover().FacingSouth().Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(ARover().FacingWest().Build()));
    }

    [Test]
    public void Facing_West_Rotate_Left()
    {
        var rover = ARover().FacingWest().Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(ARover().FacingSouth().Build()));
    }

    [Test]
    public void Facing_West_Rotate_Right()
    {
        var rover = ARover().FacingWest().Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(ARover().FacingNorth().Build()));
    }

    [Test]
    public void Facing_East_Rotate_Left()
    {
        var rover = ARover().FacingEast().Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(ARover().FacingNorth().Build()));
    }

    [Test]
    public void Facing_East_Rotate_Right()
    {
        var rover = ARover().FacingEast().Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(ARover().FacingSouth().Build()));
    }
}