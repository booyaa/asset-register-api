using System.Net;
using FluentAssertions;
using Infrastructure;
using NUnit.Framework;

namespace InfrastructureTest
{
    [TestFixture]
    public class BadRequestExceptionTests
    {
        [Test]
        public void GivenBadRequest_StatusCode_Is_400()
        {
            //arrange
            //act
            var exception = new BadRequestException();
            //assert
            exception.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public void GivenApiException_ApiResponseHas_StatusCode_200()
        {
            //arrange
            //act
            var exception = new BadRequestException(new RequestValidationResponse(false));
            //assert
            exception.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}