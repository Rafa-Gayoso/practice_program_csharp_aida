using System.Collections.Generic;

namespace MarsRover;

public interface CommandInterpreter
{
    IEnumerable<string> GetCommands(string commandsSequence);
}