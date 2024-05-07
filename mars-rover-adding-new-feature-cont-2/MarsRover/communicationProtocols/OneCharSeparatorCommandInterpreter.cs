using System.Collections.Generic;
using System.Linq;

namespace MarsRover.communicationProtocols;

public class OneCharSeparatorCommandInterpreter
{
    public IEnumerable<string> GetCommands(string commandsSequence)
    {
        return commandsSequence.Select(char.ToString);
    }
}