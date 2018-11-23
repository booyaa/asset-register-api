using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Gateway.Assets;
using HomesEngland.UseCase.CreateAsset.Models;

namespace HomesEngland.UseCase.CreateAsset.Impl
{
    public class CreateAssetUseCase : ICreateAssetUseCase
    {
        private readonly IAssetCreator _assetCreator;

        public CreateAssetUseCase(IAssetCreator assetCreator)
        {
            _assetCreator = assetCreator;
        }

        public async Task<CreateAssetResponse> ExecuteAsync(CreateAssetRequest request,
            CancellationToken cancellationToken)
        {
            var asset = new DapperAsset
            {
                AccountingYear = request.AccountingYear,
                Address = request.Address,
                AgencyEquityLoan = request.AgencyEquityLoan,
                CompletionDateForHpiStart = request.CompletionDateForHpiStart,
                Deposit = request.Deposit,
                DeveloperEquityLoan = request.DeveloperEquityLoan,
                DevelopingRslName = request.DevelopingRslName,
                DifferenceFromImsExpectedCompletionToHopCompletionDate =
                    request.DifferenceFromImsExpectedCompletionToHopCompletionDate,
                HopCompletionDate = request.HopCompletionDate,
                ImsActualCompletionDate = request.ImsActualCompletionDate,
                ImsExpectedCompletionDate = request.ImsExpectedCompletionDate,
                ImsLegalCompletionDate = request.ImsLegalCompletionDate,
                ImsOldRegion = request.ImsOldRegion,
                LocationLaRegionName = request.LocationLaRegionName,
                MonthPaid = request.MonthPaid,
                NoOfBeds = request.NoOfBeds,
                SchemeId = request.SchemeId,
                ShareOfRestrictedEquity = request.ShareOfRestrictedEquity
            };
            await _assetCreator.CreateAsync(asset);

            return null;
        }
    }
}
