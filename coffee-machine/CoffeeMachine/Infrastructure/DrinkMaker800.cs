using CoffeeMachine.Core;

namespace CoffeeMachine.Infrastructure
{
    public class DrinkMaker800 : DrinkMakerDriver
    {
        private readonly DrinkMaker _drinkMaker;


        public DrinkMaker800(DrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
        }

        public void Serve(Order order)
        {
            var command = $"{order.Drink[0]}::";
           
            _drinkMaker.Execute(command);
        }
    }
}