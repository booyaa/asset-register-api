using System;
using System.Net;

namespace Infrastructure.Api.Exceptions
{
    /// <summary>
    /// Http Status Code aware exception class
    /// Throw an exception with a corresponding HttpStatus Code
    /// Allowing any Http services to response with the correct status code
    /// </summary>
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Unhandled Exception
        /// </summary>
        public ApiException()
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        /// <summary>
        /// Initialise with Exception
        /// </summary>
        /// <param name="ex"></param>
        public ApiException(Exception ex) : base(ex?.Message, ex)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        /// <summary>
        /// Initialise with statuscode
        /// </summary>
        /// <param name="status"></param>
        public ApiException(HttpStatusCode status)
        {
            StatusCode = status;
        }

        /// <summary>
        /// Initialise with Status Code and Message
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public ApiException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}