using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemAPI.Models.ViewModels
{
    public class BaiThiModel
    {

        public string MaBaiThi { get; set; }
        public string TaiKhoan { get; set; }
        public string MaDe { get; set; }
        public Nullable<int> ThoiGianHoanThanh { get; set; }
        public string SoCauDung { get; set; }
        public Nullable<int> Diem { get; set; }
        public string CauTraLoi { get; set; }
        public Nullable<System.DateTime> NgayThi { get; set; }

    }
}