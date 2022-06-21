using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemAPI.Models.ViewModels
{
    public class CauHoiModel
    {
        public string MaCauHoi { get; set; }
        public string TenCauHoi { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string DapAn { get; set; }
        public byte[] HinhAnh { get; set; }
        public string MaLoaiCauHoi { get; set; }
        public string MaMon { get; set; }
    }
}