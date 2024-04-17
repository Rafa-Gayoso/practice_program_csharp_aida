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

        [Test]
        public void Warns_The_User_When_No_Drink_Was_Selected()
        {
            var _drinkMakerDriver = Substitute.For<DrinkMakerDriver>();
            _messageNotificator = new CurrentCultureInfoMessageNotificator(_drinkMakerDriver);

            _messageNotificator.NotifySelectDrink();

            _drinkMakerDriver.Received().Notify(Message.Create(SelectDrinkMessage));
        }
    }
}
