using HomesEngland.Domain;

namespace HomesEngland.UseCase.CalculateAssetAggregates.Models
{
    public class AssetAggregatesOutputModel
    {
        public AssetAggregatesOutputModel() { }

        public AssetAggregatesOutputModel(IAssetAggregation assetAggregation)
        {
            UniqueRecords = assetAggregation?.UniqueRecords;
            MoneyPaidOut = assetAggregation?.MoneyPaidOut;
            AssetValue = assetAggregation?.AssetValue;
            MovementInAssetValue = assetAggregation?.MovementInAssetValue;
        }

        public decimal? UniqueRecords { get; set; }
        public decimal? MoneyPaidOut { get; set; }
        public decimal? AssetValue { get; set; }
        public decimal? MovementInAssetValue { get; set; }


    }
}
