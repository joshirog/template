using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Monkeylab.Templates.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new List<ValidationFailure>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures;
        }

        public IEnumerable<ValidationFailure> Errors { get; }
    }
}