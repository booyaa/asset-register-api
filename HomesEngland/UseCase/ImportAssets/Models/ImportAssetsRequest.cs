using System;
using System.Collections.Generic;
using System.Text;
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
            throw new NotImplementedException();
        }
    }
}
