namespace HomesEngland.Domain
{
    public interface IAssetSearchQuery
    {
        int? SchemeId { get; set; }
        string Address { get; set; }
    }
}
