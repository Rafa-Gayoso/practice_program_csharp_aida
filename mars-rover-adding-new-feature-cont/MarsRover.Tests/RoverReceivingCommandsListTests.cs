using NUnit.Framework;
<<<<<<< HEAD
using static MarsRover.Tests.RoverBuilder;
=======
using static MarsRover.Tests.NasaRoverBuilder;
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e

namespace MarsRover.Tests;

public class RoverReceivingCommandsListTests
{
    [Test]
    public void No_Commands()
    {
<<<<<<< HEAD
        var rover = AnyRoverFacing("N");

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing( "N")));
=======
        var rover = ARover().Build();

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(ARover().Build()));
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e
    }

    [Test]
    public void Two_Commands()
    {
<<<<<<< HEAD
        var rover = AnyRoverFacing( "N");

        rover.Receive("lf");

        var expected = ARover().WithCoordinates(-1,0).Facing("W").Build();
        Assert.That(rover, Is.EqualTo(expected));
=======
        var rover = ARover().FacingNorth().WithCoordinates(0,0).Build();

        rover.Receive("lf");

        Assert.That(rover, Is.EqualTo(ARover().FacingWest().WithCoordinates(-1, 0).Build()));
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e
    }

    [Test]
    public void Many_Commands()
    {
<<<<<<< HEAD
        var rover = AnyRoverFacing( "N");

        rover.Receive("ffrbbrfflff");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing( "E")));
=======
        var rover = ARover().FacingNorth().WithCoordinates(0, 0).Build();

        rover.Receive("ffrbbrfflff");

        Assert.That(rover, Is.EqualTo(ARover().FacingEast().WithCoordinates(0, 0).Build()));
>>>>>>> 731ca3deff4df30e4390bf8afea2e3fc4cd79d9e
    }
}