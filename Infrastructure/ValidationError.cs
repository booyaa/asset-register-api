using System;
using FluentValidation.Results;

namespace Infrastructure
{
    public class ValidationError
    {
        public string Message { get; set; }
        public string FieldName { get; set; }

        [Obsolete("Do not use, for serializer only")]
        public ValidationError()
        {

        }

        public ValidationError(ValidationFailure validationFailure)
        {
            Message = validationFailure?.ErrorMessage;
            FieldName = validationFailure?.PropertyName;
        }
    }
}