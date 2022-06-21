using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemAPI.Models.ViewModels
{
    public class DeThiModel
    {
        public string MaDe { get; set; }
        public string MaMon { get; set; }
        public string ChuThich { get; set; }
        public int ThoiGianLamBai { get; set; }
        public string TacGia { get; set; }
        public string Cauhoi { get; set; }
        public int TongCauHoi { get; set; }
    }
}