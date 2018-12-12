using System;
using FluentAssertions;
using HomesEngland.Domain;

namespace HomesEngland.Gateway.Test
{
    public static class AssetTestExtensions
    {
        public static void AssetIsEqual(this IAsset readAsset, int id, IAsset entity)
        {
            readAsset.Id.Should().Be(id);
            readAsset.ModifiedDateTime.Should().BeCloseTo(entity.ModifiedDateTime, TimeSpan.FromMilliseconds(1.0));

            readAsset.Programme.Should().BeEquivalentTo(entity.Programme);
            readAsset.EquityOwner.Should().BeEquivalentTo(entity.EquityOwner);
            readAsset.SchemeId.Should().Be(entity.SchemeId);
            readAsset.LocationLaRegionName.Should().BeEquivalentTo(entity.LocationLaRegionName);
            readAsset.ImsOldRegion.Should().BeEquivalentTo(entity.ImsOldRegion);
            readAsset.NoOfBeds.Should().Be(entity.NoOfBeds);
            readAsset.Address.Should().BeEquivalentTo(entity.Address);
            readAsset.PropertyHouseName.Should().BeEquivalentTo(entity.PropertyHouseName);
            readAsset.PropertyStreetNumber.Should().BeEquivalentTo(entity.PropertyStreetNumber);
            readAsset.PropertyStreet.Should().BeEquivalentTo(entity.PropertyStreet);
            readAsset.PropertyTown.Should().BeEquivalentTo(entity.PropertyTown);
            readAsset.PropertyPostcode.Should().BeEquivalentTo(entity.PropertyPostcode);
            readAsset.DevelopingRslName.Should().BeEquivalentTo(entity.DevelopingRslName);
            readAsset.LBHA.Should().BeEquivalentTo(entity.LBHA);
            readAsset.CompletionDateForHpiStart.Should().BeCloseTo(entity.CompletionDateForHpiStart.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.ImsActualCompletionDate.Should().BeCloseTo(entity.ImsActualCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.ImsExpectedCompletionDate.Should().BeCloseTo(entity.ImsExpectedCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.ImsLegalCompletionDate.Should().BeCloseTo(entity.ImsLegalCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.HopCompletionDate.Should().BeCloseTo(entity.HopCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.Deposit.Should().Be(entity.Deposit);
            readAsset.AgencyEquityLoan.Should().Be(entity.AgencyEquityLoan);
            readAsset.DeveloperEquityLoan.Should().Be(entity.DeveloperEquityLoan);
            readAsset.ShareOfRestrictedEquity.Should().Be(entity.ShareOfRestrictedEquity);
            readAsset.DeveloperDiscount.Should().Be(entity.DeveloperDiscount);
            readAsset.Mortgage.Should().Be(entity.Mortgage);
            readAsset.PurchasePrice.Should().Be(entity.PurchasePrice);
            readAsset.Fees.Should().Be(entity.Fees);
            readAsset.HistoricUnallocatedFees.Should().Be(entity.HistoricUnallocatedFees);
            readAsset.ActualAgencyEquityCostIncludingHomeBuyAgentFee.Should().Be(entity.ActualAgencyEquityCostIncludingHomeBuyAgentFee);
            readAsset.FullDisposalDate.Should().BeCloseTo(entity.FullDisposalDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.OriginalAgencyPercentage.Should().Be(entity.OriginalAgencyPercentage);
            readAsset.StaircasingPercentage.Should().Be(entity.StaircasingPercentage);
            readAsset.NewAgencyPercentage.Should().Be(entity.NewAgencyPercentage);
            readAsset.Invested.Should().Be(entity.Invested);
            readAsset.Month.Should().Be(entity.Month);
            readAsset.CalendarYear.Should().Be(entity.CalendarYear);
            readAsset.MMYYYY.Should().BeEquivalentTo(entity.MMYYYY);
            readAsset.Row.Should().Be(entity.Row);
            readAsset.Col.Should().Be(entity.Col);
            readAsset.HPIStart.Should().Be(entity.HPIStart);
            readAsset.HPIEnd.Should().Be(entity.HPIEnd);
            readAsset.HPIPlusMinus.Should().Be(entity.HPIPlusMinus);
            readAsset.AgencyPercentage.Should().Be(entity.AgencyPercentage);
            readAsset.MortgageEffect.Should().Be(entity.MortgageEffect);
            readAsset.RemainingAgencyCost.Should().Be(entity.RemainingAgencyCost);
            readAsset.WAEstimatedPropertyValue.Should().Be(entity.WAEstimatedPropertyValue);
            readAsset.AgencyFairValueDifference.Should().Be(entity.AgencyFairValueDifference);
            readAsset.ImpairmentProvision.Should().Be(entity.ImpairmentProvision);
            readAsset.FairValueReserve.Should().Be(entity.FairValueReserve);
            readAsset.AgencyFairValue.Should().Be(entity.AgencyFairValue);
            readAsset.DisposalsCost.Should().Be(entity.DisposalsCost);
            readAsset.DurationInMonths.Should().Be(entity.DurationInMonths);
            readAsset.MonthOfCompletionSinceSchemeStart.Should().Be(entity.MonthOfCompletionSinceSchemeStart);
            readAsset.DisposalMonthSinceCompletion.Should().Be(entity.DisposalMonthSinceCompletion);
            readAsset.IMSPaymentDate.Should().BeCloseTo(entity.IMSPaymentDate.Value, TimeSpan.FromMilliseconds(1.0));
            readAsset.IsPaid.Should().Be(entity.IsPaid);
            readAsset.IsAsset.Should().Be(entity.IsAsset);
            readAsset.PropertyType.Should().BeEquivalentTo(entity.PropertyType);
            readAsset.Tenure.Should().BeEquivalentTo(entity.Tenure);
            readAsset.ExpectedStaircasingRate.Should().Be(entity.ExpectedStaircasingRate);
            readAsset.EstimatedSalePrice.Should().Be(entity.EstimatedSalePrice);
            readAsset.RegionalSaleAdjust.Should().Be(entity.RegionalSaleAdjust);
            readAsset.RegionalStairAdjust.Should().Be(entity.RegionalStairAdjust);
            readAsset.NotLimitedByFirstCharge.Should().Be(entity.NotLimitedByFirstCharge);
            readAsset.EarlyMortgageIfNeverRepay.Should().Be(entity.EarlyMortgageIfNeverRepay);
            readAsset.ArrearsEffectAppliedOrLimited.Should().Be(entity.ArrearsEffectAppliedOrLimited);
            readAsset.RelativeSalePropertyTypeAndTenureAdjustment.Should().Be(entity.RelativeSalePropertyTypeAndTenureAdjustment);
            readAsset.RelativeStairPropertyTypeAndTenureAdjustment.Should().Be(entity.RelativeStairPropertyTypeAndTenureAdjustment);
            readAsset.IsLondon.Should().Be(entity.IsLondon);
            readAsset.QuarterSpend.Should().Be(entity.QuarterSpend);
            readAsset.MortgageProvider.Should().Be(entity.MortgageProvider);
            readAsset.HouseType.Should().Be(entity.HouseType);
            readAsset.PurchasePriceBand.Should().Be(entity.PurchasePriceBand);
            readAsset.HouseholdFiveKIncomeBand.Should().Be(entity.HouseholdFiveKIncomeBand);
            readAsset.HouseholdFiftyKIncomeBand.Should().Be(entity.HouseholdFiftyKIncomeBand);
            readAsset.FirstTimeBuyer.Should().Be(entity.FirstTimeBuyer);
        }
    }
}
