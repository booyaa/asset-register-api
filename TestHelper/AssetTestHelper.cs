using System;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.GetAsset.Models;

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

        public static bool AssetIsEqual(this IAsset readAsset, CreateAssetRequest entity)
        {
            return
                readAsset.AccountingYear.Equals(entity.AccountingYear) &&
                readAsset.Address.Equals(entity.Address) &&
                readAsset.AgencyEquityLoan.Equals(entity.AgencyEquityLoan) &&
                readAsset.CompletionDateForHpiStart.Equals(entity.CompletionDateForHpiStart.Value) &&
                readAsset.Deposit.Equals(entity.Deposit) &&
                readAsset.DeveloperEquityLoan.Equals(entity.DeveloperEquityLoan) &&
                readAsset.DevelopingRslName.Equals(entity.DevelopingRslName) &&
                readAsset.DifferenceFromImsExpectedCompletionToHopCompletionDate.Equals(entity.DifferenceFromImsExpectedCompletionToHopCompletionDate) &&
                readAsset.HopCompletionDate.Equals(entity.HopCompletionDate.Value) &&
                readAsset.ImsActualCompletionDate.Equals(entity.ImsActualCompletionDate.Value) &&
                readAsset.ImsExpectedCompletionDate.Equals(entity.ImsExpectedCompletionDate.Value) &&
                readAsset.ImsLegalCompletionDate.Equals(entity.ImsLegalCompletionDate.Value) &&
                readAsset.ImsOldRegion.Equals(entity.ImsOldRegion) &&
                readAsset.LocationLaRegionName.Equals(entity.LocationLaRegionName) &&
                readAsset.MonthPaid.Equals(entity.MonthPaid) &&
                readAsset.NoOfBeds.Equals(entity.NoOfBeds) &&
                readAsset.SchemeId.Equals(entity.SchemeId) &&
                readAsset.ShareOfRestrictedEquity.Equals(entity.ShareOfRestrictedEquity);
        }

        public static void AssetOutputModelIsEqual(this AssetOutputModel readAsset, CreateAssetRequest entity)
        {
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

        public static void AssetOutputModelIsEqual(this AssetOutputModel readAsset, AssetOutputModel entity)
        {
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
