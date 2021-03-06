using NUnit.Framework;
using Ex1;
using System.Collections.Generic;
using System;

namespace NUTestsEx1
{
    public class GreetingServiceTest
    {
        private GreetingService Service;
        [OneTimeSetUp]
        public void InitializeService()
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
            var actualResult = Service.Greet((string)null);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("ALINA")]
        public void ShouldHandleShouting(string name)
        {
            var exepctedResult = $"HELLO, {name} !";
            var actualResult = Service.Greet(name);
            Assert.That(actualResult, Is.EqualTo(exepctedResult));
        }

        [Test]
        [TestCase("Stefan", "Emma")]
        public void ShouldHandleTwoNames(params string[] names)
        {
            string expectedResult = $"Hello, {names[0]} and {names[1]} .";
            string actualResult = Service.Greet(names);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("Stefan", "Emma","Andrei","Magda",ExpectedResult ="Hello, Stefan, Emma, Andrei and Magda .")]
        public string ShouldHandleMoreNames(params string[] names)
        {
            return Service.Greet(names);
        }

        [Test]
        [TestCase("Stefan","EMMA","George",ExpectedResult ="Hello, Stefan and George .AND HELLO, EMMA !")]
        [TestCase("Ana","MARIA","STEFAN",ExpectedResult ="Hello, Ana .AND HELLO, MARIA AND STEFAN !")]
        public string ShlouldHandleMixedNames(params string[] names)
        {
            return Service.Greet(names);
        }

        [Test]
        [TestCase("Stefan,Emma", ExpectedResult = "Hello, Stefan and Emma .")]
        [TestCase("Stefan,Emma", "ANA,MARIA", ExpectedResult = "Hello, Stefan and Emma .AND HELLO, ANA AND MARIA !")]
        [TestCase("Stefan,Emma,Ana,Maria", ExpectedResult = "Hello, Stefan, Emma, Ana and Maria .")]
        public string ShouldHandleMultipleNamesInASingleString(params string[] names)
        {
            return Service.Greet(names);
        }

        [Test]
        [TestCase("Ana","\"George,Dan\"",ExpectedResult ="Hello, Ana and George,Dan .")]
        public string ShouldHandleCommaSurroundedInNames(params string[]names)
        {
            return Service.Greet(names);
        }
    }
}