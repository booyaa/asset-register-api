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
    }
}
