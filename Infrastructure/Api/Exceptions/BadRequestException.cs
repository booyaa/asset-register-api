using System.Net;
using Infrastructure.Api.Response.Validation;

namespace Infrastructure.Api.Exceptions
{
    public class BadRequestException : ApiException
    {
        public RequestValidationResponse ValidationResponse { get; set; }

        public BadRequestException() : base(HttpStatusCode.BadRequest, "Request is null")
        {

        }

        public BadRequestException(RequestValidationResponse validationResponse)
        {
            StatusCode = HttpStatusCode.BadRequest;
            ValidationResponse = validationResponse;
        }
    }
}