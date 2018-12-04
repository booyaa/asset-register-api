using System;
using System.Text;
using HomesEngland.Domain;
using HomesEngland.UseCase.ExportCsv.Models;

namespace HomesEngland.UseCase.GetAsset.Models
{
    public class AssetOutputModel:ICsvFormattable
    {
        public int Id { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string MonthPaid { get; set; }
        public string AccountingYear { get; set; }
        public int? SchemeId { get; set; }

        //Identifying Information
        public string LocationLaRegionName { get; set; }
        public string ImsOldRegion { get; set; }
        public string NoOfBeds { get; set; }
        //IMS Adress
        public string Address { get; set; }
        public string DevelopingRslName { get; set; }
        //Completion Dates
        public DateTime? CompletionDateForHpiStart { get; set; }
        public DateTime? ImsActualCompletionDate { get; set; }
        public DateTime? ImsExpectedCompletionDate { get; set; }
        public DateTime? ImsLegalCompletionDate { get; set; }
        public DateTime? HopCompletionDate { get; set; }
        //Financial Information
        public decimal? Deposit { get; set; }
        public decimal? AgencyEquityLoan { get; set; }
        public decimal? DeveloperEquityLoan { get; set; }
        public decimal? ShareOfRestrictedEquity { get; set; }
        //Calcuation
        public int? DifferenceFromImsExpectedCompletionToHopCompletionDate { get; set; }

        public AssetOutputModel(){}

        public AssetOutputModel(IAsset asset)
        {
            Id = asset.Id;
            ModifiedDateTime = asset.ModifiedDateTime;
            MonthPaid = asset.MonthPaid;
            AccountingYear = asset.AccountingYear;
            SchemeId = asset.SchemeId;

            //Identifying Information
            LocationLaRegionName = asset.LocationLaRegionName;
            ImsOldRegion = asset.ImsOldRegion;
            NoOfBeds = asset.NoOfBeds;
            //IMS Adress
            Address = asset.Address;
            DevelopingRslName = asset.DevelopingRslName;
            //Completion Dates
            CompletionDateForHpiStart = asset.CompletionDateForHpiStart;
            ImsActualCompletionDate = asset.ImsActualCompletionDate;
            ImsExpectedCompletionDate = asset.ImsExpectedCompletionDate;
            ImsLegalCompletionDate = asset.ImsLegalCompletionDate;
            HopCompletionDate = asset.HopCompletionDate;
            //Financial Information
            Deposit = asset.Deposit;
            AgencyEquityLoan = asset.AgencyEquityLoan;
            DeveloperEquityLoan = asset.DeveloperEquityLoan;
            ShareOfRestrictedEquity = asset.ShareOfRestrictedEquity;
            //Calcuation
            DifferenceFromImsExpectedCompletionToHopCompletionDate = asset.DifferenceFromImsExpectedCompletionToHopCompletionDate;
        }

        public string ToCsv()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"{Id},");
            stringBuilder.Append($"{ModifiedDateTime},");
            stringBuilder.Append($"{MonthPaid},");
            stringBuilder.Append($"{AccountingYear},");
            stringBuilder.Append($"{SchemeId},");
            stringBuilder.Append($"{LocationLaRegionName},");
            stringBuilder.Append($"{ImsOldRegion},");
            stringBuilder.Append($"{NoOfBeds},");
            stringBuilder.Append($"{Address},");
            stringBuilder.Append($"{DevelopingRslName},");
            stringBuilder.Append($"{CompletionDateForHpiStart},");
            stringBuilder.Append($"{ImsActualCompletionDate},");
            stringBuilder.Append($"{ImsExpectedCompletionDate},");
            stringBuilder.Append($"{ImsLegalCompletionDate},");
            stringBuilder.Append($"{HopCompletionDate},");
            stringBuilder.Append($"{Deposit},");
            stringBuilder.Append($"{AgencyEquityLoan},");
        }
    }
}
