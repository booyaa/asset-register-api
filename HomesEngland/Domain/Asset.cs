using System;
using System.Collections.Generic;

namespace HomesEngland.Domain
{
    public class Asset
    {
        public string MonthPaid { get; set; }
        public string AccountingYear { get; set; }
        public string SchemeID { get; set; }

        //Identifying Information
        public string LocationLaRegionName { get; set; }
        public string IMSOldRegion { get; set; }
        public string NoOfBeds { get; set; }
        //IMS Adress
        public string Address { get; set; }
        public string DevelopingRslName { get; set; }
        //Completion Dates
        public DateTime CompletionDateForHpiStart { get; set; }
        public DateTime ImsActualCompletionDate { get; set; }
        public DateTime ImsExpectedCompletionDate { get; set; }
        public DateTime ImsLegalCompletionDate { get; set; }
        public DateTime HopCompletionDate { get; set; }
        //Financial Information
        public decimal Deposit { get; set; }
        public decimal AgencyEquityLoan { get; set; }
        public decimal DeveloperEquityLoan { get; set; }
        public decimal ShareOfRestrictedEquity { get; set; }
        //Calcuation
        public int DifferenceFromIMSExpectedCompletionToHopCompletionDate { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string> {
                {"Address", Address },
                {"SchemeID", SchemeId.ToString()},
                {"AccountingYear", AccountingYear.ToString()}
            };
        }
    }
}