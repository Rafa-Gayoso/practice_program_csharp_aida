using CoffeeMachine.Core;
using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachine.Tests
{
    public class CoffeeMachineTest
    {
        private DrinkMakerDriver _drinkMakerDriver;
        private Core.CoffeeMachine _coffeeMachine;

        [SetUp]
        public void SetUp()
        {
            _drinkMakerDriver = Substitute.For<DrinkMakerDriver>();
            _coffeeMachine = new Core.CoffeeMachine(_drinkMakerDriver);
        }

        [Test]
        public void Serve_Coffee()
        {
            var order = new Order()
            {
                Drink = DrinkType.Coffee
            };

            _coffeeMachine.SelectCoffee();
            _coffeeMachine.MakeDrink();

            _drinkMakerDriver.Received().Serve(order);
        }

        [Test]
        public void Serve_Tea() {
            var order = new Order()
            {
                Drink = DrinkType.Tea
            };

            _coffeeMachine.SelectTea();
            _coffeeMachine.MakeDrink();

            _drinkMakerDriver.Received().Serve(order);
        }

        [Test]
        public void Serve_Chocolate() {
            var order = new Order()
            {
                Drink = DrinkType.Chocolate
            };

            _coffeeMachine.SelectChocolate();
            _coffeeMachine.MakeDrink();

            _drinkMakerDriver.Received().Serve(order);
        }

        [Test]
        public void Serve_Coffee_With_One_Spoon_Of_Sugar_And_Stick()
        {
            var order = new Order()
            {
                Drink = DrinkType.Coffee,
                SugarSpoon = 1
            };

            _coffeeMachine.SelectCoffee();
            _coffeeMachine.AddOneSpoonOfSugar();
            _coffeeMachine.MakeDrink();

            _drinkMakerDriver.Received().Serve(order);
        }

        [Test]
        public void Serve_Chocolate_With_One_Spoon_Of_Sugar_And_Stick()
        {
            var order = new Order()
            {
                Drink = DrinkType.Chocolate,
                SugarSpoon = 1
            };

            _coffeeMachine.SelectChocolate();
            _coffeeMachine.AddOneSpoonOfSugar();
            _coffeeMachine.MakeDrink();

            _drinkMakerDriver.Received().Serve(order);
        }

        [Test]
        public void No_Serve_Tea_With_three_Spoon_Of_Sugar_And_Stick() {
            var order = new Order() {
                Drink = DrinkType.Tea,
                SugarSpoon = 2
            };

            _coffeeMachine.SelectTea();
            _coffeeMachine.AddOneSpoonOfSugar();
            _coffeeMachine.AddOneSpoonOfSugar();
            _coffeeMachine.AddOneSpoonOfSugar();
            _coffeeMachine.MakeDrink();

            _drinkMakerDriver.Received().Serve(order);
        }

    }
}