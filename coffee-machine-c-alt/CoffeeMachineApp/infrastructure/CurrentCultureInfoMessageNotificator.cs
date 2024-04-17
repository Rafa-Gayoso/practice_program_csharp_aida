using System.Collections.Generic;
using System.Globalization;
using CoffeeMachineApp.core;

namespace CoffeeMachineApp.infrastructure;

public class CurrentCultureInfoMessageNotificator : MessageNotificator
{
    private readonly DrinkMakerDriver _drinkMakerDriver;
    private readonly CultureInfo _cultureInfo;
    private readonly Dictionary<string, string> _selectDrinkMessage;
    private readonly Dictionary<string, string> _missingMoneyMessages;
    private NumberFormatInfo _nfi;

    public CurrentCultureInfoMessageNotificator(DrinkMakerDriver drinkMakerDriver, CultureInfo cultureInfo)
    {
        _drinkMakerDriver = drinkMakerDriver;
        _cultureInfo = cultureInfo;
        _nfi = _cultureInfo.NumberFormat;

        _selectDrinkMessage = new Dictionary<string, string>
        {
            { "es-ES", "Por favor, seleccione una bebida!" },
            { "en-US", "Please, select a drink!" }
        };
        _missingMoneyMessages = new Dictionary<string, string>
        {
            { "es-ES", "Le faltan {0}" },
            { "en-US", "You are missing {0}" }
        };
    }

    public CurrentCultureInfoMessageNotificator(DrinkMakerDriver drinkMakerDriver)
    {
        _drinkMakerDriver = drinkMakerDriver;
    }

    public void NotifySelectDrink()
    {
        _drinkMakerDriver.Notify(Message.Create(_selectDrinkMessage[_cultureInfo.Name]));
    }

    public void NotifyMissingAmount(decimal missingMoney)
    {
        _drinkMakerDriver.Notify(Message.Create(string.Format(_missingMoneyMessages[_cultureInfo.Name], 
            missingMoney.ToString("F1", _nfi))));
    }

}