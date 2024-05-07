using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;

namespace MarsRover.communicationProtocols;

public class EsaCommunicationProtocol : CommunicationProtocol
{
    private CommandInterpreter _commandInterpreter;

    public EsaCommunicationProtocol(CommandInterpreter commandInterpreter)
    {
        _commandInterpreter = commandInterpreter;
    }

    public List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        return _commandInterpreter.GetCommands(commandsSequence)
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