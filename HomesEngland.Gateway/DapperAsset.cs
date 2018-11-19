using System;
using HomesEngland.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomesEngland.Gateway
{
    [Table("Assets")]
    [Dapper.Table("Assets")]
    public class DapperAsset : IAsset
    {
        [Dapper.Key]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string MonthPaid { get; set; }
        public string AccountingYear { get; set; }
        public string SchemeId { get; set; }

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
    }
}
