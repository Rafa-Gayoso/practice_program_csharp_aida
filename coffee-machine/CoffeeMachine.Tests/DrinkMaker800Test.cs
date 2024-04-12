using CoffeeMachine.Core;
using CoffeeMachine.Infrastructure;
using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachine.Tests
{
    public class DrinkMaker800Test
    {
        [Test]
        public void Serve_Coffee()
        {
            var drinkMaker = Substitute.For<DrinkMaker>();
            var drinkMaker800 = new DrinkMaker800(drinkMaker);

            var order = new Order()
            {
                Drink = DrinkType.Coffee
            };

            drinkMaker800.Serve(order);

            
            drinkMaker.Received().Execute("C::");
        }

        [Test]
        public void Serve_Tea() {
            var drinkMaker = Substitute.For<DrinkMaker>();
            var drinkMaker800 = new DrinkMaker800(drinkMaker);

            var order = new Order() {
                Drink = DrinkType.Tea
            };

            drinkMaker800.Serve(order);


            drinkMaker.Received().Execute("T::");
        }

        [Test]
        public void Serve_Chocolate() {
            var drinkMaker = Substitute.For<DrinkMaker>();
            var drinkMaker800 = new DrinkMaker800(drinkMaker);

            var order = new Order() {
                Drink = DrinkType.Chocolate
            };

            drinkMaker800.Serve(order);


            drinkMaker.Received().Execute("H::");
        }

        [Test]
        public void Serve_Chocolate_With_One_Spoon_Of_Sugar_And_Stick()
        {
            var drinkMaker = Substitute.For<DrinkMaker>();
            var drinkMaker800 = new DrinkMaker800(drinkMaker);

            var order = new Order()
            {
                Drink = DrinkType.Chocolate,
                SugarSpoon = 1
            };

            drinkMaker800.Serve(order);


            drinkMaker.Received().Execute("H:1:0");
        }

        [Test]
        public void Serve_Tea_With_two_Spoon_Of_Sugar_And_Stick() {
            var drinkMaker = Substitute.For<DrinkMaker>();
            var drinkMaker800 = new DrinkMaker800(drinkMaker);

            var order = new Order() {
                Drink = DrinkType.Tea,
                SugarSpoon = 2
            };

            drinkMaker800.Serve(order);


            drinkMaker.Received().Execute("T:2:0");
        }

        [Test]
        public void No_Serve_Tea_With_three_Spoon_Of_Sugar_And_Stick() {
            var drinkMaker = Substitute.For<DrinkMaker>();
            var drinkMaker800 = new DrinkMaker800(drinkMaker);

            var order = new Order() {
                Drink = DrinkType.Tea,
                SugarSpoon = 3
            };

            drinkMaker800.Serve(order);


            drinkMaker.Received().Execute("T:2:0");
        }
    }
}
