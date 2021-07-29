using NUnit.Framework;
using Ex1;
namespace NUTestsEx1
{
    public class GreetingServiceTest
    {
        private GreetingService Service;
        [OneTimeSetUp]
        public void  InitializeService()
        {
            Service = new();
        }

        [Test]
        [TestCase("Alina")]
        [TestCase("Stefan")]
        public void ShouldGreet(string name)
        {
            var expectedResult = $"Hello, {name} .";
            var actualResult = Service.Greet(name);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            
        }

        [Test]
        public void ShouldHandleNullNames()
        {
            var expectedResult = $"Hello, my friend .";
            var actualResult = Service.Greet(null);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("ALINA")]
        public void ShouldHandleShouting(string name)
        {
            var exepctedResult = $"HELLO, {name} .";
            var actualResult = Service.Greet(name);
            Assert.That(actualResult, Is.EqualTo(exepctedResult));
        }
    }
}