using System;
using FluentAssertions;
using HomesEngland.Domain;

namespace TestHelper
{
    public static class AssetTestHelper
    {
        public static void AssetIsEqual(this IAsset readAsset, IAsset entity)
        {
            readAsset.Id.Should().Be(entity.Id);
            readAsset.AccountingYear.Should().BeEquivalentTo(entity.AccountingYear);
            readAsset.Address.Should().BeEquivalentTo(entity.Address);
            readAsset.AgencyEquityLoan.Should().Be(entity.AgencyEquityLoan);
            readAsset.CompletionDateForHpiStart.Should().BeCloseTo(entity.CompletionDateForHpiStart.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.Deposit.Should().Be(entity.Deposit);
            readAsset.DeveloperEquityLoan.Should().Be(entity.DeveloperEquityLoan);
            readAsset.DevelopingRslName.Should().Be(entity.DevelopingRslName);
            readAsset.DifferenceFromImsExpectedCompletionToHopCompletionDate.Should().Be(entity.DifferenceFromImsExpectedCompletionToHopCompletionDate);
            readAsset.HopCompletionDate.Should().BeCloseTo(entity.HopCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.ImsActualCompletionDate.Should().BeCloseTo(entity.ImsActualCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.ImsExpectedCompletionDate.Should().BeCloseTo(entity.ImsExpectedCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.ImsLegalCompletionDate.Should().BeCloseTo(entity.ImsLegalCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.ImsOldRegion.Should().BeEquivalentTo(entity.ImsOldRegion);
            readAsset.LocationLaRegionName.Should().BeEquivalentTo(entity.LocationLaRegionName);
            readAsset.MonthPaid.Should().BeEquivalentTo(entity.MonthPaid);
            readAsset.NoOfBeds.Should().BeEquivalentTo(entity.NoOfBeds);
            readAsset.SchemeId.Should().Be(entity.SchemeId);
            readAsset.ShareOfRestrictedEquity.Should().Be(entity.ShareOfRestrictedEquity);
        }
    }
}
