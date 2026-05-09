using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Core.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public Result(bool success) : this(success, "")
        {
        }
    }

    public class SuccessResult : Result
    {
        public SuccessResult() : base(true, "")
        {

        }
        public SuccessResult(string message) : base(true, message)
        {
        }
    }

    public class ErrorResult : Result
    {
        public ErrorResult() : base(false, "")
        {

        }
        public ErrorResult(string message) : base(false, message)
        {
        }
    }
}

