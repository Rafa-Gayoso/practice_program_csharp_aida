using System.Security.Cryptography;
using NSubstitute;
using NUnit.Framework;

namespace GuessRandomNumber.Tests
{
    public class GuessRandomNumberTest
    {
        //Input
        // user number
        // numero a adivinar

        //Boundaries
        // <1 o > 12 y que no sea un entero

        //Output
        // numero mayor, numero menor, si ha ganado o perdido.

        //Invariants
        // numero de intentos => 3

        /*Lista de ejemplos
         * Dado el numero aleatorio 5, el usaurio escoge 5, se le notifica al usuario que ha ganado
         * Dado el numero aleatorio 5, el usuario escoge 6, se le notifica al usuario que el numero aleatorio es menor y se resta un intento
         * Dado el numero aleatorio 5, el usuario escoge 4, se le notifica al usuario que el numero aleatorio es mayor y se resta un intento
         * Dado el numero aleatorio 5 y al usuario le quedan 2 intentos, el usuario escoge 5, se le notifica que ha ganado
         * Dado el numero aleatorio 5 y al usuario le quedan 1 intentos, el usuario escoge 8, se le notifica que ha perdido pq se ha quedado sin intentos
         */
        [Test]
        public void given_random_number_is_5_and_the_user_select_5_then_the_user_has_won()
        {
            var inputReceiver = Substitute.For<InputReceiver>();
            var numberGenerator =Substitute.For<NumberGenerator>();
            var notifier = Substitute.For<Notifier>();
            var numberGuesser = new NumberGuesser(inputReceiver, numberGenerator, notifier);
            inputReceiver.GuessNumber().Returns(5);
            numberGenerator.Generate().Returns(5);

            numberGuesser.Run();

            notifier.Received(1).Notify("You win!");
        }
    }

    public interface Notifier
    {
        void Notify(string message);
    }

    public interface NumberGenerator
    {
        int Generate();
    }

    public interface InputReceiver
    {
        int GuessNumber();
    }

    public class NumberGuesser
    {
        private readonly InputReceiver _inputReceiver;
        private readonly NumberGenerator _numberGenerator;
        private readonly Notifier _notifier;

        public NumberGuesser(InputReceiver inputReceiver, NumberGenerator numberGenerator, Notifier notifier)
        {
            _inputReceiver = inputReceiver;
            _numberGenerator = numberGenerator;
            _notifier = notifier;
        }

        public void Run()
        {
            _notifier.Notify("You win!");
        }
    }
}