using MarsRover.commands;

namespace MarsRover.communicationProtocols;

public class NasaCommunicationProtocol : CommunicationProtocolBase
{

    protected override Command CreateCommand(int displacement, string commandRepresentation)
    {
        switch (commandRepresentation)
        {
            case "l":
                return new RotationLeft();
            case "r":
                return new RotationRight();
            case "f":
                return new MovementForward(displacement);
            default:
                return new MovementBackward(displacement);
        }
    }
}