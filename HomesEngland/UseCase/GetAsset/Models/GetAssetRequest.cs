using HomesEngland.UseCase.GetAsset.Models.Validation;
using HomesEngland.UseCase.Models;
using Infrastructure.Api.Response.Validation;

namespace HomesEngland.UseCase.GetAsset.Models
{
    public class GetAssetRequest:IRequest
    {
        public int? Id { get; set; }
        public RequestValidationResponse Validate(IRequest request)
        {
            if(request == null)
                return new RequestValidationResponse(false);
            var validator = new GetAssetRequestValidator();
            var validationResult = validator.Validate(request as GetAssetRequest);
            var validationResponse = new RequestValidationResponse(validationResult);
            return validationResponse;
        }
    }
}
