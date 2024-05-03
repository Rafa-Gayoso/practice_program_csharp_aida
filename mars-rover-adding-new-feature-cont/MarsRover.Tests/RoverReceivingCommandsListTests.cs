using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverReceivingCommandsListTests
{
    [Test]
    public void No_Commands()
    {
        var rover = CreateRoverAtInitialFacingTo("N");

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(CreateRoverAtInitialFacingTo( "N")));
    }

    [Test]
    public void Two_Commands()
    {
        var rover = CreateRoverAtInitialFacingTo( "N");

        rover.Receive("lf");

        Assert.That(rover, Is.EqualTo(ARover().WithCoordinates(-1,0).WithDirection("W").Build()));
    }

    [Test]
    public void Many_Commands()
    {
        var rover = CreateRoverAtInitialFacingTo( "N");

        rover.Receive("ffrbbrfflff");

        Assert.That(rover, Is.EqualTo(CreateRoverAtInitialFacingTo( "E")));
    }
}