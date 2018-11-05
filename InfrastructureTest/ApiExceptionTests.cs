using System;
using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using FluentValidation.Results;
using Infrastructure;
using NUnit.Framework;

namespace InfrastructureTest
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

    [TestFixture]
    public class ApiErrorTests
    {
        [Test]
        public void GivenException_ApiError_HasExecutionErrors()
        {
            //arrange
            //act
            var error = new ApiError(new Exception());
            //assert
            error.Errors.Should().NotBeNullOrEmpty();
            error.Errors[0].Should().NotBeNull();
        }

        [TestCase("Name","IsNullOrEmpty")]
        [TestCase("LastName", "Is longer than 32 character")]
        public void GivenRequestValidationResponse_ApiError_HasValidationErrors(string field, string message)
        {
            //arrange
            //act
            var error = new ApiError(new RequestValidationResponse(new ValidationResult(new List<ValidationFailure>
            {
                new ValidationFailure(field, message)
            })));
            //assert
            error.ValidationErrors.Should().NotBeNullOrEmpty();
            error.ValidationErrors[0].FieldName.Should().BeEquivalentTo(field);
            error.ValidationErrors[0].Message.Should().BeEquivalentTo(message);
        }

        [Test]
        public void GivenRequestValidationResponseIsNull_ApiErrorHas_IsValidationErrorIsTrue()
        {
            //arrange
            //act
            var error = new ApiError((RequestValidationResponse)null);
            //assert
            error.ValidationErrors.Should().BeNull();
            error.IsValidationError.Should().BeTrue();
        }
    }
}