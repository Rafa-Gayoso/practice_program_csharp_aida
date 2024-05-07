using System.Collections.Generic;
using System.Linq;

namespace MarsRover.commandInterpreters;

public class OneCharSeparatorCommandInterpreter : CommandInterpreter
{
    public IEnumerable<string> GetCommands(string commandsSequence)
    {
        return commandsSequence.Select(char.ToString);
    }
}