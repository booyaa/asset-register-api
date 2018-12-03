using System;
using System.Collections.Generic;
using HomesEngland.UseCase.GetAsset.Models;
using HomesEngland.UseCase.Models;
using Infrastructure.Api.Response.Validation;

namespace HomesEngland.UseCase.ExportCsv.Models
{
    public class ExportCsvRequest:IRequest
    {
        public IList<AssetOutputModel> Assets { get; set; }

        public RequestValidationResponse Validate(IRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
