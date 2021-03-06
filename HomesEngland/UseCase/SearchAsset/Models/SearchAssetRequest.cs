﻿using HomesEngland.UseCase.Models;
using HomesEngland.UseCase.SearchAsset.Models.Validation;
using Infrastructure.Api.Response.Validation;

namespace HomesEngland.UseCase.SearchAsset.Models
{
    public class SearchAssetRequest : IRequest
    {
        public int? SchemeId { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string Address { get; set; }

        public SearchAssetRequest()
        {
            Page = 1;
            PageSize = 25;
        }

        public RequestValidationResponse Validate(IRequest request)
        {
            if (request == null)
                return new RequestValidationResponse(false);
            var validator = new SearchAssetRequestValidator();
            var getAssetRequest = (SearchAssetRequest) request;
            var validationResult = validator.Validate(getAssetRequest);
            var validationResponse = new RequestValidationResponse(validationResult);
            return validationResponse;
        }
    }
}
