using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.communicationProtocols;

namespace MarsRover;

public interface CommunicationProtocol
{
    List<Command> CreateCommands(string commandsSequence, int displacement);
}