using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebThiTracNghiem.Areas.Admin.Data
{
    public class QuyenModel
    {
        [Required(ErrorMessage ="Mã quyền không được để trống")]
        public string MaQuyen { get; set; }
        public string TenQuyen { get; set; }
        public string MoTa { get; set; }
    }
}