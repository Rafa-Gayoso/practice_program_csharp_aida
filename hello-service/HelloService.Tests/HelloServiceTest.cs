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

        [Test]
        public void greet_with_good_night()
        {
            _service.Hello();

            _notifier.Received(1).Notify("Buenas noches!");
        }

        [Test]
        public void greet_with_good_morning()
        {
            _dateProvider.GetTime().Returns(new TimeOnly(8, 0, 0));

            _service.Hello();

            _notifier.Received(1).Notify("Buenos dias!");
        }
    }
}