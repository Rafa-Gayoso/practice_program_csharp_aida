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

        public void Present(OrdersSummary ordersSummary)
        {
            _notifier.Notify($"{ordersSummary.Date()} Buy: € " +
                             $"{_formatter.FormatAmount(ordersSummary.BoughtAmount())}, " +
                             $"Sell: € {_formatter.FormatAmount(ordersSummary.SoldAmount())}");
        }
    }
}
