using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThiTracNghiem.Areas.Admin.Data
{
    public class BaiThiModel
    {
        public string MaBaiThi { get; set; }
        public string TaiKhoan { get; set; }
        public string MaDe { get; set; }
        public int ThoiGianHoanThanh { get; set; }
        public string SoCauDung { get; set; }
        public int Diem { get; set; }
        public string CauTraLoi { get; set; }
        public System.DateTime NgayThi { get; set; }

        public int TongSoCau { get; set; }
        public double Diem10 { get; set; }
    }
}