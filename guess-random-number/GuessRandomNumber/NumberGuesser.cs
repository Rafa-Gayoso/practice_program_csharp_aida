namespace GuessRandomNumber;

public class NumberGuesser
{
    private const int MaxGuesses = 3;
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
        var numberToGuess = _numberGenerator.Generate();

        for (var guesses = 1; guesses <= MaxGuesses; guesses++)
        {
            var userGuess = _inputReceiver.GuessNumber();
            if (userGuess == numberToGuess) {
                _notifier.Notify("You win!");
                return;
            }
            if (guesses == MaxGuesses) {
                _notifier.Notify("You lose");
                return;
            }
            _notifier.Notify(ComposeHint(userGuess, numberToGuess));
        }
    }

    private string ComposeHint(int userGuess, int numberToGuess)
    {
        if (userGuess > numberToGuess)
        {
            return $"Number to guess is lower than {userGuess}. Try again.";
        }

        return $"Number to guess is bigger than {userGuess}. Try again.";
    }
}