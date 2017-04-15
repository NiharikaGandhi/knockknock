using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Hosting;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using ReferenceAPI.Controllers;
using ReferenceAPI.Services;

namespace ReferenceAPI.Tests.Controller
{
    public class ReferenceControllerTests
    {
        [UnderTest]
        public ReferenceController _sut;
        [Fake]
        public IMathService MathService;
        [Fake]
        public IStringService StringService;
      
        [SetUp]
        public void SetUp()
        {
            Fake.InitializeFixture(this);
            _sut.Request = new HttpRequestMessage();
            _sut.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        }

        [Test]
        public void GivenCallToReverseWords_WhenValidInput_ThenProceedWithCall()
        {
            var sentence = "abc";

            _sut.ReverseWords(sentence);

            A.CallTo(() => StringService.ReverseWords(sentence)).MustHaveHappened();
        }

        [Test]
        public void GivenCallToReverseWords_WhenEmptyInput_ThenDoNotProceedWithCall()
        {
            var sentence = string.Empty;

            _sut.ReverseWords(sentence);

            A.CallTo(() => StringService.ReverseWords(sentence)).MustNotHaveHappened();
        }

        [TestCase(92)]
        [TestCase(-92)]
        public void GivenCallToFibonacci_WhenValidInput_ThenWeGetOK(int n)
        {
            A.CallTo(() => MathService.FibonacciValue(n)).Returns(100);

            var result = _sut.Fibonacci(n).ExecuteAsync(new CancellationToken()).Result;

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [TestCase(93)]
        [TestCase(-93)]
        public void GivenCallToFibonacci_WhenInValidInput_ThenWeGetBadRequest(int n)
        {
            var result = _sut.Fibonacci(n).ExecuteAsync(new CancellationToken()).Result;

            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
