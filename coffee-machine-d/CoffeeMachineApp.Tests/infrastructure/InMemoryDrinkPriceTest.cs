using CoffeeMachineApp.core;
using CoffeeMachineApp.infrastructure;
using NUnit.Framework;
using System.Collections.Generic;

namespace CoffeeMachineApp.Tests.infrastructure
{
    public class InMemoryDrinkPriceTest
    {
        [TestCase(DrinkType.Chocolate, 0.5)]
        [TestCase(DrinkType.Tea, 0.4)]
        [TestCase(DrinkType.Coffee, 0.6)]
        public void get_drink_price_from_configuration(DrinkType drinkType, decimal price)
        {
            var prices = new Dictionary<DrinkType, decimal>()
            {
                { drinkType, price }
            };

            InMemoryDrinkPrices inMemoryDrinkPrice = new(prices);

            var result = inMemoryDrinkPrice.GetDrinkTypePrice(drinkType);

            Assert.That(result, Is.EqualTo(price));
        }

    }
}