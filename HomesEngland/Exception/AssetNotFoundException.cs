using System.Net;
using Infrastructure.Api.Exceptions;

namespace HomesEngland.Exception
{
    public class AssetNotFoundException : ApiException
    {
        public AssetNotFoundException(): base(HttpStatusCode.NotFound)
        {

        }
    }
}