using System;
using HomesEngland.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomesEngland.Gateway
{
    [Table("assets")]
    [Dapper.Table("assets")]
    public class DapperAsset : IAsset
    {
        [Dapper.Key]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("modifieddatetime")]
        public DateTime ModifiedDateTime { get; set; }
        [Column("monthpaid")]
        public string MonthPaid { get; set; }
        [Column("accountingyear")]
        public string AccountingYear { get; set; }
        [Column("schemeid")]
        public string SchemeId { get; set; }

        //Identifying Information
        [Column("locationlaregionname")]
        public string LocationLaRegionName { get; set; }
        [Column("imsoldregion")]
        public string ImsOldRegion { get; set; }
        [Column("noofbeds")]
        public string NoOfBeds { get; set; }
        //IMS Adress
        [Column("address")]
        public string Address { get; set; }
        [Column("developingrslname")]
        public string DevelopingRslName { get; set; }
        //Completion Dates
        [Column("completiondateforhpistart")]
        public DateTime? CompletionDateForHpiStart { get; set; }
        [Column("imsactualcompletiondate")]
        public DateTime? ImsActualCompletionDate { get; set; }
        [Column("imsexpectedcompletiondate")]
        public DateTime? ImsExpectedCompletionDate { get; set; }
        [Column("imslegalcompletiondate")]
        public DateTime? ImsLegalCompletionDate { get; set; }
        [Column("hopcompletiondate")]
        public DateTime? HopCompletionDate { get; set; }
        //Financial Information
        [Column("deposit")]
        public decimal? Deposit { get; set; }
        [Column("agencyequityloan")]
        public decimal? AgencyEquityLoan { get; set; }
        [Column("developerequityloan")]
        public decimal? DeveloperEquityLoan { get; set; }
        [Column("shareofrestrictedequity")]
        public decimal? ShareOfRestrictedEquity { get; set; }
        //Calcuation
        [Column("differencefromimsexpectedcompletiontohopcompletiondate")]
        public int? DifferenceFromImsExpectedCompletionToHopCompletionDate { get; set; }
    }
}
