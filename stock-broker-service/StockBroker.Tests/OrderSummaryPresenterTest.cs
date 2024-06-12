using NSubstitute;
using NUnit.Framework;

namespace StockBroker.Tests
{
    public class OrderSummaryPresenterTest
    {
        
        [Test]
        public void print_no_orders_summary()
        {
            var notifier = Substitute.For<Notifier>();
            Presenter presenter = new OrderSummaryPresenter(notifier);
            var orderDate = new DateOnly(2024, 6, 12);

            presenter.Present(new OrderSummary(orderDate, 0, 0));

            notifier.Received(1).Notify($"{orderDate} Buy: € 0.00, Sell: € 0.00");
        }

        [Test]
        public void print_orders_summary_with_stock_bought()
        {
            var notifier = Substitute.For<Notifier>();
            Presenter presenter = new OrderSummaryPresenter(notifier);
            var orderDate = new DateOnly(2024, 6, 12);

            presenter.Present(new OrderSummary(orderDate, 59.6m, 0m));

            notifier.Received(1).Notify($"{orderDate} Buy: € 59.60, Sell: € 0.00");
        }
    }
}