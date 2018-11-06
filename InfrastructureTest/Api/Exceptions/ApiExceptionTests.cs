using System;
using System.Net;
using FluentAssertions;
using Infrastructure.Api.Exceptions;
using NUnit.Framework;

namespace InfrastructureTest.Api.Exceptions
{
    [TestFixture]
    public class ApiExceptionTests
    {
        [Test]
        public void GivenApiException_ApiResponseHas_StatusCode_200()
        {
            //arrange
            //act
            var exception = new ApiException();
            //assert
            exception.StatusCode.Should().Be(HttpStatusCode.InternalServerError);

        }

        [Test]
        public void GivenException_ApiExceptionHas_StatusCode_500()
        {
            //arrange
            //act
            var exception = new ApiException(new Exception());
            //assert
            exception.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        [TestCase("Unhandled Exception")]
        [TestCase("Threading Exception")]
        public void GivenException_ApiExceptionHas_Message(string message)
        {
            //arrange
            //act
            var exception = new ApiException(new Exception(message));
            //assert
            exception.Message.Should().BeEquivalentTo(message);
        }


        [TestCase(502)]
        [TestCase(401)]
        [TestCase(400)]
        public void GivenApiException_StatusCode_IsSet(int statusCode)
        {
            //arrange
            //act
            var exception = new ApiException((HttpStatusCode)statusCode);
            //assert
            exception.StatusCode.Should().Be(statusCode);
        }
    }
}