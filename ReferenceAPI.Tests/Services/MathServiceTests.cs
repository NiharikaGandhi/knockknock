using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using ReferenceAPI.Services;

namespace ReferenceAPI.Tests.Services
{
    public class MathServiceTests
    {
        [UnderTest]
        public MathService _sut;
       
        [SetUp]
        public void SetUp()
        {
            Fake.InitializeFixture(this);
        }
        
        [TestCase(92, 7540113804746346429)]
        [TestCase(90, 2880067194370816120)]
        [TestCase(45, 1134903170)]
        [TestCase(10, 55)]
        [TestCase(3, 2)]
        [TestCase(2, 1)]
        [TestCase(1, 1)]
        [TestCase(0, 0)]
        [TestCase(-1, 1)]
        [TestCase(-2, -1)]
        [TestCase(-3, 2)]
        [TestCase(-10, -55)]
        [TestCase(-45, 1134903170)]
        [TestCase(-90, -2880067194370816120)]
        [TestCase(-92, -7540113804746346429)]
        public void GivenCallToFibonacci_WhenValidInput_ThenWeGetValue(int n, long expectedValue)
        {
            var result = _sut.FibonacciValue(n);

            result.Should().Be(expectedValue);
        }
    }
}


