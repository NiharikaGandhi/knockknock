using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using ReferenceAPI.Services;

namespace ReferenceAPI.Tests.Services
{
    public class ShapeServiceTests
    {
        [UnderTest]
        public ShapeService _sut;

        [SetUp]
        public void SetUp()
        {
            Fake.InitializeFixture(this);
        }

        [TestCase(1,1,1, ShapeService.TriangleType.Equilateral)]
        [TestCase(-1, 1, 1, ShapeService.TriangleType.Error)]
        [TestCase(1, 0, 1, ShapeService.TriangleType.Error)]
        [TestCase(2, 1, 1, ShapeService.TriangleType.Error)]
        [TestCase(2, 2, 1, ShapeService.TriangleType.Isosceles)]
        [TestCase(2, 3, 4, ShapeService.TriangleType.Scalene)]
        public void GivenCallToTriangleType_WhenGiven3Values_ThenWeGetTriangleType(long a, long b, long c, ShapeService.TriangleType expectedValue)
        {
            var result = _sut.GetTriangleType(a,b,c);

            result.Should().Be(expectedValue);
        }
    }
}
