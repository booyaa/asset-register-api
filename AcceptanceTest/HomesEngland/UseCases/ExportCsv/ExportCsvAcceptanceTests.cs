using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.ExportCsv;
using HomesEngland.UseCase.ExportCsv.Models;
using HomesEngland.UseCase.SearchAsset;
using HomesEngland.UseCase.SearchAsset.Models;
using Main;
using NUnit.Framework;
using TestHelper;

namespace AssetRegisterTests.HomesEngland.UseCases.ExportCsv
{
    [TestFixture]
    public class ExportCsvAcceptanceTests
    {
        private IExportCsvUseCase _classUnderTest;
        private ICreateAssetUseCase _createAssetUseCase;
        private ISearchAssetUseCase _searchAssetUseCase;
        [SetUp]
        public void Setup()
        {
            var assetRegister = new AssetRegister();
            _createAssetUseCase = assetRegister.Get<ICreateAssetUseCase>();
            _searchAssetUseCase = assetRegister.Get<ISearchAssetUseCase>();
            _classUnderTest = new ExportCsvUseCase();
        }


        [TestCase(1, "1234 place")]
        [TestCase(2, "5678 street")]
        [TestCase(3, "9101112 road")]
        public async Task GivenXAssets_ThenWeCanExportThemAsCsv(int recordCount, string address)
        {   
            
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                //arrange
                await CreateXAssets(recordCount, address);

                var searchResults = await _searchAssetUseCase.ExecuteAsync(new SearchAssetRequest
                {
                    Address = address,
                    PageSize = recordCount,
                    Page = 1
                }, CancellationToken.None).ConfigureAwait(false);

                //act
                var exportCsvResponse = await _classUnderTest.ExecuteAsync(new ExportCsvRequest
                {
                    Assets = searchResults.Assets
                }, CancellationToken.None).ConfigureAwait(false);

                //assert
                exportCsvResponse.Csv.Should().NotBeNullOrEmpty();
                trans.Dispose();
            }
        }

        private async Task CreateXAssets(int recordCount, string address)
        {
            for (int i = 0; i < recordCount; i++)
            {
                var request = TestData.UseCase.GenerateCreateAssetRequest();
                request.Address = address;
                await _createAssetUseCase.ExecuteAsync(request, CancellationToken.None).ConfigureAwait(false);
            }
        }
    }
}
