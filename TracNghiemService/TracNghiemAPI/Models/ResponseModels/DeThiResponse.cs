using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TracNghiemAPI.Models.ViewModels;
using TracNghiemAPI.Utils;

namespace TracNghiemAPI.Models
{
    public class DeThiResponse: IBaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<DeThiModel> Data { get; set; }

        public DeThiResponse()
        {
            Data = new List<DeThiModel>();
        }
    }
}