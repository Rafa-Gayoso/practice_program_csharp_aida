using NUnit.Framework;

namespace InspirationOfTheDay.Tests
{
    public class InspirationOfTheDayTest
    {
        [Test]
        public void Fix_Me_And_Rename_Me()
        {
            var inspirationService = new InspirationService();
            var word = "word";

            inspirationService.InspireSomeone(word);

            Assert.That(false, Is.True);
        }
    }

    public class InspirationService
    {
        public void InspireSomeone(string word)
        {
            throw new System.NotImplementedException();
        }
    }
}
