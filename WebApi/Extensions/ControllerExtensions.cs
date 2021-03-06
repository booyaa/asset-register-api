﻿using System.Collections.Generic;
using System.Threading;
using HomesEngland.UseCase.SearchAsset.Models;
using Infrastructure.Api.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace WebApi.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult StandardiseResponse<TResponse,TData>(this ControllerBase controller, TResponse useCaseResult) where TResponse:IResponse<TData>
        {
            
            if (controller?.Request != null &&
                controller.ControllerContext.HttpContext.Request.Headers.Contains(new KeyValuePair<string, StringValues>("accept", "text/csv")))
            {
                controller.ControllerContext.HttpContext?.Response?.Headers.Add("Content-Disposition", "attachment; filename=export.csv;");
                return controller.StatusCode(200, useCaseResult?.ToCsv());
            }
                
            var apiResponse = new ApiResponse<TResponse>(useCaseResult);

            return controller?.StatusCode(apiResponse.StatusCode, apiResponse);
        }

        public static CancellationToken GetCancellationToken(this ControllerBase controller)
        {
            if(controller?.HttpContext == null)
                return new CancellationToken();
            return controller.HttpContext.RequestAborted;
        }
    }
}
