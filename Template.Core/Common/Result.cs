using System;
using System.Collections.Generic;

namespace Template.Core.Common
{
    /// <summary>
    /// Generic result wrapper for operation results
    /// </summary>
    /// <typeparam name="T">Type of the result data</typeparam>
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Data { get; }
        public string Error { get; }
        public List<string> ValidationErrors { get; }

        private Result(bool isSuccess, T data, string error = null, List<string> validationErrors = null)
        {
            IsSuccess = isSuccess;
            Data = data;
            Error = error;
            ValidationErrors = validationErrors ?? new List<string>();
        }

        public static Result<T> Success(T data) => new Result<T>(true, data);
        
        public static Result<T> Failure(string error) => new Result<T>(false, default, error);
        
        public static Result<T> ValidationFailure(List<string> validationErrors) => 
            new Result<T>(false, default, "Validation failed", validationErrors);
    }
} 