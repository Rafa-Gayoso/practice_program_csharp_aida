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
        public void notify_not_buy_or_sell_orders()
        {
            _client = new StockBrokerClient(_presenter, _calendar, _stockBrokerOnlineService);
            _calendar.GetDate().Returns(_date);

            _client.PlaceOrders(string.Empty);

            _presenter.Received(1).Present(Arg.Any<OrderSummary>());
            _presenter.Received(1).Present(new OrderSummary(_date, 0m, 0m));
        }

        [Test]
        public void notify_quantity_bought_for_a_single_order()
        {
            var ordersSequence = "GOOG 300 829.08 B";
            _calendar.GetDate().Returns(_date);
            _stockBrokerOnlineService.Execute(ordersSequence).Returns(true);

            _client.PlaceOrders(ordersSequence);

            _presenter.Received(1).Present(Arg.Any<OrderSummary>());
            _presenter.Received(1).Present(new OrderSummary(_date, 248724.00m, 0m));
        }

        [Test]
        public void notify_quantity_bought_for_multiple_order()
        {
            var ordersSequence = "GOOG 2 2.2 B,AAPL 5 10.5 B";
            _calendar.GetDate().Returns(_date);
            _stockBrokerOnlineService.Execute(ordersSequence).Returns(true);

            _client.PlaceOrders(ordersSequence);

            _presenter.Received(1).Present(Arg.Any<OrderSummary>());
            _presenter.Received(1).Present(new OrderSummary(_date, 56.90m, 0m));
        }

        [Test]
        public void notify_quantity_selled_for_a_single_order()
        {
            var ordersSequence = "GOOG 2 2.2 S";
            _calendar.GetDate().Returns(_date);
            _stockBrokerOnlineService.Execute(ordersSequence).Returns(true);

            _client.PlaceOrders(ordersSequence);


            _presenter.Received(1).Present(Arg.Any<OrderSummary>());
            _presenter.Received(1).Present(new OrderSummary(_date, 0m, 4.40m));
        }
    }
}