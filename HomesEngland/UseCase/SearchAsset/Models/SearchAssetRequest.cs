using HomesEngland.UseCase.GetAsset.Models.Validation;
using HomesEngland.UseCase.Models;
using Infrastructure.Api.Response.Validation;

namespace HomesEngland.UseCase.GetAsset.Models
{
    public class SearchAssetRequest : IRequest
    {
        public int? SchemeId { get; set; }

        public RequestValidationResponse Validate(IRequest request)
        {
            if (request == null)
                return new RequestValidationResponse(false);
            var validator = new SearchAssetRequestValidator();
            var getAssetRequest = (SearchAssetRequest)request;
            var validationResult = validator.Validate(getAssetRequest);
            var validationResponse = new RequestValidationResponse(validationResult);
            return validationResponse;
        }
    }
}
