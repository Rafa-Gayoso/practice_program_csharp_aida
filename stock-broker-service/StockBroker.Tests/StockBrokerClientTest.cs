using NSubstitute;
using NUnit.Framework;
using System.Globalization;

namespace StockBroker.Tests
{
    public class StockBrokerClientTest
    {
        private Calendar _calendar;
        private Notifier _notifier;
        private StockBrokerOnlineService _stockBrokerOnlineService;
        private StockBrokerClient _client;
        private DateOnly _date;
        private Presenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _calendar = Substitute.For<Calendar>();
            _notifier = Substitute.For<Notifier>();
            _stockBrokerOnlineService = Substitute.For<StockBrokerOnlineService>();
            _presenter = Substitute.For<Presenter>();
            _client = new StockBrokerClient(_presenter, _calendar, _stockBrokerOnlineService);
            _date = new DateOnly(2024, 6, 11);
        }

        [Test]
        public void place_an_empty_order_sequence()
        {
            _calendar.GetDate().Returns(_date);

            _client.PlaceOrders(string.Empty);

            PresenterReceived(new OrdersSummary(_date, 0m, 0m));
        }

        [Test]
        public void place_a_single_buy_order_of_several_stocks()
        {
            _calendar.GetDate().Returns(_date);

            _client.PlaceOrders("GOOG 300 829.08 B");

            PresenterReceived(new OrdersSummary(_date, 248724.00m, 0m));
        }

        [Test]
        public void place_a_multiple_buy_order_of_several_stocks()
        {
            _calendar.GetDate().Returns(_date);

            _client.PlaceOrders("GOOG 2 2.2 B,AAPL 5 10.5 B");

            PresenterReceived(new OrdersSummary(_date, 56.90m, 0m));
        }

        [Test]
        public void place_a_single_sell_order_of_several_stocks()
        {
            _calendar.GetDate().Returns(_date);

            _client.PlaceOrders("GOOG 2 2.2 S");

            PresenterReceived(new OrdersSummary(_date, 0m, 4.40m));
        }

        private void PresenterReceived(OrdersSummary receivedOrderSummary)
        {
            _presenter.Received(1).Present(Arg.Any<OrdersSummary>());
            _presenter.Received(1).Present(receivedOrderSummary);
        }
    }
}