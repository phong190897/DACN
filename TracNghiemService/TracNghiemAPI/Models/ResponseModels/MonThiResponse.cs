using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TracNghiemAPI.Models.ViewModels;
using TracNghiemAPI.Utils;

namespace TracNghiemAPI.Models
{
    public class MonThiResponse : IBaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<MonThiModel> Data { get; set; }

        public MonThiResponse()
        {
            Data = new List<MonThiModel>();
        }
    }
}