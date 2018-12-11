using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HomesEngland.Domain.Factory;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.CreateAsset.Models.Factory;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using NUnit.Framework;

namespace HomesEnglandTest.Domain
{
    [TestFixture]
    public class CreateAssetRequestFactoryTests
    {
        private IFactory<CreateAssetRequest, CsvAsset> _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new CreateAssetRequestFactory();
        }

        [TestCase(";", "")]
        [TestCase(";", " ")]
        [TestCase(";", null)]
        [TestCase("", "sdadsfa;sdfa")]
        [TestCase(" ", "sdadsfa;sdfa")]
        [TestCase(null, "sdadsfa;sdfa")]
        [TestCase(null, null)]
        public void GivenInValidInput_WhenWeCallCreate_ThenAssetIsNull(string delimiter, string csvLine)
        {
            //arrange
            var csvAsset = new CsvAsset
            {
                CsvLine = csvLine,
                Delimiter = delimiter
            };
            //act
            var asset = _classUnderTest.Create(csvAsset);
            //assert
            asset.Should().BeNull();
        }

        [TestCase(";", "Help to Buy;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;27-Jul-13;26-Jul-13; 7,350 ; 29,400 ; 1000 ;100%; 2 ; 110,250 ; 147,000 ; 600 ; 10,000 ; 30,000 ;15-May-17;20.0000%; 20.0% ;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y ")]
        [TestCase(";", "Old Scheme ;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;27-Jul-13;26-Jul-13; 7,350 ; 29,400 ; 1000 ;100%; 2 ; 110,250 ; 147,000 ; 600 ; 10,000 ; 30,000 ;15-May-17;20.0000%; 20.0% ;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y ")]
        [TestCase(";", "Help to Buy;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;27-Jul-13;26-Jul-13; 7,350 ; 29,400 ; 1000 ;100%; 2 ; 110,250 ; 147,000 ; 600 ; 10,000 ; 30,000 ;15-May-17;20.0000%; 20.0% ;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y ")]
        public void GivenValidInput_WhenWeCallCreate_ThenAssetHasFieldsPopulated(string delimiter, string csvLine)
        {
            //arrange
            var csvAsset = new CsvAsset
            {
                CsvLine = csvLine,
                Delimiter = delimiter
            };
            //act
            var asset = _classUnderTest.Create(csvAsset);
            //assert
            asset.Should().NotBeNull();
            asset.Programme.Should().NotBeNull();
            asset.EquityOwner.Should().NotBeNull();
            asset.SchemeId.Should().NotBeNull();
            asset.LocationLaRegionName.Should().NotBeNull();
            asset.ImsOldRegion.Should().NotBeNull();
            asset.NoOfBeds.Should().NotBeNull();
            asset.Address.Should().NotBeNull();
            asset.PropertyHouseName.Should().NotBeNull();
            asset.PropertyStreetNumber.Should().NotBeNull();
            asset.PropertyStreet.Should().NotBeNull();
            asset.PropertyTown.Should().NotBeNull();
            asset.PropertyPostcode.Should().NotBeNull();
            asset.DevelopingRslName.Should().NotBeNull();
            asset.LBHA.Should().NotBeNull();
            asset.CompletionDateForHpiStart.Should().NotBeNull().Should().NotBe(DateTime.MinValue);
            asset.ImsActualCompletionDate.Should().NotBeNull().Should().NotBe(DateTime.MinValue);
            asset.ImsExpectedCompletionDate.Should().NotBeNull().Should().NotBe(DateTime.MinValue);
            asset.ImsLegalCompletionDate.Should().NotBeNull().Should().NotBe(DateTime.MinValue);
            asset.HopCompletionDate.Should().NotBeNull().Should().NotBe(DateTime.MinValue);
            asset.Deposit.Should().NotBeNull();
            asset.AgencyEquityLoan.Should().NotBeNull();
            asset.DeveloperEquityLoan.Should().NotBeNull();
            asset.ShareOfRestrictedEquity.Should().NotBeNull();
            asset.DeveloperDiscount.Should().NotBeNull();
            asset.Mortgage.Should().NotBeNull();
            asset.PurchasePrice.Should().NotBeNull();
            asset.Fees.Should().NotBeNull();
            asset.HistoricUnallocatedFees.Should().NotBeNull();
            asset.ActualAgencyEquityCostIncludingHomeBuyAgentFee.Should().NotBeNull();
            asset.FullDisposalDate.Should().NotBeNull();
            asset.OriginalAgencyPercentage.Should().NotBeNull();
            asset.StaircasingPercentage.Should().NotBeNull();
            asset.NewAgencyPercentage.Should().NotBeNull();
            asset.Invested.Should().NotBeNull();
            asset.Month.Should().NotBeNull();
            asset.CalendarYear.Should().NotBeNull();
            asset.MMYYYY.Should().NotBeNull();
            asset.Row.Should().NotBeNull();
            asset.Col.Should().NotBeNull();
            asset.HPIStart.Should().NotBeNull();
            asset.HPIEnd.Should().NotBeNull();
            asset.HPIPlusMinus.Should().NotBeNull();
            asset.AgencyPercentage.Should().NotBeNull();
            asset.MortgageEffect.Should().NotBeNull();
            asset.RemainingAgencyCost.Should().BeNull();
            asset.WAEstimatedPropertyValue.Should().BeNull();
            asset.AgencyFairValueDifference.Should().BeNull();
            asset.ImpairmentProvision.Should().BeNull();
            asset.FairValueReserve.Should().BeNull();
            asset.AgencyFairValue.Should().BeNull();
            asset.DisposalsCost.Should().NotBeNull();
            asset.DurationInMonths.Should().NotBeNull();
            asset.MonthOfCompletionSinceSchemeStart.Should().NotBeNull();
            asset.DisposalMonthSinceCompletion.Should().NotBeNull();
            asset.IMSPaymentDate.Should().NotBeNull();
            asset.IsPaid.Should().NotBeNull();
            asset.IsAsset.Should().NotBeNull();
            asset.PropertyType.Should().NotBeNull();
            asset.Tenure.Should().NotBeNull();
            asset.ExpectedStaircasingRate.Should().NotBeNull();
            asset.EstimatedSalePrice.Should().NotBeNull();
            asset.RegionalSaleAdjust.Should().NotBeNull();
            asset.RegionalStairAdjust.Should().NotBeNull();
            asset.NotLimitedByFirstCharge.Should().NotBeNull();
            asset.EarlyMortgageIfNeverRepay.Should().NotBeNull();
            asset.ArrearsEffectAppliedOrLimited.Should().NotBeNull();
            asset.RelativeSalePropertyTypeAndTenureAdjustment.Should().NotBeNull();
            asset.RelativeStairPropertyTypeAndTenureAdjustment.Should().NotBeNull();
            asset.IsLondon.Should().NotBeNull();
            asset.QuarterSpend.Should().NotBeNull();
            asset.MortgageProvider.Should().NotBeNull();
            asset.HouseType.Should().NotBeNull();
            asset.PurchasePriceBand.Should().NotBeNull();
            asset.HouseholdFiveKIncomeBand.Should().NotBeNull();
            asset.HouseholdFiftyKIncomeBand.Should().NotBeNull();
            asset.FirstTimeBuyer.Should().NotBeNull();
    }

        [TestCase("Help to buy")]
        [TestCase("")]
        public void GivenProgramme_ThenAssetHasFieldPopulatedCorrectly(string input)
        {
            var asset = CreateAssetRequestForColumn(input, 0);

            asset.Programme.Should().BeEquivalentTo(input);
        }
        
        [TestCase("Homes England")]
        [TestCase("")]
        public void GivenEquityOwner_ThenAssetHasFieldPopulatedCorrectly(string input)
        {
            var asset = CreateAssetRequestForColumn(input, 1);

            asset.EquityOwner.Should().BeEquivalentTo(input);
        }
        
        [TestCase("1001", 1001)]
        [TestCase("2002", 2002)]
        public void GivenSchemeID_ThenAssetHasFieldPopulatedCorrectly(string input, int expectedSchemeId)
        {
            var asset = CreateAssetRequestForColumn(input, 2);

            asset.SchemeId.Should().Be(expectedSchemeId);
        }
        
        [TestCase("LocationLAOne")]
        [TestCase("LocationLATwo")]
        public void GivenLocationLARegionName_ThenAssetHasFieldPopulatedCorrectly(string input)
        {
            var asset = CreateAssetRequestForColumn(input, 3);

            asset.LocationLaRegionName.Should().BeEquivalentTo(input);
        }
        
        private CreateAssetRequest CreateAssetRequestForColumn(string input, int csvColumn)
        {
            List<string> values = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                values.Add("");
            }

            values[csvColumn] = input;

            var csvAsset = new CsvAsset
            {
                CsvLine = String.Join(";", values),
                Delimiter = ";"
            };

            var asset = _classUnderTest.Create(csvAsset);
            return asset;
        }

        [Ignore("Meow")]
        [TestCase(";", "Help to Buy;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; 1000 ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y ")]
        [TestCase(";", "Old Scheme ;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; 1000 ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y ")]
        [TestCase(";", "Help to Buy;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; 1000 ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y ")]
        public void GivenValidInput_WhenWeCallCreate_ThenAssetHasFieldsPopulatedInOrder(string delimiter, string csvLine)
        {
            //arrange
            var csvAsset = new CsvAsset
            {
                CsvLine = csvLine,
                Delimiter = delimiter
            };
            var fields = csvLine?.Split(delimiter);
            //act
            var asset = _classUnderTest.Create(csvAsset);
            //assert
            asset.Should().NotBeNull();
            asset.Programme.Should().BeEquivalentTo(fields.ElementAtOrDefault(0));
            asset.EquityOwner.Should().BeEquivalentTo(fields.ElementAtOrDefault(1));
            asset.SchemeId.Should().Be(int.Parse(fields.ElementAtOrDefault(2)));
            asset.LocationLaRegionName.Should().BeEquivalentTo(fields.ElementAtOrDefault(3));
            asset.ImsOldRegion.Should().BeEquivalentTo(fields.ElementAtOrDefault(4));
            asset.NoOfBeds.Should().Be(int.Parse(fields.ElementAtOrDefault(5)));
            asset.Address.Should().BeEquivalentTo(fields.ElementAtOrDefault(6));
            asset.PropertyHouseName.Should().BeEquivalentTo(fields.ElementAtOrDefault(7));
            asset.PropertyStreetNumber.Should().BeEquivalentTo(fields.ElementAtOrDefault(8));
            asset.PropertyStreet.Should().BeEquivalentTo(fields.ElementAtOrDefault(9));
            asset.PropertyTown.Should().BeEquivalentTo(fields.ElementAtOrDefault(10));
            asset.PropertyPostcode.Should().BeEquivalentTo(fields.ElementAtOrDefault(11));
            asset.DevelopingRslName.Should().BeEquivalentTo(fields.ElementAtOrDefault(12));
            asset.LBHA.Should().BeEquivalentTo(fields.ElementAtOrDefault(13));
            asset.CompletionDateForHpiStart.Should().Be(DateTime.Parse(fields.ElementAtOrDefault(14)));
            asset.ImsActualCompletionDate.Should().Be(DateTime.Parse(fields.ElementAtOrDefault(15)));
            asset.ImsExpectedCompletionDate.Should().Be(DateTime.Parse(fields.ElementAtOrDefault(16)));
            asset.ImsLegalCompletionDate.Should().BeNull();
            asset.HopCompletionDate.Should().Be(DateTime.Parse(fields.ElementAtOrDefault(18)));
            asset.Deposit.Should().NotBeNull();
            asset.AgencyEquityLoan.Should().NotBeNull();
            asset.DeveloperEquityLoan.Should().NotBeNull();
            asset.ShareOfRestrictedEquity.Should().NotBeNull();
            asset.DeveloperDiscount.Should().NotBeNull();
            asset.Mortgage.Should().NotBeNull();
            asset.PurchasePrice.Should().NotBeNull();
            asset.Fees.Should().NotBeNull();
            asset.HistoricUnallocatedFees.Should().NotBeNull();
            asset.ActualAgencyEquityCostIncludingHomeBuyAgentFee.Should().NotBeNull();
            asset.FullDisposalDate.Should().NotBeNull();
            asset.OriginalAgencyPercentage.Should().NotBeNull();
            asset.StaircasingPercentage.Should().NotBeNull();
            asset.NewAgencyPercentage.Should().NotBeNull();
            asset.Invested.Should().NotBeNull();
            asset.Month.Should().NotBeNull();
            asset.CalendarYear.Should().NotBeNull();
            asset.MMYYYY.Should().NotBeNull();
            asset.Row.Should().NotBeNull();
            asset.Col.Should().NotBeNull();
            asset.HPIStart.Should().NotBeNull();
            asset.HPIEnd.Should().NotBeNull();
            asset.HPIPlusMinus.Should().NotBeNull();
            asset.AgencyPercentage.Should().NotBeNull();
            asset.MortgageEffect.Should().NotBeNull();
            asset.RemainingAgencyCost.Should().NotBeNull();
            asset.WAEstimatedPropertyValue.Should().NotBeNull();
            asset.AgencyFairValueDifference.Should().NotBeNull();
            asset.ImpairmentProvision.Should().NotBeNull();
            asset.FairValueReserve.Should().NotBeNull();
            asset.AgencyFairValue.Should().NotBeNull();
            asset.DisposalsCost.Should().NotBeNull();
            asset.DurationInMonths.Should().NotBeNull();
            asset.MonthOfCompletionSinceSchemeStart.Should().NotBeNull();
            asset.DisposalMonthSinceCompletion.Should().NotBeNull();
            asset.IMSPaymentDate.Should().NotBeNull();
            asset.IsPaid.Should().NotBeNull();
            asset.IsAsset.Should().NotBeNull();
            asset.PropertyType.Should().NotBeNull();
            asset.Tenure.Should().NotBeNull();
            asset.ExpectedStaircasingRate.Should().NotBeNull();
            asset.EstimatedSalePrice.Should().NotBeNull();
            asset.RegionalSaleAdjust.Should().NotBeNull();
            asset.RegionalStairAdjust.Should().NotBeNull();
            asset.NotLimitedByFirstCharge.Should().NotBeNull();
            asset.EarlyMortgageIfNeverRepay.Should().NotBeNull();
            asset.ArrearsEffectAppliedOrLimited.Should().NotBeNull();
            asset.RelativeSalePropertyTypeAndTenureAdjustment.Should().NotBeNull();
            asset.RelativeStairPropertyTypeAndTenureAdjustment.Should().NotBeNull();
            asset.IsLondon.Should().NotBeNull();
            asset.QuarterSpend.Should().NotBeNull();
            asset.MortgageProvider.Should().NotBeNull();
            asset.HouseType.Should().NotBeNull();
            asset.PurchasePriceBand.Should().NotBeNull();
            asset.HouseholdFiveKIncomeBand.Should().NotBeNull();
            asset.HouseholdFiftyKIncomeBand.Should().NotBeNull();
            asset.FirstTimeBuyer.Should().NotBeNull();
        }
    }
}
