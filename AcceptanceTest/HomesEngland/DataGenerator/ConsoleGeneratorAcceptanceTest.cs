using System.Threading.Tasks;
using HomesEngland.Gateway.Migrations;
using HomesEngland.UseCase.GenerateAssets;
using Main;
using Microsoft.EntityFrameworkCore;
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
            var context = assetRegister.Get<AssetRegisterContext>();
            context.Database.Migrate();
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
            Assert.Fail();
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
            Assert.Fail();
        }
    }
}
