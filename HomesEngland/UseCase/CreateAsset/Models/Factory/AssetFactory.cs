using System;
using System.Linq;
using HomesEngland.Domain.Factory;

namespace HomesEngland.UseCase.CreateAsset.Models.Factory
{
    public class CreateAssetRequestFactory:IFactory<CreateAssetRequest, CsvAsset>
    {
        public CreateAssetRequest Create(CsvAsset csvAsset)
        {
            if (csvAsset == null || string.IsNullOrEmpty(csvAsset.CsvLine) || string.IsNullOrWhiteSpace(csvAsset.CsvLine) || string.IsNullOrWhiteSpace(csvAsset.Delimiter) || string.IsNullOrEmpty(csvAsset.Delimiter))
                return null;

            var fields = csvAsset?.CsvLine?.Split(csvAsset.Delimiter);
            int.TryParse(fields.ElementAtOrDefault(2), out var schemeId);
            int.TryParse(fields.ElementAtOrDefault(5), out var noOfBeds);
            DateTime.TryParse(fields.ElementAtOrDefault(14), out var completionDateForHpiStart);
            DateTime.TryParse(fields.ElementAtOrDefault(15), out var imsActualCompletionDate);
            DateTime.TryParse(fields.ElementAtOrDefault(16), out var imsExpectedCompletionDate);
            DateTime.TryParse(fields.ElementAtOrDefault(17), out var imsLegalCompletionDate);
            DateTime.TryParse(fields.ElementAtOrDefault(18), out var hopCompletionDate);
            decimal.TryParse(fields.ElementAtOrDefault(19), out var deposit);
            decimal.TryParse(fields.ElementAtOrDefault(20), out var agencyEquityLoan);
            decimal.TryParse(fields.ElementAtOrDefault(21), out var developerEquityLoan);
            decimal.TryParse(fields.ElementAtOrDefault(22), out var shareOfRestrictedEquity);
            decimal.TryParse(fields.ElementAtOrDefault(23), out var developerDiscount);
            decimal.TryParse(fields.ElementAtOrDefault(24), out var mortgage);
            decimal.TryParse(fields.ElementAtOrDefault(25), out var purchasePrice);
            decimal.TryParse(fields.ElementAtOrDefault(26), out var fees);
            decimal.TryParse(fields.ElementAtOrDefault(27), out var historicUnallocatedFees);
            decimal.TryParse(fields.ElementAtOrDefault(28), out var actualAgencyEquityCostIncludingHomeBuyAgentFee);
            DateTime.TryParse(fields.ElementAtOrDefault(29), out var fullDisposalDate);
            decimal.TryParse(fields.ElementAtOrDefault(30), out var originalAgencyPercentage);
            decimal.TryParse(fields.ElementAtOrDefault(31), out var staircasingPercentage);
            decimal.TryParse(fields.ElementAtOrDefault(32), out var newAgencyPercentage);
            int.TryParse(fields.ElementAtOrDefault(33), out var invested);
            int.TryParse(fields.ElementAtOrDefault(34), out var month);
            int.TryParse(fields.ElementAtOrDefault(36), out var calendarYear);
            int.TryParse(fields.ElementAtOrDefault(37), out var row);
            int.TryParse(fields.ElementAtOrDefault(38), out var col);
            decimal.TryParse(fields.ElementAtOrDefault(39), out var hpiStart);
            decimal.TryParse(fields.ElementAtOrDefault(40), out var hpiEnd);
            decimal.TryParse(fields.ElementAtOrDefault(41), out var hpiPlusMinus);
            decimal.TryParse(fields.ElementAtOrDefault(42), out var agencyPercentage);
            decimal.TryParse(fields.ElementAtOrDefault(43), out var mortgageEffect);
            decimal.TryParse(fields.ElementAtOrDefault(44), out var remainingAgencyCost);
            decimal.TryParse(fields.ElementAtOrDefault(45), out var waEstimatedPropertyValue);
            decimal.TryParse(fields.ElementAtOrDefault(46), out var agencyFairValueDifference);
            decimal.TryParse(fields.ElementAtOrDefault(47), out var impairmentProvision);
            decimal.TryParse(fields.ElementAtOrDefault(48), out var fairValueReserve);
            decimal.TryParse(fields.ElementAtOrDefault(49), out var agencyFairValue);
            decimal.TryParse(fields.ElementAtOrDefault(50), out var disposalsCost);
            decimal.TryParse(fields.ElementAtOrDefault(51), out var durationInMonths);
            decimal.TryParse(fields.ElementAtOrDefault(52), out var monthOfCompletionSinceSchemeStart);
            decimal.TryParse(fields.ElementAtOrDefault(53), out var disposalMonthSinceCompletion);
            DateTime.TryParse(fields.ElementAtOrDefault(54), out var imsPaymentDate);
            bool.TryParse(fields.ElementAtOrDefault(55), out var isPaid);
            bool.TryParse(fields.ElementAtOrDefault(58), out var isAsset);
            decimal.TryParse(fields.ElementAtOrDefault(59), out var expectedStaircasingRate);
            decimal.TryParse(fields.ElementAtOrDefault(60), out var estimatedSalePrice);
            decimal.TryParse(fields.ElementAtOrDefault(61), out var regionalSaleAdjust);
            decimal.TryParse(fields.ElementAtOrDefault(63), out var regionalStairAdjust);
            bool.TryParse(fields.ElementAtOrDefault(64), out var notLimitedByFirstCharge);
            decimal.TryParse(fields.ElementAtOrDefault(65), out var earlyMortgageIfNeverRepay);
            decimal.TryParse(fields.ElementAtOrDefault(66), out var relativeSalePropertyTypeAndTenureAdjustment);
            decimal.TryParse(fields.ElementAtOrDefault(69), out var relativeStairPropertyTypeAndTenureAdjustment);
            bool.TryParse(fields.ElementAtOrDefault(70), out var isLondon);
            decimal.TryParse(fields.ElementAtOrDefault(71), out var quarterSpend);
            decimal.TryParse(fields.ElementAtOrDefault(72), out var purchasePriceBand);
            decimal.TryParse(fields.ElementAtOrDefault(73), out var householdFiveKIncomeBand);
            decimal.TryParse(fields.ElementAtOrDefault(74), out var householdFiftyKIncomeBand);
            bool.TryParse(fields.ElementAtOrDefault(75), out var firstTimeBuyer);
            var createAssetRequest = new CreateAssetRequest
            {
                Programme = fields.ElementAtOrDefault(0),
                EquityOwner = fields.ElementAtOrDefault(1),
                SchemeId = schemeId,
                LocationLaRegionName = fields.ElementAtOrDefault(3),
                ImsOldRegion = fields.ElementAtOrDefault(4),
                NoOfBeds = noOfBeds,
                Address = fields.ElementAtOrDefault(6),
                PropertyHouseName = fields.ElementAtOrDefault(7),
                PropertyStreetNumber = fields.ElementAtOrDefault(8),
                PropertyStreet = fields.ElementAtOrDefault(9),
                PropertyTown = fields.ElementAtOrDefault(10),
                PropertyPostcode = fields.ElementAtOrDefault(11),
                DevelopingRslName = fields.ElementAtOrDefault(12),
                LBHA = fields.ElementAtOrDefault(13),
                CompletionDateForHpiStart = completionDateForHpiStart,
                ImsActualCompletionDate = imsActualCompletionDate,
                ImsExpectedCompletionDate = imsExpectedCompletionDate,
                ImsLegalCompletionDate = imsLegalCompletionDate,
                HopCompletionDate = hopCompletionDate,
                Deposit = deposit,
                AgencyEquityLoan = agencyEquityLoan,
                DeveloperEquityLoan = developerEquityLoan,
                ShareOfRestrictedEquity = shareOfRestrictedEquity,
                DeveloperDiscount = developerDiscount,
                Mortgage = mortgage,
                PurchasePrice = purchasePrice,
                Fees = fees,
                HistoricUnallocatedFees = historicUnallocatedFees,
                ActualAgencyEquityCostIncludingHomeBuyAgentFee = actualAgencyEquityCostIncludingHomeBuyAgentFee,
                FullDisposalDate = fullDisposalDate,
                OriginalAgencyPercentage = originalAgencyPercentage,
                StaircasingPercentage = staircasingPercentage,
                NewAgencyPercentage = newAgencyPercentage,
                Invested = invested,
                Month = month,
                CalendarYear = calendarYear,
                MMYYYY = fields.ElementAtOrDefault(35),
                Row = row,
                Col = col,
                HPIStart = hpiStart,
                HPIEnd = hpiEnd,
                HPIPlusMinus = hpiPlusMinus,
                AgencyPercentage = agencyPercentage,
                MortgageEffect = mortgageEffect,
                RemainingAgencyCost = remainingAgencyCost,
                WAEstimatedPropertyValue = waEstimatedPropertyValue,
                AgencyFairValueDifference = agencyFairValueDifference,
                ImpairmentProvision = impairmentProvision,
                FairValueReserve = fairValueReserve,
                AgencyFairValue = agencyFairValue,
                DisposalsCost = disposalsCost,
                DurationInMonths = durationInMonths,
                MonthOfCompletionSinceSchemeStart = monthOfCompletionSinceSchemeStart,
                DisposalMonthSinceCompletion = disposalMonthSinceCompletion,
                IMSPaymentDate = imsPaymentDate,
                IsPaid = isPaid,
                IsAsset = isAsset,
                PropertyType = fields.ElementAtOrDefault(56),
                Tenure = fields.ElementAtOrDefault(57),
                ExpectedStaircasingRate = expectedStaircasingRate,
                EstimatedSalePrice = estimatedSalePrice,
                RegionalSaleAdjust = regionalSaleAdjust,
                RegionalStairAdjust = regionalStairAdjust,
                NotLimitedByFirstCharge = notLimitedByFirstCharge,
                EarlyMortgageIfNeverRepay = earlyMortgageIfNeverRepay,
                ArrearsEffectAppliedOrLimited = fields.ElementAtOrDefault(62),
                RelativeSalePropertyTypeAndTenureAdjustment = relativeSalePropertyTypeAndTenureAdjustment,
                RelativeStairPropertyTypeAndTenureAdjustment = relativeStairPropertyTypeAndTenureAdjustment,
                IsLondon = isLondon,
                QuarterSpend = quarterSpend,
                MortgageProvider = fields.ElementAtOrDefault(67),
                HouseType = fields.ElementAtOrDefault(68),
                PurchasePriceBand = purchasePriceBand,
                HouseholdFiveKIncomeBand = householdFiveKIncomeBand,
                HouseholdFiftyKIncomeBand = householdFiftyKIncomeBand,
                FirstTimeBuyer = firstTimeBuyer
            };
            return createAssetRequest;
        }
    }
}
