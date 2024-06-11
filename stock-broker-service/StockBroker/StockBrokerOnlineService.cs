namespace StockBroker;

public interface StockBrokerOnlineService
{
    bool Execute(string order);
}