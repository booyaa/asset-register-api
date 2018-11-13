using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Api.Response.Validation;

namespace HomesEngland.UseCase.Models
{
    public interface IRequest
    {
        RequestValidationResponse Validate(IRequest request);
    }
}
