using System.Globalization;

namespace StockBroker;

public class StockBrokerClient
{
    private const char OrderSequenceSeparator = ',';

    private readonly Notifier _notifier;
    private readonly DateProvider _dateProvider;
    private readonly StockBrokerOnlineService _stockBrokerOnlineService;
    private readonly OrderCreator _orderCreator;

    public StockBrokerClient(Notifier notifier, DateProvider dateProvider, StockBrokerOnlineService stockBrokerOnlineService)
    {
        _notifier = notifier;
        _dateProvider = dateProvider;
        _stockBrokerOnlineService = stockBrokerOnlineService;
        _orderCreator = new OrderCreator();
    }

    public void PlaceOrders(string ordersSequence)
    {
        
        var processOrdersDate = _dateProvider.GetDate();

        if (string.IsNullOrEmpty(ordersSequence))
        {
            _notifier.Notify($"{processOrdersDate.ToString("d", new CultureInfo("en-US"))} Buy: € 0.00, Sell: € 0.00");
            return;
        }

        var amountPurchased = 0m;
        var amountSold = 0m;
        
        var splitOrders = ordersSequence.Split(OrderSequenceSeparator);
        _stockBrokerOnlineService.Execute(ordersSequence);

        foreach (var order in splitOrders)
        {
            var parsedOrder = _orderCreator.Create(order);

            if (parsedOrder.Operation == OrderOperation.B)
            {
                amountPurchased += parsedOrder.CalculateOrderAmount();
            }
            else
            {
                amountSold += parsedOrder.CalculateOrderAmount();
            }
        }

        _notifier.Notify($"{processOrdersDate.ToString("d", new CultureInfo("en-US"))} " +
                         $"Buy: € {FormatAmount(amountPurchased)}, Sell: € {FormatAmount(amountSold)}");
    }

    private static string FormatAmount(decimal amount)
    {
        return amount.ToString("F");
    }
}