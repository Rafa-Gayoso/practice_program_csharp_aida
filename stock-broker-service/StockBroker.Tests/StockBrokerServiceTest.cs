using NSubstitute;
using NUnit.Framework;
using System.Globalization;

namespace StockBroker.Tests
{
    public class StockBrokerServiceTest
    {
        [Test]
        public void notify_not_buy_or_sell_orders()
        {
            var dateProvider = Substitute.For<DateProvider>();
            var notifier = Substitute.For<Notifier>();
            var service = new StockBrokerService(notifier, dateProvider);
            var date = new DateOnly(2024,6,11);
            dateProvider.GetDate().Returns(date);

            service.PlaceOrders(string.Empty);

            notifier.Received(1).Notify(Arg.Any<string>());
            notifier.Received(1).Notify($"{date.ToString("d", new CultureInfo("en-US"))} Buy: € 0.00, Sell: € 0.00");
        }
    }
}