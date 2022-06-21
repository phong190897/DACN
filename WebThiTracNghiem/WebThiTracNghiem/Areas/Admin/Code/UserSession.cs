using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThiTracNghiem.Areas.Admin.Code
{
    [Serializable]
    public class UserSession
    {
        public string UserName { set; get; }

        public string Quyen { get; set; }
    }
}