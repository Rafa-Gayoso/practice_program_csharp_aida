using System;

namespace StockBroker;

public interface Calendar
{
    DateOnly GetDate();
}