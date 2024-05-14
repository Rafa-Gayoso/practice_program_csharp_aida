namespace MarsRover.Tests;

internal class NasaRoverBuilder
{
    private string direction = string.Empty;
    private int x = 0;
    private int y = 0;

    public static NasaRoverBuilder ARover()
    {
        return new NasaRoverBuilder();
    }

    public NasaRoverBuilder Facing(string direction)
    {
        this.direction = direction;
        return this;
    }
    public NasaRoverBuilder FacingNorth()
    {
        direction = "N";
        return this;
    }

    public NasaRoverBuilder FacingSouth()
    {
        direction = "S";
        return this;
    }

    public NasaRoverBuilder FacingEast()
    {
        direction = "E";
        return this;
    }

    public NasaRoverBuilder FacingWest()
    {
        direction = "W";
        return this;
    }

    public NasaRoverBuilder WithCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
        return this;
    }

    public Rover Build()
    {
        return new Rover(x, y, direction);
    }

    public Rover Build(CommunicationProtocol communicationProtocol)
    {
        return new Rover(x, y, direction, communicationProtocol);
    }

    public static Rover RoverFacing(string direction)
    {
        return ARover().Facing(direction).Build();
    }

    
}