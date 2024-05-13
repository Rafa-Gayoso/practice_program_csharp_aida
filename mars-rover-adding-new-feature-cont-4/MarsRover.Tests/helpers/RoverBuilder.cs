using MarsRover.communicationProtocols;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.Tests.helpers;

public class RoverBuilder
{
    private readonly CommunicationProtocol _communicationProtocol;
    private string _direction;
    private int _x;
    private int _y;

    private RoverBuilder(int x, int y, string direction, CommunicationProtocol communicationProtocol)
    {
        _x = x;
        _y = y;
        _direction = direction;
        _communicationProtocol = communicationProtocol;
    }

    public Rover Build()
    {
        return new Rover(_x, _y, _direction, _communicationProtocol);
    }

    public RoverBuilder Facing(string direction)
    {
        _direction = direction;
        return this;
    }

    public RoverBuilder WithCoordinates(int x, int y)
    {
        _x = x;
        _y = y;
        return this;
    }

    public static RoverBuilder NasaRover()
    {
        return new RoverBuilder(1, 0, "N", CommunicationProtocol.CreateNasaCommunicationProtocol());
    }

    public static RoverBuilder EsaRover()
    {
        return new RoverBuilder(0, 2, "N", CommunicationProtocol.CreateEsaCommunicationProtocol());
    }

    public static RoverBuilder CsnaRover()
    {
        return new RoverBuilder(3, 0, "N", CommunicationProtocol.CreateCnsaCommunicationProtocol());
    }

    public static RoverBuilder JaxaRover()
    {
        return new RoverBuilder(1, 1, "N", CommunicationProtocol.CreateJaxaCommunicationProtocol());
    }


    public static RoverBuilder JointRover()
    {
        return new RoverBuilder(1, 1, "N", new JointCommunicationProtocol());
    }
}