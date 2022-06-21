using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemAPI.Models.ViewModels
{
    public class TaiKhoanModel
    {
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string MaQuyen { get; set; }
        public byte[] HinhAnh { get; set; }

    }
}