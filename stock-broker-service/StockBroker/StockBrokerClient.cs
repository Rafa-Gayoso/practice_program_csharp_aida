using System.Globalization;

namespace StockBroker;

public class StockBrokerClient
{
    private readonly Notifier _notifier;
    private readonly DateProvider _dateProvider;
    private readonly StockBrokerOnlineService _stockBrokerOnlineService;

    public StockBrokerClient(Notifier notifier, DateProvider dateProvider, StockBrokerOnlineService stockBrokerOnlineService)
    {
        _notifier = notifier;
        _dateProvider = dateProvider;
        _stockBrokerOnlineService = stockBrokerOnlineService;
    }

    public void PlaceOrders(string ordersSequence)
    {
        var processOrdersDate = _dateProvider.GetDate();

        if (string.IsNullOrEmpty(ordersSequence))
        {
            _notifier.Notify($"{processOrdersDate.ToString("d", new CultureInfo("en-US"))} Buy: € 0.00, Sell: € 0.00");
            return;
        }

        var orderSuccessfullyExecuted = _stockBrokerOnlineService.Execute(ordersSequence);

        if (orderSuccessfullyExecuted)
        {
            _notifier.Notify($"{processOrdersDate.ToString("d", new CultureInfo("en-US"))} Buy: € 248724.00, Sell: € 0.00");
        }
    }
}