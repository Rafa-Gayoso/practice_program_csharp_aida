using System.Collections.Generic;
using CoffeeMachine.Core;

namespace CoffeeMachine.Infrastructure {
    public class DrinkMaker800 : DrinkMakerDriver {
        private readonly DrinkMaker _drinkMaker;
        private readonly Dictionary<string, string> _drinkDictionary;


        public DrinkMaker800(DrinkMaker drinkMaker) {
            _drinkMaker = drinkMaker;
            _drinkDictionary = new Dictionary<string, string> { { "Coffee", "C" }, { "Tea", "T" }, { "Chocolate", "H" } };
        }

        public void Serve(Order order) {
            var command = GetCommand(order);

            _drinkMaker.Execute(command);
        }

        private string GetCommand(Order order) {
            return $"{_drinkDictionary.GetValueOrDefault(order.Drink)}::";
        }
    }
}