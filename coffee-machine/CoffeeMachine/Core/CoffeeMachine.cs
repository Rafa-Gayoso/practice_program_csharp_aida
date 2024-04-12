namespace CoffeeMachine.Core;

public class CoffeeMachine
{
    private readonly DrinkMakerDriver _drinkMakerDriver;
    private string _drink;

    public CoffeeMachine(DrinkMakerDriver drinkMakerDriver)
    {
        _drinkMakerDriver = drinkMakerDriver;
    }

    public void SelectCoffee()
    {
        _drink = "Coffee";
    }

    public void MakeDrink()
    {
        _drinkMakerDriver.Serve(_drink);
    }
}