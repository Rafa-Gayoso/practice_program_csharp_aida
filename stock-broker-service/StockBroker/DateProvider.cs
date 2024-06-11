using System;

namespace StockBroker;

public interface DateProvider
{
    DateOnly GetDate();
}