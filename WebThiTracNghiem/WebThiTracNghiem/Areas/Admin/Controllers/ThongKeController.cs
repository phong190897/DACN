using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Models;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Areas.Admin.Controllers
{
    [Authorize]
    public class ThongKeController : BaseController
    {
        DeThiRepository _deThiRepo = new DeThiRepository();
        BaiThiRepository _baiThiRepo = new BaiThiRepository();

        // GET: Admin/ThongKe
        public ActionResult Index()
        {
            var BaiThis = _baiThiRepo.GetAllBaiThi().Data;
            var DeThis = _deThiRepo.GetAllDeThi().Data;

            ViewBag.TongBaiThi = BaiThis.Count();
            ViewBag.TongDeThi = DeThis.Count();

            var DeThiDcLamNhieuNhat = from bt in BaiThis
                                      group bt by bt.MaDe into btGroup
                                      select new MaxDeThi
                                      {
                                          MaDe = btGroup.Key,
                                          SoLan = btGroup.Count(),
                                      };
            ViewBag.MaxDeThi = DeThiDcLamNhieuNhat.OrderByDescending(m => m.SoLan).FirstOrDefault();

            var NguoiLamBaiThiNhieuNhat = from bt in BaiThis
                                          group bt by bt.TaiKhoan into btGroup
                                          select new MaxDeThi
                                          {
                                              TenTK = btGroup.Key,
                                              SoLan = btGroup.Count(),
                                          };

            ViewBag.MaxUserThiNhieuNhat = NguoiLamBaiThiNhieuNhat.OrderByDescending(m => m.SoLan).FirstOrDefault();

            return View();
        }
    }
}