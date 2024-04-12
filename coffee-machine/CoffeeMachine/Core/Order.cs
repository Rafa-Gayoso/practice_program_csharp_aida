namespace CoffeeMachine.Core;

public record Order
{
    public string Drink { get; set; }
    public int SugarSpoon { get; set; }
}