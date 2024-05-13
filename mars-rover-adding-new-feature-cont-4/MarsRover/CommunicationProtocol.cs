using MarsRover.communicationProtocols;
using System.Collections.Generic;
using MarsRover.communicationProtocols.agencyCommands;

namespace MarsRover;

public abstract class CommunicationProtocol
{
    public abstract List<Command> CreateCommands(string commandsSequence, int displacement);

    public static CommunicationProtocol CreateNasaCommunicationProtocol()
    {
        return new CommunicationProtocolForAgency(new NasaAgencyCommands());
    }

    public static CommunicationProtocol CreateEsaCommunicationProtocol()
    {
        return new CommunicationProtocolForAgency(new EsaAgencyCommands());
    }

    public static CommunicationProtocol CreateCnsaCommunicationProtocol()
    {
        return new CommunicationProtocolForAgency(new CnsaAgencyCommands());
    }

    public static CommunicationProtocol CreateJaxaCommunicationProtocol()
    {
        return new CommunicationProtocolForAgency(new JaxaAgencyCommands());
    }
}