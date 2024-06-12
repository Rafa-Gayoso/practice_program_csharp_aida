using System.Globalization;

namespace StockBroker;

internal class Formatter
{
    public string FormatAmount(decimal amount)
    {
        return amount.ToString("0.00", new CultureInfo("en-US"));
    }
}