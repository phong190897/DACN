using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TracNghiemAPI.Models.ViewModels;
using TracNghiemAPI.Utils;

namespace TracNghiemAPI.Models
{
    public class LoaiCauHoiResponse : IBaseResponse
    {

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<LoaiCauHoiModel> Data { get; set; }

        public LoaiCauHoiResponse()
        {
            Data = new List<LoaiCauHoiModel>();
        }

    }
}