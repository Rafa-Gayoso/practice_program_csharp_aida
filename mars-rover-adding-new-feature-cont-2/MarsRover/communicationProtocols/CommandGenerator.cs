using System.Collections.Generic;

namespace MarsRover.communicationProtocols;

public interface CommandGenerator
{
    IEnumerable<string> GetCommands(string commandsSequence);
}