using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.Results;
using Infrastructure.Api.Response.Errors;
using Infrastructure.Api.Response.Validation;
using NUnit.Framework;

namespace InfrastructureTest.Api.Response.Errors
{
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