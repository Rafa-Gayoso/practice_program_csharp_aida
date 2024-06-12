using System.Globalization;

namespace StockBroker;

public class StockBrokerClient
{
    private const char OrderSequenceSeparator = ',';

    private readonly Calendar _calendar;
    private readonly StockBrokerOnlineService _stockBrokerOnlineService;
    private readonly OrderCreator _orderCreator;
    private readonly Presenter _presenter;

    public StockBrokerClient(Presenter presenter, Calendar calendar, StockBrokerOnlineService stockBrokerOnlineService)
    {
        _presenter = presenter;
        _calendar = calendar;
        _stockBrokerOnlineService = stockBrokerOnlineService;
        _orderCreator = new OrderCreator();
    }

    public void PlaceOrders(string ordersSequence)
    {
        
        var processOrdersDate = _calendar.GetDate();

        if (string.IsNullOrEmpty(ordersSequence))
        {
            _presenter.Present(new OrderSummary(_calendar.GetDate(), 0m, 0m));
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

        _presenter.Present(new OrderSummary(_calendar.GetDate(), amountPurchased, amountSold));
    }
}