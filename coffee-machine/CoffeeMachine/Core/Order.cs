namespace CoffeeMachine.Core;

public record Order
{
    public int SugarSpoon { get; set; }
    public DrinkType Drink { get; set; }
}