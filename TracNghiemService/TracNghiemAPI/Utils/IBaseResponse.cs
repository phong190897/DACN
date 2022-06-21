using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemAPI.Utils
{
    public interface IBaseResponse
    {
        int StatusCode { get; set; }
        string Message { get; set; }
    }
}