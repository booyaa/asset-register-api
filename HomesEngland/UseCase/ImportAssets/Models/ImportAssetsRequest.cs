using System;
using System.Collections.Generic;
using System.Text;
using HomesEngland.UseCase.ImportAssets.Validation;
using HomesEngland.UseCase.Models;
using Infrastructure.Api.Response.Validation;

namespace HomesEngland.UseCase.ImportAssets.Models
{
    public class ImportAssetsRequest:IRequest
    {
        public IList<string> AssetLines { get; set; }
        public string Delimiter { get; set; }

        public RequestValidationResponse Validate(IRequest request)
        {
            if (request == null)
                return new RequestValidationResponse(false);
            var validator = new ImportAssetsRequestValidator();
            var typedRequest = (ImportAssetsRequest)request;
            var validationResult = validator.Validate(typedRequest);
            var validationResponse = new RequestValidationResponse(validationResult);
            return validationResponse;
        }
    }
}
