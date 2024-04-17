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
        _drinkMakerDriver.Notify(Message.Create($"You are missing {missingMoney}"));
    }

    private Message ComposeSelectDrinkMessage()
    {
        const string message = "Please, select a drink!";
        return Message.Create(message);
    }
}