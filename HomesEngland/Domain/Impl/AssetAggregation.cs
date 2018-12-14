namespace HomesEngland.Domain.Impl
{
    public class AssetAggregation:IAssetAggregation
    {
        public decimal? UniqueRecords { get; set; }
        public decimal? MoneyPaidOut { get; set; }
        public decimal? AssetValue { get; set; }
        public decimal? MovementInAssetValue { get; set; }
    }
}
