using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThiTracNghiem.Areas.Admin.Data
{
    public class DetailsBaiThiViewModel
    {
        public BaiThiModel BaiThi { get; set; }
        
        public DeThiModel DeThi { get; set; }

        public List<CauHoiModel> CauHois { get; set; }

        public DetailsBaiThiViewModel()
        {
        }

        public DetailsBaiThiViewModel(List<CauHoiModel> cauHois)
        {
            CauHois = cauHois;
        }
    }
}