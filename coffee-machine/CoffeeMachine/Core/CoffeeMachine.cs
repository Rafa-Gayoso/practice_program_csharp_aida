namespace CoffeeMachine.Core;

public class CoffeeMachine
{
    private readonly DrinkMakerDriver _drinkMakerDriver;
    private Order _order;

    public CoffeeMachine(DrinkMakerDriver drinkMakerDriver)
    {
        _drinkMakerDriver = drinkMakerDriver;
    }

    public void SelectCoffee()
    {
        _order = new Order()
        {
            Drink = "Coffee"
        };
    }

    public void MakeDrink()
    {
        _drinkMakerDriver.Serve(_order);
    }

    public void SelectTea() {
        _order = new Order() {
            Drink = "Tea"
        };
    }

    public void SelectChocolate() {
        _order = new Order() {
            Drink = "Chocolate"
        };
    }
}