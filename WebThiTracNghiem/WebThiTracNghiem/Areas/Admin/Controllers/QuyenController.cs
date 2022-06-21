using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Areas.Admin.Controllers
{
    [Authorize]
    public class QuyenController : BaseController
    {
        QuyenRepository _quyenRepo = new QuyenRepository();

        // GET: Admin/Quyen
        public ActionResult Index()
        {
            var model = _quyenRepo.GetAllQuyen();

            return View(model.Data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuyenModel quyenModel)
        {

            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var result = _quyenRepo.CreateQuyen(quyenModel);
                    if (result.CheckStatus())
                        return RedirectToAction("Index", "Quyen");
                }
                else
                {
                    ModelState.AddModelError("", "Add Failed");
                }    
                return View();

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var model = _quyenRepo.GetQuyenById(id);

            return View(model.Data.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuyenModel quyenModel)
        {
            try
            {
                // TODO: Add update logic here
                var model = _quyenRepo.UpdateQuyen(quyenModel);

                if(model.CheckStatus())
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Update Failed");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                bool isDeleted = false;
                // TODO: Add delete logic here
                var model = _quyenRepo.DeleteQuyen(id);
                if (model.CheckStatus())
                {
                    isDeleted = true;
                }

                return Json(isDeleted);
            }
            catch
            {
                return View();
            }
        }

    }
}