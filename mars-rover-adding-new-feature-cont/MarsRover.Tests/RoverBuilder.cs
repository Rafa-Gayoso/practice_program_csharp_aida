namespace MarsRover.Tests;

internal class RoverBuilder
{
    private string _direction = "N";
    private int _axisY;
    private int _axisX;

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

    public Rover Build()
    {
        return new Rover(_axisX, _axisY, _direction);
    }

    public static RoverBuilder ARover()
    {
        return new RoverBuilder();
    }
}