using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;

namespace MarsRover.communicationProtocols;

public class CNSACommunicationProtocol : CommunicationProtocol
{
    private readonly CommandInterpreter _commandInterpreter;

    public CNSACommunicationProtocol(CommandInterpreter commandInterpreter)
    {
        _commandInterpreter = commandInterpreter;
    }

    public List<Command> CreateCommands(string commandsSequence, int displacement)
    {

        if (commandsSequence == "")
        {
            return new List<Command>();
        }

       return _commandInterpreter.GetCommands(commandsSequence).Select(c => CreateCommand(c, displacement)).ToList();
    }

    private Command CreateCommand(string commandsSequence, int displacement)
    {
        Command command = new MovementBackward(displacement);

        command = commandsSequence switch
        {
            "bx" => new MovementForward(displacement),
            "ah" => new RotationLeft(),
            "pl" => new RotationRight(),
            _ => command
        };
        return command;
    }
}