using System;
using System.Linq;
using HomesEngland.Domain.Factory;
using HomesEngland.UseCase.ImportAssets.Models.ParserExtensions;

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
            DateTime? completionDateForHpiStart = fields.ElementAtOrDefault(14).TryParseDateTimeNullable();
            DateTime? imsActualCompletionDate = fields.ElementAtOrDefault(15).TryParseDateTimeNullable();
            DateTime? imsExpectedCompletionDate = fields.ElementAtOrDefault(16).TryParseDateTimeNullable();
            DateTime? imsLegalCompletionDate = fields.ElementAtOrDefault(17).TryParseDateTimeNullable();
            DateTime? hopCompletionDate = fields.ElementAtOrDefault(18).TryParseDateTimeNullable();

            decimal? deposit = fields.ElementAtOrDefault(19).TryParseDecimalNullable();
            decimal? agencyEquityLoan = fields.ElementAtOrDefault(20).TryParseDecimalNullable();
            decimal? developerEquityLoan = fields.ElementAtOrDefault(21).TryParseDecimalNullable();
            decimal? shareOfRestrictedEquity = fields.ElementAtOrDefault(22).TryParseDecimalNullable("%");
            decimal? developerDiscount = fields.ElementAtOrDefault(23).TryParseDecimalNullable();
            decimal? mortgage = fields.ElementAtOrDefault(24).TryParseDecimalNullable();
            decimal? purchasePrice = fields.ElementAtOrDefault(25).TryParseDecimalNullable();

            decimal? fees = fields.ElementAtOrDefault(26).TryParseDecimalNullable();
            decimal? historicUnallocatedFees = fields.ElementAtOrDefault(27).TryParseDecimalNullable();

            decimal? actualAgencyEquityCostIncludingHomeBuyAgentFee = fields.ElementAtOrDefault(28).TryParseDecimalNullable();
            DateTime? fullDisposalDate = fields.ElementAtOrDefault(29).TryParseDateTimeNullable();
            decimal? originalAgencyPercentage = fields.ElementAtOrDefault(30).TryParseDecimalNullable("%");

            decimal? staircasingPercentage = fields.ElementAtOrDefault(31).TryParseDecimalNullable("%");

            decimal? newAgencyPercentage = fields.ElementAtOrDefault(32).TryParseDecimalNullable("%");
            int? invested = fields.ElementAtOrDefault(33).TryParseIntNullable(); 
            int? month = fields.ElementAtOrDefault(34).TryParseIntNullable(); 
            int? calendarYear = fields.ElementAtOrDefault(35).TryParseIntNullable(); 
            int? row = fields.ElementAtOrDefault(37).TryParseIntNullable(); 
            int? col = fields.ElementAtOrDefault(38).TryParseIntNullable(); 

            decimal? hpiStart = fields.ElementAtOrDefault(39).TryParseDecimalNullable(); 
            decimal? hpiEnd = fields.ElementAtOrDefault(40).TryParseDecimalNullable(); 
            decimal? hpiPlusMinus = fields.ElementAtOrDefault(41).TryParseDecimalNullable("%"); 
            decimal? agencyPercentage = fields.ElementAtOrDefault(42).TryParseDecimalNullable("%"); 
            decimal? mortgageEffect = fields.ElementAtOrDefault(43).TryParseDecimalNullable("%"); 
            decimal? remainingAgencyCost = fields.ElementAtOrDefault(44).TryParseDecimalNullable(); 
            decimal? waEstimatedPropertyValue = fields.ElementAtOrDefault(45).TryParseDecimalNullable(); 
            decimal? agencyFairValueDifference = fields.ElementAtOrDefault(46).TryParseDecimalNullable(); 
            decimal? impairmentProvision = fields.ElementAtOrDefault(47).TryParseDecimalNullable(); 
            decimal? fairValueReserve = fields.ElementAtOrDefault(48).TryParseDecimalNullable(); 
            decimal? agencyFairValue = fields.ElementAtOrDefault(49).TryParseDecimalNullable(); 
            decimal? disposalsCost = fields.ElementAtOrDefault(50).TryParseDecimalNullable(); 
            decimal? durationInMonths = fields.ElementAtOrDefault(51).TryParseDecimalNullable(); 
            decimal? monthOfCompletionSinceSchemeStart = fields.ElementAtOrDefault(52).TryParseDecimalNullable(); 
            decimal? disposalMonthSinceCompletion = fields.ElementAtOrDefault(53).TryParseDecimalNullable(); 

            DateTime? imsPaymentDate = fields.ElementAtOrDefault(54).TryParseDateTimeNullable();
            bool?     isPaid = fields.ElementAtOrDefault(55).TryParseBoolNullable();    
            bool?     isAsset = fields.ElementAtOrDefault(58).TryParseBoolNullable();    
            decimal?  expectedStaircasingRate = fields.ElementAtOrDefault(59).TryParseDecimalNullable(); 
            decimal?  estimatedSalePrice = fields.ElementAtOrDefault(60).TryParseDecimalNullable(); 
            decimal?  regionalSaleAdjust = fields.ElementAtOrDefault(61).TryParseDecimalNullable(); 
            decimal?  regionalStairAdjust = fields.ElementAtOrDefault(63).TryParseDecimalNullable(); 
            bool?     notLimitedByFirstCharge = fields.ElementAtOrDefault(64).TryParseBoolNullable();    
            decimal?  earlyMortgageIfNeverRepay = fields.ElementAtOrDefault(65).TryParseDecimalNullable(); 
            decimal?  relativeSalePropertyTypeAndTenureAdjustment = fields.ElementAtOrDefault(66).TryParseDecimalNullable(); 
            decimal?  relativeStairPropertyTypeAndTenureAdjustment = fields.ElementAtOrDefault(69).TryParseDecimalNullable(); 
            bool?     isLondon = fields.ElementAtOrDefault(70).TryParseBoolNullable();    
            decimal?  quarterSpend = fields.ElementAtOrDefault(71).TryParseDecimalNullable(); 
            decimal?  purchasePriceBand = fields.ElementAtOrDefault(72).TryParseDecimalNullable(); 
            decimal?  householdFiveKIncomeBand = fields.ElementAtOrDefault(73).TryParseDecimalNullable(); 
            decimal?  householdFiftyKIncomeBand = fields.ElementAtOrDefault(74).TryParseDecimalNullable(); 
            bool? firstTimeBuyer = fields.ElementAtOrDefault(75).TryParseBoolNullable();    

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
                MMYYYY = fields.ElementAtOrDefault(36),
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
