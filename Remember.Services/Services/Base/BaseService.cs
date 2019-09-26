using FluentValidation.Results;
using Remember.Domain.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.Services.Services
{
    public class BaseService
    {
        protected BaseResponse DefaultFailure()
        {
            return new BaseResponse(false);
        }

        protected BaseResponse DefaultValidationFailure(IList<ValidationFailure> errors)
        {
            return new BaseResponse(false) { Errors = errors };
        }

        protected BaseResponse DefaultSuccess(object response)
        {
            return new BaseResponse() { Data = response };
        }

        protected BaseResponse CreateValidationFailure (string property, string message, string oldValue = null)
        {
            return new BaseResponse(false) { Errors = new List<ValidationFailure> { new ValidationFailure(property, message, oldValue) } };      
        }
    }
}
