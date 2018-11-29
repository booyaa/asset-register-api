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

        [TestCase(1, null, 1, 1)]
        [TestCase(2, null, 1, 1)]
        [TestCase(3, null, 1, 1)]
        [TestCase(null, "d", 1, 1)]
        [TestCase(null, "e", 1, 1)]
        [TestCase(null, "t", 1, 1)]
        [TestCase(1, "a", 1, 1)]
        [TestCase(2, "b", 2, 3)]
        [TestCase(3, "c", 3, 5)]
        public void GivenValidInput_ThenIsValidIsTrue(int? id, string address, int? page, int? pageSize)
        {
            //arrange
            var request = new SearchAssetRequest
            {
                SchemeId = id,
                Address = address,
                Page = page,
                PageSize = pageSize
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeTrue();
        }

        [TestCase(null, null, 1, 1)]
        [TestCase(0, null, 1, 1)]
        [TestCase(-1, null, 1, 1)]
        [TestCase(null, "", 1, 1)]
        [TestCase(null, " ", 1, 1)]
        [TestCase(1, "address", null, 1)]
        [TestCase(1, "address", -1, 1)]
        [TestCase(1, "address", 0, 1)]
        [TestCase(1, "address", 1, null)]
        [TestCase(1, "address", 1, -1)]
        [TestCase(1, "address", 1, 0)]
        public void GivenInValidRequest_ThenIsValidIsFalse(int? id, string address, int? page, int? pageSize)
        {
            //arrange
            var request = new SearchAssetRequest
            {
                SchemeId = id,
                Address = address,
                Page = page,
                PageSize = pageSize
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeFalse();
            response.Errors.Should().NotBeNullOrEmpty();
        }
    }
}
