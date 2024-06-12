using NSubstitute;
using NUnit.Framework;

namespace StockBroker.Tests
{
    public class OrderSummaryPresenterTest
    {
        private Notifier _notifier;
        private OrderSummaryPresenter _presenter;
        private DateOnly _orderDate;

        [SetUp]
        public void SetUp()
        {
            _notifier = Substitute.For<Notifier>();
            _orderDate = new DateOnly(2024, 6, 12);
            _presenter = new OrderSummaryPresenter(_notifier);
        }
        
        [Test]
        public void print_no_orders_summary()
        {
            _presenter.Present(new OrdersSummary(_orderDate, 0, 0));

            _notifier.Received(1).Notify($"{_orderDate} Buy: € 0.00, Sell: € 0.00");
        }

        [Test]
        public void print_orders_summary_with_stock_bought()
        {
            _presenter.Present(new OrdersSummary(_orderDate, 59.6m, 0m));

            _notifier.Received(1).Notify($"{_orderDate} Buy: € 59.60, Sell: € 0.00");
        }

        [Test]
        public void print_orders_summary_with_stock_sold()
        {
            _presenter.Present(new OrdersSummary(_orderDate, 0m, 12.5m));

            _notifier.Received(1).Notify($"{_orderDate} Buy: € 0.00, Sell: € 12.50");
        }
    }
}