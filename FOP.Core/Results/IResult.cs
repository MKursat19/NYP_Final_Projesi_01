using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace FOP.Core.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
    

