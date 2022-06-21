using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TracNghiemAPI.Models.ViewModels;
using TracNghiemAPI.Utils;

namespace TracNghiemAPI.Models
{
    public class CauHoiResponse: IBaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<CauHoiModel> Data { get; set; }

        public CauHoiResponse()
        {
            Data = new List<CauHoiModel>();
        }
    }
}