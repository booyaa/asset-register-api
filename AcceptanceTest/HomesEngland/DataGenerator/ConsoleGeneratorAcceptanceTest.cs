using System.Threading.Tasks;
using HomesEngland.Gateway.DataGenerator;
using HomesEngland.UseCase.GenerateAssets;
using Main;
using NUnit.Framework;

namespace AssetRegisterTests.HomesEngland.DataGenerator
{
    [TestFixture]
    public class ConsoleGeneratorAcceptanceTests
    {
        private IConsoleGenerator _classUnderTest;

        public ConsoleGeneratorAcceptanceTests()
        {
            var assetRegister = new AssetRegister();
            _classUnderTest = assetRegister.Get<IConsoleGenerator>();
        }

        [TestCase("--records", "1")]
        [TestCase("--records", "2")]
        [TestCase("--records", "3")]
        public async Task GivenWeNeedToGenerateAssets_WhenWeDoSoThroughAConsoleInterface_ThenTheArgumentsArePassedIn(string arg1, string arg2)
        {
            //arrange
            var args = new string[] {arg1, arg2};
            //act
            await _classUnderTest.ProcessAsync(args).ConfigureAwait(false);
            //assert

        }

        [TestCase("--records", "1")]
        [TestCase("--records", "2")]
        [TestCase("--records", "3")]
        public async Task GivenWeNeedToGenerateAssets_WhenWeDoSoThroughAConsoleInterface_ThenWeCanGenerateThem(string arg1, string arg2)
        {
            //arrange
            var args = new string[] { arg1, arg2 };
            //act
            await _classUnderTest.ProcessAsync(args).ConfigureAwait(false);
            //assert
        }
    }
}
