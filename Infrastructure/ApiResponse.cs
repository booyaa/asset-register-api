using System;
using System.Net;

namespace Infrastructure
{
    public class ApiResponse<T> where T : class
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
