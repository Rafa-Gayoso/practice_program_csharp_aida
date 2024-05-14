using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.communicationProtocols;

public class JaxaCommunicationProtocol : CommunicationProtocolForAgency,  CommunicationProtocol
{
    protected CommandExtractor _commandExtractor;

    public JaxaCommunicationProtocol()
    {
        _commandExtractor = new JaxaCommandExtractor();
    }

    protected override Command CreateCommand(int displacement, string commandRepresentation)
    {
        if (commandRepresentation == "at") return new MovementBackward(displacement);

        if (commandRepresentation == "iz") return new RotationLeft();

        if (commandRepresentation == "der") return new RotationRight();

        return new MovementForward(displacement);
    }

    public virtual List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        return GetCommands(commandsSequence, displacement, _commandExtractor);
    }
}