using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.communicationProtocols;

public class NasaCommunicationProtocol : CommunicationProtocol
{
    protected CommandExtractor _commandExtractor;

    public NasaCommunicationProtocol()
    {
        _commandExtractor = new FixedLengthCommandExtractor(1);
    }

    private Command CreateCommand(int displacement, string commandRepresentation)
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
        var commandRepresentations = _commandExtractor.Extract(commandsSequence);
        return commandRepresentations
            .Select(commandRepresentation => CreateCommand(displacement, commandRepresentation))
            .ToList();
    }
}