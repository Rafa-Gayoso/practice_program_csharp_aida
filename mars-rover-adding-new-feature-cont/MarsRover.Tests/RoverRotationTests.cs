using NUnit.Framework;
<<<<<<< HEAD
using static MarsRover.Tests.RoverBuilder;
=======
using static MarsRover.Tests.NasaRoverBuilder;
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e

namespace MarsRover.Tests;

public class RoverRotationTests
{
    [Test]
    public void Facing_North_Rotate_Left()
    {
<<<<<<< HEAD
        var rover = AnyRoverFacing("N");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("W")));
=======
        var rover = ARover().FacingNorth().Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(ARover().FacingWest().Build()));
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e
    }

    [Test]
    public void Facing_North_Rotate_Right()
    {
<<<<<<< HEAD
        var rover = AnyRoverFacing("N");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("E")));
=======
        var rover = ARover().FacingNorth().Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(ARover().FacingEast().Build()));
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e
    }

    [Test]
    public void Facing_South_Rotate_Left()
    {
<<<<<<< HEAD
        var rover = AnyRoverFacing("S");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("E")));
=======
        var rover = ARover().FacingSouth().Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(ARover().FacingEast().Build()));
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e
    }

    [Test]
    public void Facing_South_Rotate_Right()
    {
<<<<<<< HEAD
        var rover = AnyRoverFacing("S");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("W")));
=======
        var rover = ARover().FacingSouth().Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(ARover().FacingWest().Build()));
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e
    }

    [Test]
    public void Facing_West_Rotate_Left()
    {
<<<<<<< HEAD
        var rover = AnyRoverFacing("W");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("S")));
=======
        var rover = ARover().FacingWest().Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(ARover().FacingSouth().Build()));
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e
    }

    [Test]
    public void Facing_West_Rotate_Right()
    {
<<<<<<< HEAD
        var rover = AnyRoverFacing("W");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("N")));
=======
        var rover = ARover().FacingWest().Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(ARover().FacingNorth().Build()));
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e
    }

    [Test]
    public void Facing_East_Rotate_Left()
    {
<<<<<<< HEAD
        var rover = AnyRoverFacing("E");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("N")));
=======
        var rover = ARover().FacingEast().Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(ARover().FacingNorth().Build()));
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e
    }

    [Test]
    public void Facing_East_Rotate_Right()
    {
<<<<<<< HEAD
        var rover = AnyRoverFacing("E");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing("S")));
=======
        var rover = ARover().FacingEast().Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(ARover().FacingSouth().Build()));
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e
    }
}