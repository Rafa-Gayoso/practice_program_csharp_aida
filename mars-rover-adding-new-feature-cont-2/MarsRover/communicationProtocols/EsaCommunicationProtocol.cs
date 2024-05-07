using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;

namespace MarsRover.communicationProtocols;

public class EsaCommunicationProtocol : CommunicationProtocolBase
{
    protected override Command CreateCommand(int displacement, string commandRepresentation)
    {
        switch (commandRepresentation)
        {
            case "b":
                return new MovementForward(displacement);
            case "x":
                return new MovementBackward(displacement);
            case "f":
                return new RotationLeft();
            default:
                return new RotationRight();
        }
    }
}