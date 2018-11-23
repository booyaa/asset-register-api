using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.CreateAsset.Impl;
using NUnit.Framework;
using TestHelper;

namespace HomesEnglandTest.UseCase.CreateAsset
{
    public class CreateAssetTests
    {
        private class AssetCreatorSpy : IAssetCreator
        {
            public IAsset CalledWith;
            public int CreatedId;

            public async Task<IAsset> CreateAsync(IAsset entity)
            {
                CalledWith = entity;
                entity.Id = CreatedId;
                return entity;
            }
        }

        private readonly ICreateAssetUseCase _classUnderTest;
        private readonly AssetCreatorSpy _gateway;

        public CreateAssetTests()
        {
            _gateway = new AssetCreatorSpy();
            _classUnderTest = new CreateAssetUseCase(_gateway);
        }

        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        public async Task GivenValidRequest_UseCaseCallsGatewayWithCorrectDomainObject(int schemeId, int createdAssetId)
        {
            _gateway.CreatedId = createdAssetId;

            var request = TestData.UseCase.GenerateCreateAssetRequest();
            request.SchemeId = schemeId;

            await _classUnderTest.ExecuteAsync(request, CancellationToken.None);

            var asset = _gateway.CalledWith;

            asset.AccountingYear.Should().BeEquivalentTo(request.AccountingYear);
            asset.Address.Should().BeEquivalentTo(request.Address);
            asset.AgencyEquityLoan.Should().Be(request.AgencyEquityLoan);
            asset.CompletionDateForHpiStart.Should()
                .BeCloseTo(request.CompletionDateForHpiStart.Value, TimeSpan.FromMilliseconds(1.0));
            asset.Deposit.Should().Be(request.Deposit);
            asset.DeveloperEquityLoan.Should().Be(request.DeveloperEquityLoan);
            asset.DevelopingRslName.Should().Be(request.DevelopingRslName);
            asset.DifferenceFromImsExpectedCompletionToHopCompletionDate.Should()
                .Be(request.DifferenceFromImsExpectedCompletionToHopCompletionDate);
            asset.HopCompletionDate.Should().BeCloseTo(request.HopCompletionDate.Value,
                TimeSpan.FromMilliseconds(1.0));
            asset.ImsActualCompletionDate.Should().BeCloseTo(request.ImsActualCompletionDate.Value,
                TimeSpan.FromMilliseconds(1.0));
            asset.ImsExpectedCompletionDate.Should()
                .BeCloseTo(request.ImsExpectedCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            asset.ImsLegalCompletionDate.Should().BeCloseTo(request.ImsLegalCompletionDate.Value,
                TimeSpan.FromMilliseconds(1.0));
            asset.ImsOldRegion.Should().BeEquivalentTo(request.ImsOldRegion);
            asset.LocationLaRegionName.Should().BeEquivalentTo(request.LocationLaRegionName);
            asset.MonthPaid.Should().BeEquivalentTo(request.MonthPaid);
            asset.NoOfBeds.Should().BeEquivalentTo(request.NoOfBeds);
            asset.SchemeId.Should().Be(request.SchemeId);
            asset.ShareOfRestrictedEquity.Should().Be(request.ShareOfRestrictedEquity);
        }
    }
}
