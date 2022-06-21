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
    public class BaiThiController : BaseController
    {
        BaiThiRepository _BaiThiRepo = new BaiThiRepository();
        // GET: Admin/BaiThi
        public ActionResult Index()
        {
            var model = _BaiThiRepo.GetAllBaiThi();

            return View(model.Data);
        }

        // GET: Admin/BaiThi/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: Admin/BaiThi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BaiThi/Create
        [HttpPost]
        public ActionResult Create(BaiThiModel baiThiModel)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/BaiThi/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: Admin/BaiThi/Edit/5
        [HttpPost]
        public ActionResult Edit(BaiThiModel baiThiModel)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Admin/BaiThi/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
