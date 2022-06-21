using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TracNghiemAPI.Models.ViewModels;
using TracNghiemAPI.Utils;


namespace TracNghiemAPI.Models
{
    public class TaiKhoanResponse: IBaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public List<TaiKhoanModel> Data { get; set; }

        public TaiKhoanResponse()
        {
            Data = new List<TaiKhoanModel>();
        }
    }
}