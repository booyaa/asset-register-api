using FluentAssertions;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.GetAsset.Models.Validation;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.GetAsset.Validation
{
    [TestFixture]
    public class GetAssetRequestValidatorTests
    {
        private readonly GetAssetRequestValidator _classUnderTest;
        public GetAssetRequestValidatorTests()
        {
            _classUnderTest = new GetAssetRequestValidator();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GivenValidInput_ThenIsValidIsTrue(int? id)
        {
            //arrange
            var request = new GetAssetRequest
            {
                Id = id
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeTrue();
        }

        [TestCase(0,  "Id must not be null and must be greater than 0.")]
        [TestCase(-1, "Id must not be null and must be greater than 0.")]
        [TestCase(null, "'Id' must not be empty.")]
        public void GivenInValidRequest_ThenIsValidIsFalse(int? id, string message)
        {
            //arrange
            var request = new GetAssetRequest
            {
                Id = id
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeFalse();
            response.Errors.Should().NotBeNullOrEmpty();
            response.Errors[0].PropertyName.Should().BeEquivalentTo("Id");
            response.Errors[0].ErrorMessage.Should().BeEquivalentTo(message);
        }
    }
}
