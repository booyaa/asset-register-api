using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using HomesEngland.UseCase.CreateAsset;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.ImportAssets;
using HomesEngland.UseCase.ImportAssets.Impl;
using HomesEngland.UseCase.ImportAssets.Models;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace HomesEnglandTest.UseCase.ImportAssets
{
    [TestFixture]
    public class ImportAssetsUseCaseTest
    {
        public IImportAssetsUseCase _classUnderTest;
        public Mock<ICreateAssetUseCase> _mockCreateAssetUseCase;
        public Mock<ILogger<IImportAssetsUseCase>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockCreateAssetUseCase = new Mock<ICreateAssetUseCase>();
            _mockLogger = new Mock<ILogger<IImportAssetsUseCase>>();
            _classUnderTest = new ImportAssetsUseCase(_mockCreateAssetUseCase.Object, _mockLogger.Object);
        }

        [TestCase("Old Scheme;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y ")]
        [TestCase("Help to Buy;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y ")]
        public async Task GivenValidInput_ThenWeCallCreateAssetUseCaseOnce(string csvLine)
        {
            //arrange
            var request = new ImportAssetsRequest
            {
                AssetLines = new List<string> {csvLine}
            };
            //act
            var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None).ConfigureAwait(false);
            
            //assert
            _mockCreateAssetUseCase.Verify(v=> v.ExecuteAsync(It.IsAny<CreateAssetRequest>(),It.IsAny<CancellationToken>()));
        }

        [TestCase(1, "Help to Buy;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y")]
        [TestCase(2, "Old Scheme;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y \n Buy To Help;Homes England;58342;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y")]
        [TestCase(3, "Old Scheme;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y \n Buy To Help;Homes England;58342;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y \nOld Scheme;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y")]
        public async Task GivenValidInput_ThenWeCallCreateAssetUseCaseXTimes(int executionCount, string multipleCsvLines)
        {
            //arrange
            var csvLines = multipleCsvLines.Split("\n");
            var request = new ImportAssetsRequest
            {
                AssetLines = csvLines
            };
            //act
            var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None).ConfigureAwait(false);

            //assert
            _mockCreateAssetUseCase.Verify(v => v.ExecuteAsync(It.IsAny<CreateAssetRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(executionCount));
        }

        [TestCase(1, "Help to Buy;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y")]
        [TestCase(2, "Old Scheme;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y \n Buy To Help;Homes England;58342;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y")]
        [TestCase(3, "Old Scheme;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y \n Buy To Help;Homes England;58342;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y \nOld Scheme;Homes England;583417;Midlands;West Midlands; 2 ; Primrose Gardens Plot 14 30 Mews Mews Netherton  Dudley DY2 9LD ; Primrose Gardens Plot 14 ; 30 ; Mews Mews ; Cat Town, DogVille ; DY2 9LD ; Taylor Wimpey ; Orbit Group Limited ;26-Jul-13;2-Sep-13;26-Jul-13;#N/A;26-Jul-13; 7,350 ; 29,400 ; - ;100%; - ; 110,250 ; 147,000 ; 600 ; - ; 30,000 ;15-May-17;20.0000%;;0.0000%;0;7;2013;7/2013;99;13;94.7;125.4;32.4%;20.0%;0.000%;- ;- ;- ;- ;- ;- ;(30,000.00);63;3;46;11-Sep-13;Paid;Asset;Semi-detached;Freehold;42%; 179,332 ; 176,939 ;-7.84%;-9.07%;;0.00%;;0.00%;0.00%;Non-London;2;Halifax;Semi-detached; 200,000 ; 28,842 ; 30,000 ; 50,000 ; Y")]
        public async Task GivenValidInput_ThenXAssetsAreReturned(int executionCount, string multipleCsvLines)
        {
            //arrange
            var csvLines = multipleCsvLines.Split("\n");
            var request = new ImportAssetsRequest
            {
                AssetLines = csvLines
            };
            //act
            var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None).ConfigureAwait(false);

            //assert
            response.Should().NotBeNull();
            response.AssetsImported.Count.Should().Be(executionCount);
        }
    }
}
