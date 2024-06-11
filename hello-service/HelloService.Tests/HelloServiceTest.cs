using NSubstitute;
using NUnit.Framework;

namespace Hello.Tests
{
    public class HelloServiceTest
    {
        [Test]
        public void greet_with_good_night()
        {
            var notifier = Substitute.For<Notifier>();
            var service = new HelloService(notifier);

            service.Hello();

            notifier.Received(1).Notify("Buenas noches!");
        }
    }
}