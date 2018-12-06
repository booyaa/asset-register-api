using System;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.GenerateAssets;
using HomesEngland.UseCase.ImportAssets;
using HomesEngland.UseCase.ImportAssets.Impl;
using HomesEngland.UseCase.ImportAssets.Models;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using HomesEngland.UseCase.Models;

namespace HomesEnglandTest.UseCase.ImportAssets
{
    [TestFixture]
    public class ConsoleImporterTests
    {
        public IConsoleImporter _classUnderTest;
        public Mock<ILogger<IConsoleImporter>> _mockLogger;
        public Mock<IImportAssetsUseCase> _mockImportAssetUseCase;
        public IInputParser<ImportAssetConsoleInput> _inputParser;
        public Mock<IFileReader<string>> _mockFileReader;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<IConsoleImporter>>();
            _mockImportAssetUseCase = new Mock<IImportAssetsUseCase>();
            _inputParser = new ImportAssetInputParser();
            _mockFileReader = new Mock<IFileReader<string>>();
            _classUnderTest = new ConsoleImporter(_mockImportAssetUseCase.Object, _inputParser, _mockFileReader.Object, _mockLogger.Object);
        }

        [TestCase("--file", "test.csv", "--delimiter", ";")]
        [TestCase("--file", "TEST.CSV", "--delimiter", ";")]
        [TestCase("--file", "Test.csv", "--delimiter", ";")]
        public async Task GivenWeNeedToImportAssets_WhenWeDoSoThroughAConsoleInterface_ThenWeCallImportAssetsUseCase(string arg1, string arg2, string arg3, string arg4)
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

        [TestCase("--file", "test.csv", "--delimiter", ";")]
        [TestCase("--file", "TEST.CSV", "--delimiter", ";")]
        [TestCase("--file", "Test.csv", "--delimiter", ";")]
        public async Task GivenWeNeedToImportAssets_WhenWeDoSoThroughAConsoleInterface_ThenWeCallFileReader(string arg1, string arg2, string arg3, string arg4)
        {
            //arrange
            var args = new string[] { arg1, arg2, arg3, arg4 };
            //act
            await _classUnderTest.ProcessAsync(args).ConfigureAwait(false);
            //assert
            _mockFileReader.Verify(s => s.ReadAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestCase("--file", "test.csv", "--delimiter", ";")]
        [TestCase("--file", "TEST.CSV", "--delimiter", ";")]
        [TestCase("--file", "Test.csv", "--delimiter", ";")]
        public async Task GivenWeNeedToImportAssets_WhenWeWantToReadFileContents_ThenWeCallFileReaderWithFilePath(string arg1, string arg2, string arg3, string arg4)
        {
            //arrange
            var args = new string[] { arg1, arg2, arg3, arg4 };
            //act
            await _classUnderTest.ProcessAsync(args).ConfigureAwait(false);
            //assert
            _mockFileReader.Verify(s => s.ReadAsync(It.Is<string>(i=> i.Equals(arg2)), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
