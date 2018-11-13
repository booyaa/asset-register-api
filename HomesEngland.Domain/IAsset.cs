using System;

namespace HomesEngland.Domain
{
    public interface IAsset:IDatabaseEntity<int>
    {
        string MonthPaid { get; set; }
        string AccountingYear { get; set; }
        string SchemeID { get; set; }
        string LocationLaRegionName { get; set; }
        string ImsOldRegion { get; set; }
        string NoOfBeds { get; set; }
        string Address { get; set; }
        string DevelopingRslName { get; set; }
        DateTime? CompletionDateForHpiStart { get; set; }
        DateTime? ImsActualCompletionDate { get; set; }
        DateTime? ImsExpectedCompletionDate { get; set; }
        DateTime? ImsLegalCompletionDate { get; set; }
        DateTime? HopCompletionDate { get; set; }
        decimal? Deposit { get; set; }
        decimal? AgencyEquityLoan { get; set; }
        decimal? DeveloperEquityLoan { get; set; }
        decimal? ShareOfRestrictedEquity { get; set; }
        int? DifferenceFromImsExpectedCompletionToHopCompletionDate { get; set; }
    }
}