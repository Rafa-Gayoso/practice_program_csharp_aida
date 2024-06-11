using NSubstitute;
using NUnit.Framework;

namespace Hello.Tests
{
    public class HelloServiceTest
    {
        private Notifier _notifier;
        private TimeProvider _dateProvider;

        private HelloService _service;

        [SetUp]
        public void Setup()
        {
            _notifier = Substitute.For<Notifier>();
            _dateProvider = Substitute.For<TimeProvider>();
            _service = new HelloService(_notifier, _dateProvider);
        }

        [TestCase(20, 0)]
        [TestCase(0, 0)]
        [TestCase(5, 59)]
        public void greet_with_good_night(int hour, int minutes)
        {
            _dateProvider.GetTimeOfTheDay().Returns(new TimeOnly(hour, minutes));

            _service.Hello();

            _notifier.Received(1).Notify(Arg.Any<string>());
            _notifier.Received(1).Notify("Buenas noches!");
        }

        [TestCase(6,0)]
        [TestCase(8, 0)]
        [TestCase(11, 59)]
        public void greet_with_good_morning(int hour, int minutes)
        {
            _dateProvider.GetTimeOfTheDay().Returns(new TimeOnly(hour, minutes));

            _service.Hello();

            _notifier.Received(1).Notify(Arg.Any<string>());
            _notifier.Received(1).Notify("Buenos dias!");
        }

        [TestCase(12, 1)]
        [TestCase(15, 0)]
        [TestCase(19, 59)]
        public void greet_with_good_evening(int hour, int minutes)
        {
            _dateProvider.GetTimeOfTheDay().Returns(new TimeOnly(hour, minutes));

            _service.Hello();

            _notifier.Received(1).Notify(Arg.Any<string>());
            _notifier.Received(1).Notify("Buenas tardes!");
        }
    }
}