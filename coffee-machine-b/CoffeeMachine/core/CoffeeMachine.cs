using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CoffeeMachine.core;

public class CoffeeMachine
{
    private readonly DrinkMakerDriver _drinkMakerDriver;
    private Order _order;
    private decimal _amount;
    private readonly Dictionary<DrinkType, decimal> _drinkTypesPrices;

    public CoffeeMachine(DrinkMakerDriver drinkMakerDriver)
    {
        _drinkMakerDriver = drinkMakerDriver;
        _order = new Order();
        _drinkTypesPrices = new Dictionary<DrinkType, decimal>()
        {
            { DrinkType.Chocolate ,0.5m},
            { DrinkType.Tea ,0.4m},
            { DrinkType.Coffee ,0.6m},
            { DrinkType.None ,0m}
        };
    }

    public void SelectChocolate()
    {
        _order.SelectDrink(DrinkType.Chocolate);
    }

    public void SelectTea()
    {
        _order.SelectDrink(DrinkType.Tea);
    }

    public void SelectCoffee()
    {
        _order.SelectDrink(DrinkType.Coffee);
    }

    public void AddOneSpoonOfSugar()
    {
        _order.AddSpoonOfSugar();
    }

    public void MakeDrink()
    {
        if (NoDrinkWasSelected())
        {
            _drinkMakerDriver.Notify(SelectDrinkMessage());
            return;
        }

        if (_amount < GetDrinkTypesPrice())
        {
            DisplayNotEnoughMoney();
            return;
        }
        

        _drinkMakerDriver.Send(_order);
        _order = new Order();
    }

    private void DisplayNotEnoughMoney()
    {
        var difference = GetDrinkTypesPrice() - _amount;
        _drinkMakerDriver.Notify(NotEnoughMoneyMessage(difference));
    }

    private decimal GetDrinkTypesPrice()
    {
        return _drinkTypesPrices[_order.GetDrinkType()];
    }

    private bool NoDrinkWasSelected()
    {
        return _order.GetDrinkType() == DrinkType.None;
    }

    private Message SelectDrinkMessage()
    {
        const string message = "Please, select a drink!";
        return Message.Create(message);
    }

    private Message NotEnoughMoneyMessage(decimal difference)
    {
        var message = $"Please, Remains to introduce {difference}!";
        return Message.Create(message);
    }

    public void AddMoney(decimal amount)
    {
        _amount = amount;
    }

}