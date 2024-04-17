using CoffeeMachineApp.core;
using System.Globalization;

namespace CoffeeMachineApp.Tests.infrastructure
{
    public class SpanishCultureMessageNotificatorTest : CurrentCultureInfoMessageNotificatorTest
    {
        private const string SelectDrinkMessage = "Por favor, seleccione una bebida!";
        private NumberFormatInfo nfi = new CultureInfo("es-ES", false).NumberFormat;

        protected override Message GetNotEnoughMoneyMessage(decimal missingAmount)
        {
            return Message.Create($"Le faltan {missingAmount.ToString("F1", nfi)}");
        }

        protected override Message GetSelectDrinkMessage()
        {
            return Message.Create(SelectDrinkMessage);
        }

        
    }
}
