using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace LegacySecurityManager.Tests
{
    public class SecurityManagerTest
    {
        private SecurityManagerForTesting _securityManager;

        [Test]
        public void do_not_save_user_when_password_and_confirm_password_are_not_equals()
        {
            _securityManager = SecurityManagerReceivingInputs("Pepe", "Pepe Garcia", "Pepe1234", "Pepe1234.");

            _securityManager.CreateValidUser();

            AssertPrintedMessages("The passwords don't match");
        }

        [Test]
        public void do_not_save_user_when_password_too_short()
        {
            _securityManager = SecurityManagerReceivingInputs("Pepe", "Pepe Garcia", "Pepe123", "Pepe123");

            _securityManager.CreateValidUser();

            AssertPrintedMessages("Password must be at least 8 characters in length");
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

        private void AssertPrintedMessages(string lastMessage)
        {
            Assert.That(_securityManager.PrintedMessage.Count, Is.EqualTo(5));
            Assert.That(_securityManager.PrintedMessage, Is.EquivalentTo(new List<string>
            {
                "Enter a username",
                "Enter your full name",
                "Enter your password",
                "Re-enter your password",
                lastMessage
            }));
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