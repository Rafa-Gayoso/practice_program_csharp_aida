namespace CoffeeMachine.Core;

public class CoffeeMachine {
    private readonly DrinkMakerDriver _drinkMakerDriver;
    private Order _order;

    public CoffeeMachine(DrinkMakerDriver drinkMakerDriver) {
        _drinkMakerDriver = drinkMakerDriver;
        _order = new EmptyOrder();
    }

    public void SelectCoffee() {
        _order = new Order() {
            Drink = DrinkType.Coffee
        };
    }

    public void SelectTea() {
        _order = new Order() {
            Drink = DrinkType.Tea
        };
    }

    public void SelectChocolate() {
        _order = new Order() {
            Drink = DrinkType.Chocolate
        };
    }

    public void AddOneSpoonOfSugar() {
        if (_order.SugarSpoon < 2) {
            _order.SugarSpoon++;
        }
    }

    public void MakeDrink() {
        _drinkMakerDriver.Serve(_order);
    }


}