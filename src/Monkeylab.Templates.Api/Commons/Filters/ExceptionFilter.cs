using System;
using System.Collections.Generic;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Monkeylab.Templates.Application.Commons.Dtos;
using Monkeylab.Templates.Application.Exceptions;

namespace Monkeylab.Templates.Api.Commons.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {

        private readonly IDictionary<string, Action<ExceptionContext>> _exceptionHandlers;

        private string CustomMessage = "";

        private IEnumerable<ValidationFailure> CustomValidationMessage;

        public ExceptionFilter()
        {
            _exceptionHandlers = new Dictionary<string, Action<ExceptionContext>>
            {
                { nameof(ValidationException), HandleValidationException },
                { nameof(NotFoundException), HandleNotFoundException },
                { nameof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
                { nameof(ForbiddenException), HandleForbiddenAccessException },
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            var errorResponse = BaseResponse.Error<object>(CustomMessage, CustomValidationMessage);
            
            context.Result = new JsonResult(errorResponse);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            var type = context.Exception.GetType().Name;
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            CustomValidationMessage = exception?.Errors;

            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            CustomMessage = exception?.Message;

            context.ExceptionHandled = true;
        }

        private void HandleUnauthorizedAccessException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "Unauthorized",
                Type = "https://tools.ietf.org/html/rfc7235#section-3.1"
            };

            CustomMessage = "Error " + details.Status + ": " + details.Title;

            context.ExceptionHandled = true;
        }

        private void HandleForbiddenAccessException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status403Forbidden,
                Title = "Forbidden",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
            };

            CustomMessage = "Error " + details.Status + ": " + details.Title;

            context.ExceptionHandled = true;
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            CustomMessage = context.Exception.Message;

            context.ExceptionHandled = true;
        }
    }
}