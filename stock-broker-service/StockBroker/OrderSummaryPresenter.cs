namespace StockBroker
{
    public class OrderSummaryPresenter : Presenter
    {
        private readonly Notifier _notifier;
        private readonly Formatter _formatter;

        public OrderSummaryPresenter(Notifier notifier)
        {
            _notifier = notifier;
            _formatter = new Formatter();
        }

        public void Present(OrderSummary orderSummary)
        {
            _notifier.Notify($"{orderSummary.Date()} Buy: € " +
                             $"{_formatter.FormatAmount(orderSummary.BoughtAmount())}, " +
                             $"Sell: € {_formatter.FormatAmount(orderSummary.SoldAmount())}");
        }
    }
}
