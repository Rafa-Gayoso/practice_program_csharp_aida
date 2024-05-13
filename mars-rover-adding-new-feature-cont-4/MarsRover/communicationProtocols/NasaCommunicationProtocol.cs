using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.communicationProtocols;

public class NasaCommunicationProtocol : CommunicationProtocolBase, CommunicationProtocol
{
    private readonly CommandExtractor _commandExtractor;

    public NasaCommunicationProtocol()
    {
        _commandExtractor = new FixedLengthCommandExtractor(1);
    }

    protected override Command CreateCommand(int displacement, string commandRepresentation)
    {
        return commandRepresentation switch
        {
            "l" => new RotationLeft(),
            "r" => new RotationRight(),
            "f" => new MovementForward(displacement),
            _ => new MovementBackward(displacement)
        };
    }

    public virtual List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        return GetCommands(commandsSequence, displacement, _commandExtractor);
    }
}