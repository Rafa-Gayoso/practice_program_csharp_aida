using System;
using System.Collections.Generic;
using System.Globalization;

namespace StockBroker;

public class StockBrokerClient
{
    private const char OrderSequenceSeparator = ',';
    private const string OrderDataSeparator = " ";
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
        var amountPurchased = 0m;
        var amountSelled = 0m;
        var processOrdersDate = _dateProvider.GetDate();

        if (string.IsNullOrEmpty(ordersSequence))
        {
            _notifier.Notify($"{processOrdersDate.ToString("d", new CultureInfo("en-US"))} Buy: € 0.00, Sell: € 0.00");
            return;
        }

        var splitOrders = ordersSequence.Split(OrderSequenceSeparator);

        foreach (var order in splitOrders)
        {
            var orderData = order.Split(OrderDataSeparator);
            var orderQuantity = int.Parse(orderData[1]);
            var orderValue = Convert.ToDecimal(orderData[2], new CultureInfo("en-US"));
            var orderOperation = (OrderOperation)Enum.Parse(typeof(OrderOperation), orderData[^1]);
            _stockBrokerOnlineService.Execute(ordersSequence);

            if (orderOperation == OrderOperation.B)
            {
                amountPurchased += orderQuantity * orderValue;
            }
        }

        _notifier.Notify($"{processOrdersDate.ToString("d", new CultureInfo("en-US"))} " +
                         $"Buy: € {amountPurchased.ToString("F")}, Sell: € 0,00");
    }
}