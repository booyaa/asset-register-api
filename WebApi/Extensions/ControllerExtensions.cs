using System.Threading;
using Infrastructure.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult StandardiseResponse<T>(this ControllerBase controller, T useCaseResult)
        {
            var apiResponse = new ApiResponse<T>(useCaseResult);
            return controller.StatusCode(apiResponse.StatusCode, apiResponse);
        }

        public static CancellationToken GetCancellationToken(this ControllerBase controller)
        {
            if(controller?.HttpContext == null)
                return new CancellationToken();
            return controller.HttpContext.RequestAborted;
        }
    }
}
