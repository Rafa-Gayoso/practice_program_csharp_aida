using NUnit.Framework;
using static MarsRover.Tests.NasaRoverBuilder;

namespace MarsRover.Tests;

public class RoverReceivingCommandsListTests
{
    [Test]
    public void No_Commands()
    {
        var rover = ARover().Build();

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(ARover().Build()));
    }

    [Test]
    public void Two_Commands()
    {
        var rover = ARover().FacingNorth().WithCoordinates(0,0).Build();

        rover.Receive("lf");

        Assert.That(rover, Is.EqualTo(ARover().FacingWest().WithCoordinates(-1, 0).Build()));
    }

    [Test]
    public void Many_Commands()
    {
        var rover = ARover().FacingNorth().WithCoordinates(0, 0).Build();

        rover.Receive("ffrbbrfflff");

        Assert.That(rover, Is.EqualTo(ARover().FacingEast().WithCoordinates(0, 0).Build()));
    }
}