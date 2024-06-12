using System.Globalization;

namespace StockBroker
{
    public class OrderSummaryPresenter : Presenter
    {
        private readonly Notifier _notifier;

        public OrderSummaryPresenter(Notifier notifier)
        {
            _notifier = notifier;
        }

        public void Present(OrderSummary orderSummary)
        {
            _notifier.Notify($"{orderSummary.Date()} Buy: € {orderSummary.BoughtAmount().ToString("0.00", new CultureInfo("en-US"))}, Sell: € 0.00");
        }
    }
}
