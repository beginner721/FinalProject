using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success) //this:  bu class demektir.. alttaki resultu da çalıştırır
        {
            Message = message; //getler ctor içinde set edilebilir... başka yerde edilemez
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
