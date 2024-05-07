using System.Collections.Generic;
using System.Linq;

namespace MarsRover.communicationProtocols;

public abstract class CommunicationProtocolBase
{
    public List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        return commandsSequence
            .Select(char.ToString)
            .Select<string, Command>(commandRepresentation => 
                CreateCommand(displacement, commandRepresentation))
            .ToList();
    }

    protected abstract Command CreateCommand(int displacement, string commandRepresentation);
}