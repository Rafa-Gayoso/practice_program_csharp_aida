using System.Globalization;

namespace StockBroker;

public class StockBrokerService
{
    private readonly Notifier _notifier;
    private readonly DateProvider _dateProvider;

    public StockBrokerService(Notifier notifier, DateProvider dateProvider)
    {
        _notifier = notifier;
        _dateProvider = dateProvider;
    }

    public void PlaceOrders(string ordersSequence)
    {
        var processOrdersDate = _dateProvider.GetDate();

        _notifier.Notify($"{processOrdersDate.ToString("d", new CultureInfo("en-US"))} Buy: € 0.00, Sell: € 0.00");
    }
}