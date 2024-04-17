using CoffeeMachineApp.core;
using CoffeeMachineApp.infrastructure;
using System.Globalization;

namespace CoffeeMachineApp.Tests.infrastructure
{
    public class EnglishCultureMessageNotificatorTest : CurrentCultureInfoMessageNotificatorTest
    {
        private const string SelectDrinkMessage = "Please, select a drink!";
        private NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

        protected override Message GetNotEnoughMoneyMessage(decimal missingAmount)
        {
            return Message.Create($"You are missing {missingAmount.ToString("F1", nfi)}");
        }

        protected override Message GetSelectDrinkMessage()
        {
            return Message.Create(SelectDrinkMessage);
        }

        protected override CurrentCultureInfoMessageNotificator CreateMessageNotificator()
        {
            return new CurrentCultureInfoMessageNotificator(base._drinkMakerDriver, new CultureInfo("en-US"));
        }
    }
}
