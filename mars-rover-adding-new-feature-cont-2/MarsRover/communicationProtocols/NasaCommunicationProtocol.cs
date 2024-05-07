using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;

namespace MarsRover.communicationProtocols;

public class NasaCommunicationProtocol : CommunicationProtocol
{
    private OneCharSeparatorCommandInterpreter _commandGenerator;

    public NasaCommunicationProtocol()
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