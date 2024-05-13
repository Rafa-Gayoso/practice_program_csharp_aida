using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.communicationProtocols;

public class CnsaCommunicationProtocol : CommunicationProtocol
{
    protected CommandExtractor _commandExtractor;

    public CnsaCommunicationProtocol()
    {
        _commandExtractor = new FixedLengthCommandExtractor(2);
    }

    private Command CreateCommand(int displacement, string commandRepresentation)
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
        var commandRepresentations = _commandExtractor.Extract(commandsSequence);
        return commandRepresentations
            .Select(commandRepresentation => CreateCommand(displacement, commandRepresentation))
            .ToList();
    }
}