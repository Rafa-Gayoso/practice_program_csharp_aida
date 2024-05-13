using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.communicationProtocols;

public class EsaCommunicationProtocol : CommunicationProtocolBase, CommunicationProtocol
{
    protected CommandExtractor _commandExtractor;

    public EsaCommunicationProtocol()
    {
        _commandExtractor = new FixedLengthCommandExtractor(1);
    }

    protected override Command CreateCommand(int displacement, string commandRepresentation)
    {
        return commandRepresentation switch
        {
            "b" => new MovementForward(displacement),
            "x" => new MovementBackward(displacement),
            "f" => new RotationLeft(),
            _ => new RotationRight()
        };
    }

    public virtual List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        return GetCommands(commandsSequence, displacement, _commandExtractor);
    }
}