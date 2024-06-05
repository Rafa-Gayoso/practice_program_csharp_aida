using NUnit.Framework;

namespace LegacySecurityManager.Tests
{
    public class SecurityManagerTest
    {
        [Test]
        public void do_not_save_user_when_password_and_confirm_password_are_not_equals()
        {
            var securityManager = SecurityManagerReceivingInputs("Pepe", "Pepe Garcia", "Pepe1234", "Pepe1234.");

            securityManager.CreateValidUser();

            Assert.That(securityManager.PrintedMessage.Count, Is.EqualTo(5));
            Assert.That(securityManager.PrintedMessage, Is.EquivalentTo(new List<string>
            {
                "Enter a username",
                "Enter your full name",
                "Enter your password",
                "Re-enter your password",
                "The passwords don't match"
            }));
        }

        private static SecurityManagerForTesting SecurityManagerReceivingInputs(params string[] inputs)
        {
            var userInputs = new Queue<string>();
            foreach (var input in inputs)
            {
                userInputs.Enqueue(input);
            }

            return new SecurityManagerForTesting(userInputs);
        }
    }

    public class SecurityManagerForTesting : SecurityManager
    {
        public List<string> PrintedMessage { get; init; }
        private Queue<string> _userInput;

        public SecurityManagerForTesting(Queue<string> userInput)
        {
            PrintedMessage = new List<string>();
            _userInput = userInput;
        }

        protected override void Print(string message)
        {
            PrintedMessage.Add(message);
        }

        protected override string ReadUserInput()
        {
            return _userInput.Dequeue();
        }
    }
}