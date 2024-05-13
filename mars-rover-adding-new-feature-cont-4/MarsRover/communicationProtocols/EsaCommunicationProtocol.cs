using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.communicationProtocols;

public class EsaCommunicationProtocol : CommunicationProtocol
{
    protected CommandExtractor _commandExtractor;

    public EsaCommunicationProtocol()
    {
        _commandExtractor = new FixedLengthCommandExtractor(1);
    }

    private Command CreateCommand(int displacement, string commandRepresentation)
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
        var commandRepresentations = _commandExtractor.Extract(commandsSequence);
        return commandRepresentations
            .Select(commandRepresentation => CreateCommand(displacement, commandRepresentation))
            .ToList();
    }
}