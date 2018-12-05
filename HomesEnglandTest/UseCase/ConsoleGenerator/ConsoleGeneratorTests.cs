using System;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.UseCase.GenerateAssets;
using HomesEngland.UseCase.GenerateAssets.Models;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.ConsoleGenerator
{
    [TestFixture]
    public class ConsoleGeneratorTests
    {
        private IConsoleGenerator _classUnderTest;
        private IInputParser _inputParser;
        private Mock<IGenerateAssetsUseCase> _mockGenerateAssetUseCase;
        private Mock<ILogger<ConsoleAssetGenerator>> _mockLogger;
        [SetUp]
        public void Setup()
        {
            _inputParser = new InputParser();
            _mockGenerateAssetUseCase = new Mock<IGenerateAssetsUseCase>();
            _mockLogger = new Mock<ILogger<ConsoleAssetGenerator>>();
            _classUnderTest = new ConsoleAssetGenerator(_inputParser, _mockGenerateAssetUseCase.Object, _mockLogger.Object);
        }

        [TestCase("--records", "1")]
        [TestCase("--records", "2")]
        [TestCase("--records", "3")]
        public async Task GivenWeNeedToGenerateAssets_WhenWeDoSoThroughAConsoleInterface_ThenWeCallGenerateAssets(string arg1, string arg2)
        {
            //arrange
            var args = new string[] { arg1, arg2 };
            //act
            await _classUnderTest.ProcessAsync(args).ConfigureAwait(false);
            //assert
            _mockGenerateAssetUseCase.Verify(s=> s.ExecuteAsync(It.IsAny<GenerateAssetsRequest>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestCase("--records", "1")]
        [TestCase("--records", "2")]
        [TestCase("--records", "3")]
        public async Task GivenValidInput_WhenWeRunTheGenerator_ThenTheArgumentsArePassedIn(string arg1, string arg2)
        {
            //arrange
            var args = new string[] { arg1, arg2 };
            //act
            await _classUnderTest.ProcessAsync(args).ConfigureAwait(false);
            //assert
            _mockGenerateAssetUseCase.Verify(s => s.ExecuteAsync(It.Is<GenerateAssetsRequest>(i=> i.Records == int.Parse(arg2)), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
