using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebThiTracNghiem.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời Nhập Tài Khoản")]
        public string TenTaiKhoan { get; set; }
        [Required(ErrorMessage = "Mời Nhập Mật Khẩu")]
        public string MatKhau { get; set; }
    }
}