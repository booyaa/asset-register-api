using System;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.UseCase.GetAsset.Models;

namespace TestHelper
{
    public static class AssetOutputModelTestHelper
    {
        public static void AssetOutputModelIsEqual(this AssetOutputModel assetOutputModel, IAsset entity)
        {
            assetOutputModel.Id.Should().Be(entity.Id);
            assetOutputModel.AccountingYear.Should().BeEquivalentTo(entity.AccountingYear);
            assetOutputModel.Address.Should().BeEquivalentTo(entity.Address);
            assetOutputModel.AgencyEquityLoan.Should().Be(entity.AgencyEquityLoan);
            assetOutputModel.CompletionDateForHpiStart.Should().BeCloseTo(entity.CompletionDateForHpiStart.Value, TimeSpan.FromMilliseconds(1.0));
            assetOutputModel.Deposit.Should().Be(entity.Deposit);
            assetOutputModel.DeveloperEquityLoan.Should().Be(entity.DeveloperEquityLoan);
            assetOutputModel.DevelopingRslName.Should().Be(entity.DevelopingRslName);
            assetOutputModel.DifferenceFromImsExpectedCompletionToHopCompletionDate.Should().Be(entity.DifferenceFromImsExpectedCompletionToHopCompletionDate);
            assetOutputModel.HopCompletionDate.Should().BeCloseTo(entity.HopCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            assetOutputModel.ImsActualCompletionDate.Should().BeCloseTo(entity.ImsActualCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            assetOutputModel.ImsExpectedCompletionDate.Should().BeCloseTo(entity.ImsExpectedCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            assetOutputModel.ImsLegalCompletionDate.Should().BeCloseTo(entity.ImsLegalCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            assetOutputModel.ImsOldRegion.Should().BeEquivalentTo(entity.ImsOldRegion);
            assetOutputModel.LocationLaRegionName.Should().BeEquivalentTo(entity.LocationLaRegionName);
            assetOutputModel.MonthPaid.Should().BeEquivalentTo(entity.MonthPaid);
            assetOutputModel.NoOfBeds.Should().BeEquivalentTo(entity.NoOfBeds);
            assetOutputModel.SchemeId.Should().Be(entity.SchemeId);
            assetOutputModel.ShareOfRestrictedEquity.Should().Be(entity.ShareOfRestrictedEquity);
        }
    }
}
