using CoffeeMachine.Core;
using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachine.Tests
{
    public class CoffeeMachineTest
    {
        [Test]
        public void Serve_Coffee()
        {
            var drinkMakerDriver = Substitute.For<DrinkMakerDriver>();
            var coffeeMachine = new Core.CoffeeMachine(drinkMakerDriver);

            coffeeMachine.SelectCoffee();
            coffeeMachine.MakeDrink();

            drinkMakerDriver.Received().Serve("Coffee");
        }
    }
}