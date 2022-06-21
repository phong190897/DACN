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
    public class LoaiCauHoiController : BaseController
    {
        LoaiCauHoiRepository _loaiCauHoiRepo = new LoaiCauHoiRepository();

        // GET: Admin/LoaiCauHoi
        public ActionResult Index()
        {
            var model = _loaiCauHoiRepo.GetLoaiCauHoiToDropDownList();
            return View(model);
        }

        // GET: Admin/LoaiCauHoi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiCauHoi/Create
        [HttpPost]
        public ActionResult Create(LoaiCauHoiModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _loaiCauHoiRepo.CreateLoaiCauHoi(model);
                    if (result.CheckStatus())
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Insert Failed!!!");
                        return View();
                    }
                }

                // TODO: Add insert logic here

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiCauHoi/Edit/5
        public ActionResult Edit(string id)
        {
            var model = _loaiCauHoiRepo.GetLoaiCauHoiById(id);

            return View(model.Data.FirstOrDefault());
        }

        // POST: Admin/LoaiCauHoi/Edit/5
        [HttpPost]
        public ActionResult Edit(LoaiCauHoiModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var result = _loaiCauHoiRepo.UpdateLoaiCauHoi(model);

                    if(result.CheckStatus())
                    {
                        return RedirectToAction("Index");
                    }    
                    else
                    {
                        ModelState.AddModelError("", "Update Failed");
                        return View();
                    }    
                }

                return View();
                // TODO: Add update logic here
            }
            catch
            {
                return View();
            }
        }

        // POST: Admin/LoaiCauHoi/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                bool isDeleted = false;
                // TODO: Add delete logic here
                var model = _loaiCauHoiRepo.DeleteLoaiCauHoi(id);
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
