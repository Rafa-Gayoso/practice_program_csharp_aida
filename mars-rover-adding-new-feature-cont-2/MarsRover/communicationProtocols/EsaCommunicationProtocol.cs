using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;

namespace MarsRover.communicationProtocols;

public class EsaCommunicationProtocol : CommunicationProtocol
{
    private OneCharSeparatorCommandInterpreter _commandGenerator;

    public EsaCommunicationProtocol()
    {
        _commandGenerator = new OneCharSeparatorCommandInterpreter();
    }

    public List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        return _commandGenerator.GetCommands(commandsSequence)
            .Select(commandRepresentation => CreateCommand(displacement, commandRepresentation))
            .ToList();
    }

    private Command CreateCommand(int displacement, string commandRepresentation)
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