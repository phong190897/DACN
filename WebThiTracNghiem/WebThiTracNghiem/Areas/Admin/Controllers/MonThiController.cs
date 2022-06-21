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
    public class MonThiController : BaseController
    {
        MonRepository _monRepo = new MonRepository();

        // GET: Admin/MonThi
        public ActionResult Index()
        {
            var model = _monRepo.GetMonThiToDropDownList();
            return View(model);
        }


        // GET: Admin/MonThi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MonThi/Create
        [HttpPost]
        public ActionResult Create(MonModel mon)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var result = _monRepo.CreateMonThi(mon);

                    if(result.CheckStatus())
                    {
                        return RedirectToAction("Index");
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

        // GET: Admin/MonThi/Edit/5
        public ActionResult Edit(string id)
        {
            var model = _monRepo.GetMonThiById(id);

            return View(model.Data.FirstOrDefault());
        }

        // POST: Admin/MonThi/Edit/5
        [HttpPost]
        public ActionResult Edit(MonModel mon)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _monRepo.UpdateMonThi(mon);

                    if (result.CheckStatus())
                    {
                        return RedirectToAction("Index");
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

        // POST: Admin/MonThi/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                bool isDeleted = false;
                // TODO: Add delete logic here
                var model = _monRepo.DeleteMonThi(id);
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
