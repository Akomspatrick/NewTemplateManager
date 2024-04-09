using NewTemplateManager.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewTemplateManager.DomainBase.Result
{
    public readonly struct Result<TValue, TError>
    {
        private readonly TValue? _value;
        private readonly TError? _error;
        private readonly bool _isSuccess;
        private readonly string? _message;


        private Result(TValue value, string? message = "")
        {
            if (_isSuccess & _error != null ||
                               !_isSuccess & _error == null)
            {
                throw new ArgumentException("Attempt to call an error a success");
            }
            _isSuccess = true;
            _value = value;
            _message = message;
        }

        private Result(TError error, string? message = "")
        {
            if (_isSuccess & _error != null ||
                               !_isSuccess & _error == null)
            {
                throw new ArgumentException("Attempt to call an error a success");
            }
            _isSuccess = true;
            _error = error;
            _message = message;
        }

    }
    public class Result2<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }
        public GeneralFailure ErrorMessage { get; set; }

        //private Result()
        //{
        //    IsSuccess = false;
        //    Message = string.Empty;
        //    Value = default(T);
        //    ErrorMessage = string.Empty;
        //}
        //private Result(bool isSuccess, string message, T data, GeneralFailure errorMessage)
        //{
        //    if (isSuccess & errorMessage != GeneralFailure.None ||
        //        !isSuccess & errorMessage == GeneralFailure.None)
        //    {
        //        throw new ArgumentException("Attempt to call an error a success");
        //    }
        //    IsSuccess = isSuccess;
        //    Message = message;
        //    Value = data;
        //    ErrorMessage = errorMessage;
        //}
        //public static Result<T> Success(T data, string? message = "") => new Result<T>(true, message, data, GeneralFailure.None)
        //{ IsSuccess = true, Value = data, Message = message, ErrorMessage = GeneralFailure.None };

        //public static Result<T> Failure(GeneralFailure errorMessage, string? message = "")
        //  => new Result<T>(false, message, default, errorMessage) { IsSuccess = false, Message = message, ErrorMessage = errorMessage };


        //public static Result<T> Success(T data, string? message = "") => new()
        //{ IsSuccess = true, Value = data, Message = message, ErrorMessage = GeneralFailure.None };

        //public static Result<T> Failure(GeneralFailure errorMessage, string? message = "")
        //  => new()
        //  { IsSuccess = false, Message = message, ErrorMessage = errorMessage };


        //public Result(bool isSuccess, string message, T data)
        //{
        //    IsSuccess = isSuccess;
        //    Message = message;
        //    Value = data;
        //}
    }
}
