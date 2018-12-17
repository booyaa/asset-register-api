using System;
using System.Linq;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.Domain.Factory;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.CreateAsset.Models.Factory;
using NUnit.Framework;

namespace HomesEnglandTest.Domain
{
    [TestFixture]
    public class AssetTests
    {
        private IAsset _classUnderTest;
        private IFactory<CreateAssetRequest, CsvAsset> _createAssetRequestFactory;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new Asset();
            _createAssetRequestFactory = new CreateAssetRequestFactory();
        }


        [TestCase("Paid", true)]
        [TestCase("  Paid  ", true)]
        [TestCase("PaId", true)]
        [TestCase("NotPaid", false)]
        [TestCase("", false)]
        public void GivenPaidField_ThenIsPaidSetToCorrectValue(string input, bool expectedIsPaid)
        {
            _classUnderTest.IsPaid = input;

            _classUnderTest.IsPaidAsBool().Should().Be(expectedIsPaid);
        }

        [TestCase("Asset", true)]
        [TestCase("  Asset  ", true)]
        [TestCase("AsSeT", true)]
        [TestCase("NotAnAsset", false)]
        [TestCase("", false)]
        public void GivenAssetField_ThenIsAssetSetToCorrectValue(string input, bool expectedIsAsset)
        {
            _classUnderTest.IsAsset = input;

            _classUnderTest.IsAssetAsBool().Should().Be(expectedIsAsset);
        }

        [TestCase("Non-London", false)]
        [TestCase("  Non-London  ", false)]
        [TestCase("  NoN-lOnDoN  ", false)]
        [TestCase("London", true)]
        [TestCase("", false)]
        public void GivenNonLondonField_ThenIsLondonSetToCorrectValue(string input, bool expectedIsLondon)
        {
            _classUnderTest.IsLondon = input;

            _classUnderTest.IsLondonAsBool().Should().Be(expectedIsLondon);
        }

        [TestCase("Y", true)]
        [TestCase("  Y  ", true)]
        [TestCase("y", true)]
        [TestCase("nah", false)]
        [TestCase("", false)]
        public void GivenFirstTimeBuyer_ThenFirstTimeBuyerSetToCorrectValue(string input, bool expectedIsFirstTimeBuyer)
        {
            _classUnderTest.FirstTimeBuyer = input;

            _classUnderTest.FirstTimeBuyerAsBool().Should().Be(expectedIsFirstTimeBuyer);
        }

        [TestCase(";",
            "Help to Buy;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;27-Jul-13;26-Jul-13; 7,350 ; 29,400 ; 1000 ;100%; 2 ; 110,250 ; 147,000 ; 600 ; 10,000 ; 30,000 ;15-May-17;20.0000%; 20.0% ;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;10 ;20 ;30 ;40 ;50 ;60 ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y ")]
        public void GivenValidInput_WhenWeCallCreate_ThenAssetHasFieldsPopulatedInOrder(string delimiter,
            string csvLine)
        {
            //arrange
            var csvAsset = new CsvAsset
            {
                CsvLine = csvLine,
                Delimiter = delimiter
            };
            var fields = csvLine?.Split(delimiter);
            //act
            var asset = _createAssetRequestFactory.Create(csvAsset);
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
            asset.ImsLegalCompletionDate.Should().Be(DateTime.Parse(fields.ElementAtOrDefault(17)));
            asset.HopCompletionDate.Should().Be(DateTime.Parse(fields.ElementAtOrDefault(18)));
            asset.Deposit.Should().Be(7350);
            asset.AgencyEquityLoan.Should().Be(29400);
            asset.DeveloperEquityLoan.Should().Be(1000);
            asset.ShareOfRestrictedEquity.Should().Be(100);
            asset.DeveloperDiscount.Should().Be(2);
            asset.Mortgage.Should().Be(110250);
            asset.PurchasePrice.Should().Be(147000);
            asset.Fees.Should().Be(600);
            asset.HistoricUnallocatedFees.Should().Be(10000);
            asset.ActualAgencyEquityCostIncludingHomeBuyAgentFee.Should().Be(30000);
            asset.FullDisposalDate.Should().Be(DateTime.Parse(fields.ElementAtOrDefault(29)));
            asset.OriginalAgencyPercentage.Should().Be(20);
            asset.StaircasingPercentage.Should().Be(20);
            asset.NewAgencyPercentage.Should().Be(0);
            asset.Invested.Should().Be(0);
            asset.Month.Should().Be(7);
            asset.CalendarYear.Should().Be(2013);
            asset.MMYYYY.Should().Be("7/2013");
            asset.Row.Should().Be(99);
            asset.Col.Should().Be(13);
            asset.HPIStart.Should().Be((decimal)94.7);
            asset.HPIEnd.Should().Be((decimal)125.4);
            asset.HPIPlusMinus.Should().Be((decimal)32.4);
            asset.AgencyPercentage.Should().Be(20);
            asset.MortgageEffect.Should().Be(0);
            asset.RemainingAgencyCost.Should().Be(10);
            asset.WAEstimatedPropertyValue.Should().Be(20);
            asset.AgencyFairValueDifference.Should().Be(30);
            asset.ImpairmentProvision.Should().Be(40);
            asset.FairValueReserve.Should().Be(50);
            asset.AgencyFairValue.Should().Be(60);
            asset.DisposalsCost.Should().Be(-30000);
            asset.DurationInMonths.Should().Be(63);
            asset.MonthOfCompletionSinceSchemeStart.Should().Be(3);
            asset.DisposalMonthSinceCompletion.Should().Be(46);
            asset.IMSPaymentDate.Should().Be(DateTime.Parse("11-Sep-13"));

            asset.IsPaid.Should().Be("Paid");
            asset.IsAsset.Should().Be("Asset");
            asset.IsPaidAsBool().Should().Be(true);
            asset.IsAssetAsBool().Should().Be(true);

            asset.PropertyType.Should().Be("Semi-detached");
            asset.Tenure.Should().Be("Freehold");
            asset.ExpectedStaircasingRate.Should().Be(42);
            asset.EstimatedSalePrice.Should().Be(179332);
            asset.EstimatedValuation.Should().Be(176939);
            asset.RegionalSaleAdjust.Should().Be((decimal)-7.84);
            asset.RegionalStairAdjust.Should().Be((decimal)-9.07);
            asset.NotLimitedByFirstCharge.Should().Be("");
            asset.EarlyMortgageIfNeverRepay.Should().Be(0);
            asset.ArrearsEffectAppliedOrLimited.Should().Be("");
            asset.RelativeSalePropertyTypeAndTenureAdjustment.Should().Be(0);
            asset.RelativeStairPropertyTypeAndTenureAdjustment.Should().Be(0);
            asset.IsLondon.Should().BeEquivalentTo("Non-London");
            asset.IsLondonAsBool().Should().Be(false);
            asset.QuarterSpend.Should().Be(2);
            asset.MortgageProvider.Should().Be("Halifax");
            asset.HouseType.Should().Be("Semi-detached");
            asset.PurchasePriceBand.Should().Be(200000);
            // Household income
            asset.HouseholdFiveKIncomeBand.Should().Be(30000);
            asset.HouseholdFiftyKIncomeBand.Should().Be(50000);
            asset.FirstTimeBuyer.Should().BeEquivalentTo(" Y ");
            asset.FirstTimeBuyerAsBool().Should().Be(true);
        }
    }
}