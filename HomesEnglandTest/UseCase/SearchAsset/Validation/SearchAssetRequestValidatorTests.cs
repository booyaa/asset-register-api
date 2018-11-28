using FluentAssertions;
using HomesEngland.UseCase.SearchAsset.Models;
using HomesEngland.UseCase.SearchAsset.Models.Validation;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.SearchAsset.Validation
{
    [TestFixture]
    public class SearchAssetRequestValidatorTests
    {
        private readonly SearchAssetRequestValidator _classUnderTest;
        public SearchAssetRequestValidatorTests()
        {
            _classUnderTest = new SearchAssetRequestValidator();
        }

        [TestCase(1, null)]
        [TestCase(2, null)]
        [TestCase(3, null)]
        [TestCase(null, "d")]
        [TestCase(null, "e")]
        [TestCase(null, "t")]
        public void GivenValidInput_ThenIsValidIsTrue(int? id, string address)
        {
            //arrange
            var request = new SearchAssetRequest
            {
                SchemeId = id,
                Address = address
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeTrue();
        }

        [TestCase(null, null, "'Scheme Id' must not be empty.")]
        [TestCase(0,    null, "SchemeId must not be null and must be greater than 0.")]
        [TestCase(-1,   null, "SchemeId must not be null and must be greater than 0.")]
        [TestCase(null, " ", "Address must not be null or empty.")]
        public void GivenInValidRequest_ThenIsValidIsFalse(int? id, string address, string message)
        {
            //arrange
            var request = new SearchAssetRequest
            {
                SchemeId = id,
                Address = address
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeFalse();
            response.Errors.Should().NotBeNullOrEmpty();
            response.Errors[0].ErrorMessage.Should().BeEquivalentTo(message);
        }
    }
}
