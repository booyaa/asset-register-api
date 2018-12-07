using System;
using HomesEngland.UseCase.Models;
using Infrastructure.Api.Response.Validation;

namespace HomesEngland.UseCase.CreateAsset.Models
{
    public class CreateAssetRequest : IRequest
    {
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

        public RequestValidationResponse Validate(IRequest request)
        {
            throw new NotImplementedException();
        }

        public CreateAssetRequest(){}
    }
}
