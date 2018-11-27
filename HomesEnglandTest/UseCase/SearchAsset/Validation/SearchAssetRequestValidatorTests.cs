using FluentAssertions;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.GetAsset.Models.Validation;
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

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GivenValidInput_ThenIsValidIsTrue(int? id)
        {
            //arrange
            var request = new SearchAssetRequest
            {
                SchemeId = id
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeTrue();
        }

        [TestCase(0,  "SchemeId must not be null and must be greater than 0.")]
        [TestCase(-1, "SchemeId must not be null and must be greater than 0.")]
        [TestCase(null, "'Scheme Id' must not be empty.")]
        public void GivenInValidRequest_ThenIsValidIsFalse(int? id, string message)
        {
            //arrange
            var request = new SearchAssetRequest
            {
                SchemeId = id
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeFalse();
            response.Errors.Should().NotBeNullOrEmpty();
            response.Errors[0].PropertyName.Should().BeEquivalentTo("SchemeId");
            response.Errors[0].ErrorMessage.Should().BeEquivalentTo(message);
        }
    }
}
