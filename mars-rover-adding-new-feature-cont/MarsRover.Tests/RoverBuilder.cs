namespace MarsRover.Tests;

internal class RoverBuilder
{
    private string _direction = "N";
    private int _axisY = 0;
    private int _axisX = 0;

    public RoverBuilder FacingNorth()
    {
        _direction = "N";
        return this;
    }

    public RoverBuilder WithDirection(string direction)
    {
        _direction = direction;
        return this;
    }

    public RoverBuilder WithCoordinates(int x, int y)
    {
        _axisX = x;
        _axisY = y;
        return this;
    }

    public Rover Build()
    {
        return new Rover(_axisX, _axisY, _direction);
    }

    public static RoverBuilder ARover()
    {
        return new RoverBuilder();
    }

    public static Rover CreateRoverAtInitialFacingTo(string direction)
    {
        return ARover().WithDirection(direction).Build();
    }
}