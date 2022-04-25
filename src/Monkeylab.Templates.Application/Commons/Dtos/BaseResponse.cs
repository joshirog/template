using System.Collections.Generic;
using FluentValidation.Results;

namespace Monkeylab.Templates.Application.Commons.Dtos
{
    public static class BaseResponse
    {
        public static BaseResponse<T> Ok<T>(string message, T data = default) => new BaseResponse<T>(data, message?? "Success", true);
        
        public static BaseResponse<T> Fail<T>(string message, T data = default) => new BaseResponse<T>(data, message, false);
        
        public static BaseResponse<T> Error<T>(string exception, IEnumerable<ValidationFailure> validationErrors) => new BaseResponse<T>(exception, validationErrors);
        
        public static BaseResponse<T> Exception<T>(string exception) => new BaseResponse<T>(exception);
    }
    
    public class BaseResponse<T>
    {
        public BaseResponse(T data, string message, bool success)
        {
            Message = message;
            Data = data;
            IsSuccess = success;
        }
        
        public BaseResponse(string exception, IEnumerable<ValidationFailure> validationErrors = null)
        {
            IsSuccess = false;
            Exception = exception;
            ValidationErrors = validationErrors;
        }
        
        public bool IsSuccess { get; set; }
        
        public T Data { get; set; }
        
        public string Message { get; set; }

        public string Exception { get; set; }
        
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
    }
}