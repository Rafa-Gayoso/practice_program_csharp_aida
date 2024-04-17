using CoffeeMachineApp.core;

namespace CoffeeMachineApp.infrastructure;

public class CurrentCultureInfoMessageNotificator : MessageNotificator
{
    private readonly DrinkMakerDriver _drinkMakerDriver;

    public CurrentCultureInfoMessageNotificator(DrinkMakerDriver drinkMakerDriver)
    {
        _drinkMakerDriver = drinkMakerDriver;
    }

    public void NotifySelectDrink()
    {
        _drinkMakerDriver.Notify(ComposeSelectDrinkMessage());
    }

    public void NotifyMissingAmount(decimal missingMoney)
    {
        _drinkMakerDriver.Notify(Message.Create($"Le faltan {missingMoney}"));
    }

    private Message ComposeSelectDrinkMessage()
    {
        const string message = "Por favor, seleccione una bebida!";
        return Message.Create(message);
    }
}