using System.Collections.Generic;
using System.Linq;

namespace MarsRover.communicationProtocols;

public abstract class CommunicationProtocolBase
{
    protected abstract Command CreateCommand(int displacement, string commandRepresentation);

    protected List<Command> GetCommands(string commandsSequence, int displacement, CommandExtractor commandExtractor)
    {
        var commandRepresentations = commandExtractor.Extract(commandsSequence);
        return commandRepresentations
            .Select(commandRepresentation => CreateCommand(displacement, commandRepresentation))
            .ToList();
    }
}