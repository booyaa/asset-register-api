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

        public string Programme { get; set; }
        public string EquityOwner { get; set; }

        [Column("schemeid")]
        public int? SchemeId { get; set; }

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

        public string PropertyHouseName { get; set; }
        public string PropertyStreetNumber { get; set; }
        public string PropertyStreet { get; set; }
        public string PropertyTown { get; set; }
        public string PropertyPostcode { get; set; }

        [Column("developingrslname")]
        public string DevelopingRslName { get; set; }

        public string LBHA { get; set; }

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

        public decimal? DeveloperDiscount { get; set; }
        public decimal? Mortgage { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? Fees { get; set; }
        public decimal? HistoricUnallocatedFees { get; set; }
        public decimal? ActualAgencyEquityCostIncludingHomeBuyAgentFee { get; set; }
        public DateTime? FullDisposalDate { get; set; }
        public decimal? OriginalAgencyPercentage { get; set; }
        public decimal? StaircasingPercentage { get; set; }
        public decimal? NewAgencyPercentage { get; set; }
        public int? Invested { get; set; }
        public int? Month { get; set; }
        public int? CalendarYear { get; set; }
        public string MMYYYY { get; set; }
        public int? Row { get; set; }
        public int? Column { get; set; }
        public decimal? HPIStart { get; set; }
        public decimal? HPIEnd { get; set; }
        public decimal? HPIPlusMinus { get; set; }
        public decimal? AgencyPercentage { get; set; }
        public decimal? MortgageEffect { get; set; }
        public decimal? RemainingAgencyCost { get; set; }
        public decimal? WAEstimatedPropertyValue { get; set; }
        public decimal? AgencyFairValueDifference { get; set; }
        public decimal? ImpairmentProvision { get; set; }
        public decimal? FairValueReserve { get; set; }
        public decimal? AgencyFairValue { get; set; }
        public decimal? DisposalsCost { get; set; }
        public decimal? DurationInMonths { get; set; }
        public decimal? MonthOfCompletionSinceSchemeStart { get; set; }
        public decimal? DisposalMonthSinceCompletion { get; set; }
        public DateTime? IMSPaymentDate { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsAsset { get; set; }
        public string PropertyType { get; set; }
        public string Tenure { get; set; }
        public decimal? ExpectedStaircasingRate { get; set; }
        public decimal? EstimatedSalePrice { get; set; }
        public decimal? RegionalSaleAdjust { get; set; }
        public decimal? RegionalStairAdjust { get; set; }
        public bool? NotLimitedByFirstCharge { get; set; }
        public decimal? EarlyMortgageIfNeverRepay { get; set; }
        public string ArrearsEffectAppliedOrLimited { get; set; }
        public decimal? RelativeSalePropertyTypeAndTenureAdjustment { get; set; }
        public decimal? RelativeStairPropertyTypeAndTenureAdjustment { get; set; }
        public bool? IsLondon { get; set; }
        public decimal? QuarterSpend { get; set; }
        public string MortgageProvider { get; set; }
        public string HouseType { get; set; }
        public decimal? PurchasePriceBand { get; set; }
        public decimal? HouseholdFiveKIncomeBand { get; set; }
        public decimal? HouseholdFiftyKIncomeBand { get; set; }
        public bool? FirstTimeBuyer { get; set; }

        //Calcuation
        [Column("differencefromimsexpectedcompletiontohopcompletiondate")]
        public int? DifferenceFromImsExpectedCompletionToHopCompletionDate { get; set; }

        public DapperAsset() { }
        public DapperAsset(IAsset asset)
        {
            AccountingYear = asset.AccountingYear;
            Address = asset.Address;
            AgencyEquityLoan = asset.AgencyEquityLoan;
            CompletionDateForHpiStart = asset.CompletionDateForHpiStart;
            Deposit = asset.Deposit;
            DeveloperEquityLoan = asset.DeveloperEquityLoan;
            DevelopingRslName = asset.DevelopingRslName;
            DifferenceFromImsExpectedCompletionToHopCompletionDate = asset.DifferenceFromImsExpectedCompletionToHopCompletionDate;
            HopCompletionDate = asset.HopCompletionDate;
            ImsActualCompletionDate = asset.ImsActualCompletionDate;
            ImsExpectedCompletionDate = asset.ImsExpectedCompletionDate;
            ImsLegalCompletionDate = asset.ImsLegalCompletionDate;
            ImsOldRegion = asset.ImsOldRegion;
            LocationLaRegionName = asset.LocationLaRegionName;
            MonthPaid = asset.MonthPaid;
            NoOfBeds = asset.NoOfBeds;
            SchemeId = asset.SchemeId;
            ShareOfRestrictedEquity = asset.ShareOfRestrictedEquity;
        }
    }
}
