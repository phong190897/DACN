using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TracNghiemAPI.Models.ViewModels;
using TracNghiemAPI.Utils;

namespace TracNghiemAPI.Models
{
    public class QuyenResponse : IBaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<QuyenModel> Data { get; set; }

        public QuyenResponse()
        {
            Data = new List<QuyenModel>();
        }

    }
}