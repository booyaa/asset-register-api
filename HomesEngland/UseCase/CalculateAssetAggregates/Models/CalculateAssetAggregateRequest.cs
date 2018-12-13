using HomesEngland.UseCase.Models;
using Infrastructure.Api.Response.Validation;

namespace HomesEngland.UseCase.CalculateAssetAggregates.Models
{
    public class CalculateAssetAggregateRequest : IRequest
    {
        public int? SchemeId { get; set; }
        public string Address { get; set; }

        public RequestValidationResponse Validate(IRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
