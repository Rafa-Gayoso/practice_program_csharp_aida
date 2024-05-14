namespace GuessRandomNumber;

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
        var numberToGuess = _numberGenerator.Generate();
        var userGuess = _inputReceiver.GuessNumber();
        if (userGuess == numberToGuess) {
            _notifier.Notify("You win!");
            return;
        }
        if (userGuess > numberToGuess) {
            _notifier.Notify($"Number to guess is lower than {userGuess}. Try again.");
            
        }
        else {
            _notifier.Notify($"Number to guess is bigger than {userGuess}. Try again.");
        }
    }
}