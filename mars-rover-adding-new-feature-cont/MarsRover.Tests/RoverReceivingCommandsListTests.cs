using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverReceivingCommandsListTests
{
    [Test]
    public void No_Commands()
    {
        var rover = AnyRoverFacing("N");

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing( "N")));
    }

    [Test]
    public void Two_Commands()
    {
        var rover = AnyRoverFacing( "N");

        rover.Receive("lf");

        var expected = ARover().WithCoordinates(-1,0).Facing("W").Build();
        Assert.That(rover, Is.EqualTo(expected));
    }

    [Test]
    public void Many_Commands()
    {
        var rover = AnyRoverFacing( "N");

        rover.Receive("ffrbbrfflff");

        Assert.That(rover, Is.EqualTo(AnyRoverFacing( "E")));
    }
}