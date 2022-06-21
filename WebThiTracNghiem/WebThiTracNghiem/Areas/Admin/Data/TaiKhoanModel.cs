using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebThiTracNghiem.Areas.Admin.Data
{
    public class TaiKhoanModel
    {
        [Required(ErrorMessage ="Tài khoản không được để trống")]
        [Display(Name ="Tài Khoản")]
        public string TenTaiKhoan { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [Display(Name = "Mật Khẩu")]
        public string Matkhau { get; set; }
        [Display(Name = "Quyền")]
        public string MaQuyen { get; set; }

        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }

        [Display(Name = "Giới Tính")]
        public bool GioiTinh { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Ảnh")]
        public byte[] Anh { get; set; }

        public string TenQuyen { get; set; }
    }
}