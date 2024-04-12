using CoffeeMachine.Core;
using CoffeeMachine.Infrastructure;
using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachine.Tests {
    public class DrinkMaker800Test {
  
        [TestCase(DrinkType.Chocolate, "H")]
        [TestCase(DrinkType.Coffee, "C")]
        [TestCase(DrinkType.Tea, "T")]
        public void Serve_Drink(DrinkType drinkType, string drinkCommand) {
            var drinkMaker = Substitute.For<DrinkMaker>();
            var drinkMaker800 = new DrinkMaker800(drinkMaker);

            var order = new Order() {
                Drink = drinkType
            };

            drinkMaker800.Serve(order);


            drinkMaker.Received().Execute($"{drinkCommand}::");
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Serve_drinks_With_Spoons_Of_Sugar_And_Stick(int sugar) {
            var drinkMaker = Substitute.For<DrinkMaker>();
            var drinkMaker800 = new DrinkMaker800(drinkMaker);

            var order = new Order() {
                Drink = DrinkType.Chocolate,
                SugarSpoon = sugar
            };

            drinkMaker800.Serve(order);


            drinkMaker.Received().Execute($"H:{sugar}:0");
        }

    }
}
