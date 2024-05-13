using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.communicationProtocols;

public class CnsaCommunicationProtocol : CommunicationProtocolBase, CommunicationProtocol
{
    protected CommandExtractor _commandExtractor;

    public CnsaCommunicationProtocol()
    {
        _commandExtractor = new FixedLengthCommandExtractor(2);
    }

    protected override Command CreateCommand(int displacement, string commandRepresentation)
    {
        return commandRepresentation switch
        {
            "bx" => new MovementForward(displacement),
            "tf" => new MovementBackward(displacement),
            "ah" => new RotationLeft(),
            _ => new RotationRight()
        };
    }

    public virtual List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        return GetCommands(commandsSequence, displacement, _commandExtractor);
    }
}