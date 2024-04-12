namespace CoffeeMachine.Core;

public interface DrinkMakerDriver
{
    void Serve(Order order);
}