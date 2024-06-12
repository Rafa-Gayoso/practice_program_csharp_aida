using System;
using System.Globalization;

namespace StockBroker;

internal class OrderCreator
{
    private const string OrderDataSeparator = " ";

    public Order Create(string order)
    {
        var orderData = order.Split(OrderDataSeparator);
        var orderQuantity = int.Parse(orderData[1]);
        var orderValue = Convert.ToDecimal(orderData[2], new CultureInfo("en-US"));
        var orderOperation = (OrderOperation)Enum.Parse(typeof(OrderOperation), orderData[^1]);

        return new Order(orderQuantity, orderValue, orderOperation);
    }
}