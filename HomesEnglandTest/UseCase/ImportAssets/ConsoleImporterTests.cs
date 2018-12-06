using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.GenerateAssets;
using HomesEngland.UseCase.GenerateAssets.Models;
using HomesEngland.UseCase.ImportAssets;
using HomesEngland.UseCase.ImportAssets.Impl;
using HomesEngland.UseCase.ImportAssets.Models;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.ImportAssets
{
    [TestFixture]
    public class ConsoleImporterTests
    {
        public IConsoleImporter _classUnderTest;
        public Mock<ILogger<IConsoleImporter>> _mockLogger;
        public Mock<IImportAssetsUseCase> _mockImportAssetUseCase;
        public IInputParser<ImportAssetsRequest> _inputParser;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<IConsoleImporter>>();
            _mockImportAssetUseCase = new Mock<IImportAssetsUseCase>();
            _inputParser = new ImportAssetInputParser();
            _classUnderTest = new ConsoleImporter(_mockImportAssetUseCase.Object, _inputParser, _mockLogger.Object);
        }

        [TestCase("--file", "test.csv", "--delimiter", ";")]
        [TestCase("--file", "TEST.CSV", "--delimiter", ";")]
        [TestCase("--file", "Test.csv", "--delimiter", ";")]
        public async Task GivenWeNeedToGenerateAssets_WhenWeDoSoThroughAConsoleInterface_ThenWeCallGenerateAssets(string arg1, string arg2, string arg3, string arg4)
        {
            //arrange
            var args = new string[] { arg1, arg2, arg3, arg4 };
            //act
            await _classUnderTest.ProcessAsync(args).ConfigureAwait(false);
            //assert
            _mockImportAssetUseCase.Verify(s => s.ExecuteAsync(It.IsAny<ImportAssetsRequest>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestCase("--file", "test.csv", "--delimiter", ";")]
        [TestCase("--file", "TEST.CSV", "--delimiter", ",")]
        [TestCase("--file", "Test.csv", "--delimiter", "\t")]
        public async Task GivenValidInput_WhenWeRunTheGenerator_ThenTheArgumentsArePassedIn(string arg1, string arg2, string arg3, string arg4)
        {
            //arrange
            var args = new string[] { arg1, arg2, arg3, arg4 };
            //act
            await _classUnderTest.ProcessAsync(args).ConfigureAwait(false);
            //assert
            _mockImportAssetUseCase.Verify(s => s.ExecuteAsync(It.Is<ImportAssetsRequest>(i => i.Delimiter.Equals(arg4)), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestCase("--file", "test.csv", "--delimiter", ";")]
        [TestCase("--file", "TEST.CSV", "--delimiter", ",")]
        [TestCase("--file", "Test.csv", "--delimiter", "\t")]
        public async Task GivenValidInput_WhenWeRunTheGenerator_ThenTheInputParserIsCalled(string arg1, string arg2, string arg3, string arg4)
        {
            //arrange
            var args = new string[] { arg1, arg2, arg3, arg4 };
            //act
            await _classUnderTest.ProcessAsync(args).ConfigureAwait(false);
            //assert
            _mockImportAssetUseCase.Verify(s => s.ExecuteAsync(It.Is<ImportAssetsRequest>(i => i.Delimiter.Equals(arg4)), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public void GivenInValidInput_WhenWeRunTheGenerator_ThenWeThrowAnException()
        {
            //arrange
            string[] args = null;
            //act
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _classUnderTest.ProcessAsync(args).ConfigureAwait(false));
        }
    }
}
