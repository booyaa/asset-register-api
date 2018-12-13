namespace HomesEngland.Domain
{
    public interface IAssetAggregation
    {
        decimal? UniqueRecords { get; set; }
        decimal? MoneyPaidOut { get; set; }
        decimal? AssetValue { get; set; }
        decimal? MovementInAssetValue { get; set; }
    }
}
