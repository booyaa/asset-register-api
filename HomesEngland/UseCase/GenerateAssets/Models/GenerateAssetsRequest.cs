using HomesEngland.UseCase.GenerateAssets.Models.Validation;
using HomesEngland.UseCase.Models;
using Infrastructure.Api.Response.Validation;

namespace HomesEngland.UseCase.GenerateAssets.Models
{
    public class GenerateAssetsRequest : IRequest
    {
        public int? Records { get; set; }

        public RequestValidationResponse Validate(IRequest request)
        {
            if (request == null)
                return new RequestValidationResponse(false);
            var validator = new GenerateAssetsRequestValidator();
            var getAssetRequest = (GenerateAssetsRequest)request;
            var validationResult = validator.Validate(getAssetRequest);
            var validationResponse = new RequestValidationResponse(validationResult);
            return validationResponse;
        }
    }
}
