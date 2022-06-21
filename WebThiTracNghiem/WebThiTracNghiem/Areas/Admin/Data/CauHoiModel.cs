using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebThiTracNghiem.Models;

namespace WebThiTracNghiem.Areas.Admin.Data
{
    public class CauHoiModel
    {
        [DisplayName("Mã Câu Hỏi")]
        [StringLength(8, ErrorMessage ="Mã câu hỏi có tối đa 8 ký tự")]
        [Required(ErrorMessage ="Bạn cần nhập mã câu hỏi")]
        public string MaCauHoi { get; set; }

        [DisplayName("Tên Câu Hỏi")]
        public string TenCauHoi { get; set; }

        [DisplayName("Đáp Án A")]
        public string A { get; set; }
        [DisplayName("Đáp Án B")]
        public string B { get; set; }

        [DisplayName("Đáp Án C")]
        public string C { get; set; }

        [DisplayName("Đáp Án D")]
        public string D { get; set; }

        [DisplayName("Đáp Án Đúng")]
        public string DapAn { get; set; }

        [DisplayName("Hình Ảnh")]
        public byte[] HinhAnh { get; set; }

        [DisplayName("Mã Loại Câu Hỏi")]
        public string MaLoaiCauHoi { get; set; }

        [DisplayName("Mã Môn Học")]
        public string MaMon { get; set; }

        public string TenLoaiCauHoi { get; set; }

        public string TenMonHoc { get; set; }

        public string DapAnChu { get; set; }

    }
}