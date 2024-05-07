using System.Collections.Generic;
using System.Linq;

namespace MarsRover.commandInterpreters;

public class TwoCharSeparatorCommandInterpreter : CommandInterpreter
{
    public IEnumerable<string> GetCommands(string commandsSequence)
    {
        return commandsSequence.Chunk(2).Select(c => new string(c));
    }
}