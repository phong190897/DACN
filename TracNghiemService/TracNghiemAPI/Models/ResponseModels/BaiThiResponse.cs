using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TracNghiemAPI.Models.ViewModels;
using TracNghiemAPI.Utils;

namespace TracNghiemAPI.Models
{
    public class BaiThiResponse:IBaseResponse
    {

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<BaiThiModel> Data { get; set; }

        public BaiThiResponse()
        {
            Data = new List<BaiThiModel>();
        }


    }
}