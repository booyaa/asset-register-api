namespace HomesEngland.Domain
{
    public interface IAssetSearchQuery
    {
        int? SchemeId { get; set; }
        int? Page { get; set; }
        int? PageSize { get; set; }
        string Address { get; set; }
    }
}
