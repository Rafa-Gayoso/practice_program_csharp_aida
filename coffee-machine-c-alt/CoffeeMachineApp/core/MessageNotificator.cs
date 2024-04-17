namespace CoffeeMachineApp.core;

public interface MessageNotificator
{
    void NotifySelectDrink();
    void NotifyMissingAmount(decimal missingMoney);
}