using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThiTracNghiem.Areas.Admin.Data
{
    public class KetQuaBaiThiModel
    {
        public string MaDe { get; set; }

        public int ThoiGianLamBai { get; set; }
        public int SoCauDung { get; set; }
        public int Diem { get; set; }

        public int TongSoCau { get; set; }

        public List<CauHoiModel> CauHois { get; set; }

    }
}