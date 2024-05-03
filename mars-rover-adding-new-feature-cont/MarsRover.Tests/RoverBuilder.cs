namespace MarsRover.Tests;

internal class RoverBuilder
{
    private string _direction;
    private int _axisY;
    private int _axisX;

    private RoverBuilder(int x, int y, string direction)
    {
        _axisX = x;
        _axisY = y;
        _direction = direction;
    }

    public RoverBuilder Facing(string direction)
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
        return new RoverBuilder(0,0,"N");
    }

    public static Rover AnyRoverFacing(string direction)
    {
        return ARover().Facing(direction).Build();
    }
}