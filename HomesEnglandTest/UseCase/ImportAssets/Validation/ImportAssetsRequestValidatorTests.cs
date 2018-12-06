using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.GetAsset.Models.Validation;
using HomesEngland.UseCase.ImportAssets.Models;
using HomesEngland.UseCase.ImportAssets.Validation;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.ImportAssets.Validation
{
    

    [TestFixture]
    public class ImportAssetsRequestValidatorTests
    {
        private readonly ImportAssetsRequestValidator _classUnderTest;
        public ImportAssetsRequestValidatorTests()
        {
            _classUnderTest = new ImportAssetsRequestValidator();
        }

        [TestCase("id;dsd;",";")]
        [TestCase("id;dsd;",";")]
        [TestCase("id;dsd;",";")]
        public void GivenValidInput_ThenIsValidIsTrue(string csvLines, string delimiter)
        {
            //arrange
            var request = new ImportAssetsRequest
            {
                Delimiter = delimiter,
                AssetLines = new List<string>{csvLines}
            };
            //act
            var response = _classUnderTest.Validate(request);
            //assert
            response.Should().NotBeNull();
            response.IsValid.Should().BeTrue();
        }

        [TestCase(null, ";")]
        [TestCase("id;dsd;", null)]
        [TestCase(null, null)]
        public void GivenInValidRequest_ThenIsValidIsFalse(string csvLines, string delimiter)
        {
            //arrange
            var request = new ImportAssetsRequest
            {
                Delimiter = delimiter,
                AssetLines = new List<string> { csvLines }
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
