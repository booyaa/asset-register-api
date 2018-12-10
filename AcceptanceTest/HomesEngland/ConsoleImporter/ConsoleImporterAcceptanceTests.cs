using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.Gateway.Migrations;
using HomesEngland.UseCase.ImportAssets;
using Main;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AssetRegisterTests.HomesEngland.ConsoleImporter
{
    [TestFixture]
    public class ConsoleImporterAcceptanceTests
    {
        private IConsoleImporter _classUnderTest;
        [SetUp]
        public void Setup()
        {
            var assetRegister = new AssetRegister();
            var context = assetRegister.Get<AssetRegisterContext>();
            context.Database.Migrate();
            _classUnderTest = assetRegister.Get<IConsoleImporter>();
        }

        [TestCase(1,"--file",".\\asset-register-1-row.csv", "--delimiter", ";")]
        [TestCase(5,"--file",".\\asset-register-5-row.csv", "--delimiter", ";")]
        [TestCase(10,"--file",".\\asset-register-10-row.csv","--delimiter", ";")]
        public async Task GivenValidFilePathAndDemiliter_WhenWeCallProcess_ThenWeImportTheCsv(int expectedCount, string fileFlag, string fileValue, string delimiterFlag, string delimiterValue)
        {
            //arrange
            var args = new[] { fileFlag, fileValue, delimiterFlag, delimiterValue };
            //act
            var response = await _classUnderTest.ProcessAsync(args).ConfigureAwait(false);
            //assert
            response.Should().NotBeNullOrEmpty();
            response.Count.Should().Be(expectedCount);
        }
    }
}
