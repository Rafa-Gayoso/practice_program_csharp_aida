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

            var order = new Order()
            {
                Drink = "Coffee"
            };
            drinkMakerDriver.Received().Serve(order);
        }

        [Test]
        public void Serve_Tea() {
            var drinkMakerDriver = Substitute.For<DrinkMakerDriver>();
            var coffeeMachine = new Core.CoffeeMachine(drinkMakerDriver);

            coffeeMachine.SelectTea();
            coffeeMachine.MakeDrink();

            var order = new Order() {
                Drink = "Tea"
            };
            drinkMakerDriver.Received().Serve(order);
        }
    }
}