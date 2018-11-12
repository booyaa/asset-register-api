using System;
using System.Net;
using Infrastructure.Api.Exceptions;
using Infrastructure.Api.Response.Errors;

namespace Infrastructure.Api.Response
{
    public class ApiResponse<T>
    {        
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public ApiError Error { get; set; }

        public ApiResponse(BadRequestException ex)
        {
            StatusCode = (int)ex.StatusCode;
            Error = new ApiError(ex?.ValidationResponse);
        }

        public ApiResponse(ApiException ex)
        {
            StatusCode = (int)ex.StatusCode;
            Error = new ApiError(ex);
        }

        public ApiResponse(Exception ex)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
            Error = new ApiError(ex);
        }

        public ApiResponse(T result)
        {
            StatusCode = (int)HttpStatusCode.OK;
            Data = result;
        }
    }
}
