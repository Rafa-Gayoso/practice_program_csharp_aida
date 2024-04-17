using CoffeeMachineApp.core;
using CoffeeMachineApp.infrastructure;
using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachineApp.Tests.infrastructure
{
    public class CurrentCultureInfoMessageNotificatorTest
    {
        private const string SelectDrinkMessage = "Please, select a drink!";
        private CurrentCultureInfoMessageNotificator _messageNotificator;
        private DrinkMakerDriver _drinkMakerDriver;

        [SetUp]
        public void SetUp()
        {
            _drinkMakerDriver = Substitute.For<DrinkMakerDriver>();
        }

        [Test]
        public void Warns_The_User_When_No_Drink_Was_Selected()
        {
            _messageNotificator = new CurrentCultureInfoMessageNotificator(_drinkMakerDriver);

            _messageNotificator.NotifySelectDrink();

            _drinkMakerDriver.Received().Notify(Message.Create(SelectDrinkMessage));
        }

        [Test]
        public void Warns_The_User_When_No_Enough_Money()
        {
            var missingAmount = 0.3m;
            _messageNotificator = new CurrentCultureInfoMessageNotificator(_drinkMakerDriver);

            _messageNotificator.NotifyMissingAmount(missingAmount);

            _drinkMakerDriver.Received().Notify(Message.Create($"You are missing {missingAmount}"));
        }
    }
}
