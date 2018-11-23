using System.Net;
using Infrastructure.Api.Exceptions;

namespace HomesEngland.Exception
{
    public class CreateAssetException : ApiException
    {
        public CreateAssetException() : base(HttpStatusCode.InternalServerError)
        {

        }
    }
}