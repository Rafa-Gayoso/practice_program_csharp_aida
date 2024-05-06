namespace MarsRover.Tests;

internal class RoverBuilder
{
    private string direction = string.Empty;
    private int x = 0;
    private int y = 0;

    public static RoverBuilder ARover()
    {
        return new RoverBuilder();
    }

    public RoverBuilder Facing(string direction)
    {
        this.direction = direction;
        return this;
    }
    public RoverBuilder FacingNorth()
    {
        direction = "N";
        return this;
    }

    public RoverBuilder FacingSouth()
    {
        direction = "S";
        return this;
    }

    public RoverBuilder FacingEast()
    {
        direction = "E";
        return this;
    }

    public RoverBuilder FacingWest()
    {
        direction = "W";
        return this;
    }

    public RoverBuilder WithCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
        return this;
    }

    public Rover Build()
    {
        return new Rover(x, y, direction);
    }

    public static Rover RoverFacing(string direction)
    {
        return ARover().Facing(direction).Build();
    }

    
}