﻿using System;
using System.Collections.Generic;
using Infrastructure.Api.Response.Validation;

namespace Infrastructure.Api.Response.Errors
{
    public class ApiError
    {
        public bool IsValidationError { get; set; }
        public IList<ExecutionError> Errors { get; set; }
        public IList<ValidationError> ValidationErrors { get; set; }

        public ApiError(Exception ex)
        {
            Errors = new List<ExecutionError> { new ExecutionError(ex) };
        }


        public ApiError(RequestValidationResponse validationResponse)
        {
            if (validationResponse == null)
                IsValidationError = true;
            else
            {
                IsValidationError = !validationResponse.IsValid;
                ValidationErrors = validationResponse.ValidationErrors;
            }
        }

    }
}