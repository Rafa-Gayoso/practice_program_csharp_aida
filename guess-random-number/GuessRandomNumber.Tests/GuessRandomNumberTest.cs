using System.Security.Cryptography;
using NSubstitute;
using NUnit.Framework;

namespace GuessRandomNumber.Tests {
    public class GuessRandomNumberTest {
        private InputReceiver _inputReceiver;
        private NumberGenerator _numberGenerator;
        private Notifier _notifier;

        private NumberGuesser _numberGuesser;
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

        [SetUp]
        public void Setup() {
            _inputReceiver = Substitute.For<InputReceiver>();
            _numberGenerator = Substitute.For<NumberGenerator>();
            _notifier = Substitute.For<Notifier>();
            _numberGuesser = new NumberGuesser(_inputReceiver, _numberGenerator, _notifier);
        }

        [Test]
        public void user_wins_with_firts_guess() {
            _inputReceiver.GuessNumber().Returns(5);
            _numberGenerator.Generate().Returns(5);

            _numberGuesser.Run();

            _notifier.Received(1).Notify("You win!");
        }

        [Test]
        public void user_wins_with_second_guess()
        {
            _inputReceiver.GuessNumber().Returns(4,5);
            _numberGenerator.Generate().Returns(5);

            _numberGuesser.Run();

            _notifier.Received(1).Notify("Number to guess is bigger than 4. Try again.");
            _notifier.Received(1).Notify("You win!");
            _notifier.Received(2).Notify(Arg.Any<string>());
        }

        [Test]
        public void user_wins_with_third_guess()
        {
            _inputReceiver.GuessNumber().Returns(4, 8, 6);
            _numberGenerator.Generate().Returns(6);

            _numberGuesser.Run();

            _notifier.Received(1).Notify("Number to guess is bigger than 4. Try again.");
            _notifier.Received(1).Notify("Number to guess is lower than 8. Try again.");
            _notifier.Received(1).Notify("You win!");
            _notifier.Received(3).Notify(Arg.Any<string>());
        }

        [Test]
        public void user_loses()
        {
            _inputReceiver.GuessNumber().Returns(4, 8, 3);
            _numberGenerator.Generate().Returns(5);

            _numberGuesser.Run();

            _notifier.Received(1).Notify("Number to guess is bigger than 4. Try again.");
            _notifier.Received(1).Notify("Number to guess is lower than 8. Try again.");
            _notifier.Received(1).Notify("You lose");
            _notifier.Received(3).Notify(Arg.Any<string>());
        }
    }
}