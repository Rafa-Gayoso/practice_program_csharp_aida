using NUnit.Framework;
using static MarsRover.Tests.NasaRoverBuilder;

namespace MarsRover.Tests;

public class RoverEqualityTest
{
    private NasaRoverBuilder _roverFacingNorth;

    [SetUp]
    public void Initialize()
    {
        _roverFacingNorth = ARover().FacingNorth().WithCoordinates(1, 1);
    }

    [Test]
    public void Equal_Rovers()
    {
        Assert.That(_roverFacingNorth.Build(), Is.EqualTo(_roverFacingNorth.Build()));
    }

    [Test]
    public void Not_Equal_Rovers()
    {
        Assert.That(
            _roverFacingNorth.Build(),
            Is.Not.EqualTo(ARover().FacingSouth().Build()));

        Assert.That(
            _roverFacingNorth.Build(),
            Is.Not.EqualTo(ARover().FacingNorth().WithCoordinates(1, 2).Build()));

        Assert.That(
            _roverFacingNorth.Build(),
            Is.Not.EqualTo(ARover().FacingNorth().WithCoordinates(0, 1).Build()));
    }
}