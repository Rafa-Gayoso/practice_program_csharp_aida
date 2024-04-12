using System;
using System.Collections.Generic;
using CoffeeMachine.Core;

namespace CoffeeMachine.Infrastructure
{
    public class DrinkMaker800 : DrinkMakerDriver
    {
        private readonly DrinkMaker _drinkMaker;
        private readonly Dictionary<DrinkType, string> _drinkDictionary;


        public DrinkMaker800(DrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
            _drinkDictionary = new Dictionary<DrinkType, string>
            {
                { DrinkType.Coffee, "C" }, 
                { DrinkType.Tea, "T" }, 
                { DrinkType.Chocolate, "H" }
            };
        }

        public void Serve(Order order)
        {
            var command = GetCommand(order);

            _drinkMaker.Execute(command);
        }

        private string GetCommand(Order order)
        {
            var sugarSpoon = order.SugarSpoon == 0 ? string.Empty : order.SugarSpoon.ToString();
            var stick = order.SugarSpoon > 0 ? "0" : string.Empty;
            return $"{_drinkDictionary.GetValueOrDefault(order.Drink)}:{sugarSpoon}:{stick}";
        }
    }
}