using System;
using HomesEngland.UseCase.CreateAsset.Models;

namespace HomesEngland.Domain
{
    public class Asset:IAsset
    {
        public int Id { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string MonthPaid { get; set; }
        public string AccountingYear { get; set; }
        public int? SchemeId { get; set; }
        public string LocationLaRegionName { get; set; }
        public string ImsOldRegion { get; set; }
        public string NoOfBeds { get; set; }
        public string Address { get; set; }
        public string DevelopingRslName { get; set; }
        public DateTime? CompletionDateForHpiStart { get; set; }
        public DateTime? ImsActualCompletionDate { get; set; }
        public DateTime? ImsExpectedCompletionDate { get; set; }
        public DateTime? ImsLegalCompletionDate { get; set; }
        public DateTime? HopCompletionDate { get; set; }
        public decimal? Deposit { get; set; }
        public decimal? AgencyEquityLoan { get; set; }
        public decimal? DeveloperEquityLoan { get; set; }
        public decimal? ShareOfRestrictedEquity { get; set; }
        public int? DifferenceFromImsExpectedCompletionToHopCompletionDate { get; set; }

        public Asset() { }
        public Asset(CreateAssetRequest request)
        {
            AccountingYear = request.AccountingYear;
            Address = request.Address;
            AgencyEquityLoan = request.AgencyEquityLoan;
            CompletionDateForHpiStart = request.CompletionDateForHpiStart;
            Deposit = request.Deposit;
            DeveloperEquityLoan = request.DeveloperEquityLoan;
            DevelopingRslName = request.DevelopingRslName;
            DifferenceFromImsExpectedCompletionToHopCompletionDate = request.DifferenceFromImsExpectedCompletionToHopCompletionDate;
            HopCompletionDate = request.HopCompletionDate;
            ImsActualCompletionDate = request.ImsActualCompletionDate;
            ImsExpectedCompletionDate = request.ImsExpectedCompletionDate;
            ImsLegalCompletionDate = request.ImsLegalCompletionDate;
            ImsOldRegion = request.ImsOldRegion;
            LocationLaRegionName = request.LocationLaRegionName;
            MonthPaid = request.MonthPaid;
            NoOfBeds = request.NoOfBeds;
            SchemeId = request.SchemeId;
            ShareOfRestrictedEquity = request.ShareOfRestrictedEquity;
        }

        public Asset(IAsset request)
        {
            AccountingYear = request.AccountingYear;
            Address = request.Address;
            AgencyEquityLoan = request.AgencyEquityLoan;
            CompletionDateForHpiStart = request.CompletionDateForHpiStart;
            Deposit = request.Deposit;
            DeveloperEquityLoan = request.DeveloperEquityLoan;
            DevelopingRslName = request.DevelopingRslName;
            DifferenceFromImsExpectedCompletionToHopCompletionDate = request.DifferenceFromImsExpectedCompletionToHopCompletionDate;
            HopCompletionDate = request.HopCompletionDate;
            ImsActualCompletionDate = request.ImsActualCompletionDate;
            ImsExpectedCompletionDate = request.ImsExpectedCompletionDate;
            ImsLegalCompletionDate = request.ImsLegalCompletionDate;
            ImsOldRegion = request.ImsOldRegion;
            LocationLaRegionName = request.LocationLaRegionName;
            MonthPaid = request.MonthPaid;
            NoOfBeds = request.NoOfBeds;
            SchemeId = request.SchemeId;
            ShareOfRestrictedEquity = request.ShareOfRestrictedEquity;
        }
    }
}
