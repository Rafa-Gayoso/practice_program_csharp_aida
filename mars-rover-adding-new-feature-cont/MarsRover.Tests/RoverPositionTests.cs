using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverPositionTests
{
    [Test]
    public void Facing_North_Move_Forward()
    {
         
        var rover = ARover().Facing("N").WithCoordinates(0,0).Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(ARover().Facing("N").WithCoordinates(0,1).Build()));
    }

    [Test]
    public void Facing_North_Move_Backward()
    {
        var rover = ARover().Facing("N").WithCoordinates(0, 0).Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(ARover().Facing("N").WithCoordinates(0, -1).Build()));
    }

    [Test]
    public void Facing_South_Move_Forward()
    {
        var rover = ARover().Facing("S").WithCoordinates(0, 0).Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(ARover().Facing("S").WithCoordinates(0, -1).Build()));
    }

    [Test]
    public void Facing_South_Move_Backward()
    {
        var rover = ARover().Facing("S").WithCoordinates(0, 0).Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(ARover().Facing("S").WithCoordinates(0, 1).Build()));
    }

    [Test]
    public void Facing_West_Move_Forward()
    {
        var rover = ARover().Facing("W").WithCoordinates(0, 0).Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(ARover().Facing("W").WithCoordinates(-1, 0).Build()));
    }

    [Test]
    public void Facing_West_Move_Backward()
    {
        var rover = ARover().Facing("W").WithCoordinates(0, 0).Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(ARover().Facing("W").WithCoordinates(1, 0).Build()));
    }

    [Test]
    public void Facing_East_Move_Forward()
    {
        var rover = ARover().Facing("E").WithCoordinates(0, 0).Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(ARover().Facing("E").WithCoordinates(1, 0).Build()));
    }

    [Test]
    public void Facing_East_Move_Backward()
    {
        var rover = ARover().Facing("E").WithCoordinates(0, 0).Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(ARover().Facing("E").WithCoordinates(-1, 0).Build()));
    }
}