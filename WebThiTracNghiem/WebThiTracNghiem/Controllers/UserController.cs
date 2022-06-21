using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Controllers;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Controllers
{
    [Authorize]

    public class UserController : BaseController
    {
        TaiKhoanRepository _taiKhoanRepo = new TaiKhoanRepository();
        QuyenRepository _quyenRepo = new QuyenRepository();

        // GET: User
        public ActionResult Detail(string id)
        {
            var model = _taiKhoanRepo.getTaiKhoanInfo(id);

            List<QuyenModel> listQuyen = _quyenRepo.GetQuyenById(model.Data.FirstOrDefault().MaQuyen).Data;
            List<SelectListItem> quyen = new List<SelectListItem>();

            quyen.AddRange(from a in listQuyen
                           select new SelectListItem
                           {
                               Text = a.TenQuyen,
                               Value = a.MaQuyen,
                               Selected = a.MaQuyen == model.Data.FirstOrDefault().MaQuyen
                           });
            if (listQuyen.Count != 0)
            {
                ViewBag.Quyen = quyen;
            }

            return View(model.Data.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Detail(TaiKhoanModel taiKhoanModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = _taiKhoanRepo.UpdateTaiKhoan(taiKhoanModel);
                    if (model.CheckStatus())
                    {
                        return RedirectToAction("Detail");
                    }
                }
                else
                {
                    var model = _taiKhoanRepo.getTaiKhoanInfo(taiKhoanModel.TenTaiKhoan);

                    ModelState.AddModelError("", "Update Failed");

                    return View(model.Data.FirstOrDefault());
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}