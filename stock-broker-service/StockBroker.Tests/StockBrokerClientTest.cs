using NSubstitute;
using NUnit.Framework;
using System.Globalization;

namespace StockBroker.Tests
{
    public class StockBrokerClientTest
    {
        private DateProvider _dateProvider;
        private Notifier _notifier;
        private StockBrokerOnlineService _stockBrokerOnlineService;
        private StockBrokerClient _client;
        private DateOnly _date;

        [SetUp]
        public void SetUp()
        {
            _dateProvider = Substitute.For<DateProvider>();
            _notifier = Substitute.For<Notifier>();
            _stockBrokerOnlineService = Substitute.For<StockBrokerOnlineService>();
            _client = new StockBrokerClient(_notifier, _dateProvider, _stockBrokerOnlineService);
            _date = new DateOnly(2024, 6, 11);
        }

        [Test]
        public void notify_not_buy_or_sell_orders()
        {
            _dateProvider.GetDate().Returns(_date);

            _client.PlaceOrders(string.Empty);

            _notifier.Received(1).Notify(Arg.Any<string>());
            _notifier.Received(1).Notify($"{_date.ToString("d", new CultureInfo("en-US"))} Buy: € 0.00, Sell: € 0.00");
        }

        [Test]
        public void notify_quantity_bought_for_a_single_order()
        {
            var ordersSequence = "GOOG 300 829.08 B";
            _dateProvider.GetDate().Returns(_date);
            _stockBrokerOnlineService.Execute(ordersSequence).Returns(true);

            _client.PlaceOrders(ordersSequence);

            _notifier.Received(1).Notify(Arg.Any<string>());
            _notifier.Received(1).Notify($"{_date.ToString("d", new CultureInfo("en-US"))} Buy: € 248724,00, Sell: € 0,00");
        }

        [Test]
        public void notify_quantity_bought_for_multiple_order()
        {
            var ordersSequence = "GOOG 2 2.2 B,AAPL 5 10.5 B";
            _dateProvider.GetDate().Returns(_date);
            _stockBrokerOnlineService.Execute(ordersSequence).Returns(true);

            _client.PlaceOrders(ordersSequence);

            _notifier.Received(1).Notify(Arg.Any<string>());
            _notifier.Received(1).Notify($"{_date.ToString("d", new CultureInfo("en-US"))} Buy: € 56,90, Sell: € 0,00");
        }
    }
}