using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebThiTracNghiem.Areas.Admin.Data
{
    public class DeThiModel
    {
        [Required(ErrorMessage = "Bạn Cần Nhập Mã Đề")]
        public string MaDe { get; set; }
        public string MaMon { get; set; }
        public string ChuThich { get; set; }

        [Required(ErrorMessage = "Bạn Cần Nhập Thời Gian Làm Bài")]
        public int ThoiGianLamBai { get; set; }
        public string TacGia { get; set; }
        public string Cauhoi { get; set; }

        [Required(ErrorMessage ="Bạn Cần Nhập Tổng Số Câu Hỏi")]
        public int TongCauHoi { get; set; }
        public string TenMon { get; set; }

        public bool TronDe { get; set; }
    }
}