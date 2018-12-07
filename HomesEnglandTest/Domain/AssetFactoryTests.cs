using FluentAssertions;
using HomesEngland.Domain.Factory;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.CreateAsset.Models.Factory;
using NUnit.Framework;

namespace HomesEnglandTest.Domain
{
    [TestFixture]
    public class AssetFactoryTests
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

        [TestCase(";", "Help to Buy;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y ")]
        [TestCase(";", "Old Scheme ;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y ")]
        [TestCase(";", "Help to Buy;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y ")]
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
            asset.AccountingYear.Should().NotBeNull();
            asset.Address.Should().NotBeNull();
            asset.AgencyEquityLoan.Should().NotBeNull();
            asset.CompletionDateForHpiStart.Should().NotBeNull();
            asset.Deposit.Should().NotBeNull();
            asset.DeveloperEquityLoan.Should().NotBeNull();
            asset.DevelopingRslName.Should().NotBeNull();
            asset.DifferenceFromImsExpectedCompletionToHopCompletionDate.Should().NotBeNull();
            asset.HopCompletionDate.Should().NotBeNull();
            asset.ImsActualCompletionDate.Should().NotBeNull();
            asset.ImsExpectedCompletionDate.Should().NotBeNull();
            asset.ImsLegalCompletionDate.Should().NotBeNull();
            asset.ImsOldRegion.Should().NotBeNull();
            asset.LocationLaRegionName.Should().NotBeNull();
            asset.MonthPaid.Should().NotBeNull();
            asset.NoOfBeds.Should().NotBeNull();
            asset.SchemeId.Should().NotBeNull();
            asset.ShareOfRestrictedEquity.Should().NotBeNull();



        }
    }
}
