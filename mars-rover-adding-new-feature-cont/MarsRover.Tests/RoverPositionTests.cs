using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverPositionTests
{
    [Test]
    public void Facing_North_Move_Forward()
    {
         
        var rover = ARover().FacingNorth().WithCoordinates(0,0).Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(ARover().FacingNorth().WithCoordinates(0,1).Build()));
    }

    [Test]
    public void Facing_North_Move_Backward()
    {
        var rover = ARover().FacingNorth().WithCoordinates(0, 0).Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(ARover().FacingNorth().WithCoordinates(0, -1).Build()));
    }

    [Test]
    public void Facing_South_Move_Forward()
    {
        var rover = ARover().FacingSouth().WithCoordinates(0, 0).Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(ARover().FacingSouth().WithCoordinates(0, -1).Build()));
    }

    [Test]
    public void Facing_South_Move_Backward()
    {
        var rover = ARover().FacingSouth().WithCoordinates(0, 0).Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(ARover().FacingSouth().WithCoordinates(0, 1).Build()));
    }

    [Test]
    public void Facing_West_Move_Forward()
    {
        var rover = ARover().FacingWest().WithCoordinates(0, 0).Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(ARover().FacingWest().WithCoordinates(-1, 0).Build()));
    }

    [Test]
    public void Facing_West_Move_Backward()
    {
        var rover = ARover().FacingWest().WithCoordinates(0, 0).Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(ARover().FacingWest().WithCoordinates(1, 0).Build()));
    }

    [Test]
    public void Facing_East_Move_Forward()
    {
        var rover = ARover().FacingEast().WithCoordinates(0, 0).Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(ARover().FacingEast().WithCoordinates(1, 0).Build()));
    }

    [Test]
    public void Facing_East_Move_Backward()
    {
        var rover = ARover().FacingEast().WithCoordinates(0, 0).Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(ARover().FacingEast().WithCoordinates(-1, 0).Build()));
    }
}