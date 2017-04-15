using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using ReferenceAPI.Services;

namespace ReferenceAPI.Tests.Services
{
    public class StringServiceTests
    {
        [UnderTest]
        public StringService _sut;

        [SetUp]
        public void SetUp()
        {
            Fake.InitializeFixture(this);
        }

       [TestCase(" "," ")]
       [TestCase("", "")]
       [TestCase("abc", "cba")]
       [TestCase(" abc ", " cba ")]
       [TestCase("abc def", "cba fed")]
       [TestCase("a b c d e f", "a b c d e f")]
       [TestCase("%%% #$@ !@", "%%% @$# @!")]
       [TestCase("123 #$@  !@", "321 @$#  @!")]
       public void GivenCallToReverseWords_WhenGivenSentence_ThenWeGetReverseWords(string sentence, string expectedValue)
        {
            var result = _sut.ReverseWords(sentence);

            result.Should().Be(expectedValue);
        }
    }
}

