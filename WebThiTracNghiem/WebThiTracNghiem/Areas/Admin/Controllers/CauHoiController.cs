using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Areas.Admin.Controllers
{
    [Authorize]
    public class CauHoiController : BaseController
    {
        public CauHoiRepository _cauHoiRepo = new CauHoiRepository();
        public LoaiCauHoiRepository loaiCauHoiRepository = new LoaiCauHoiRepository();
        public MonRepository monRepository = new MonRepository();

        // GET: Admin/CauHoi
        public ActionResult Index()
        {
            var model = _cauHoiRepo.GetAllCauHoi();
            var getTenLoaiCauHoi = loaiCauHoiRepository.GetLoaiCauHoiToDropDownList();
            var getMonThi = monRepository.GetMonThiToDropDownList();

            var result = from tenLoaiCauHoi in getTenLoaiCauHoi
                         join cauHoi in model.Data on tenLoaiCauHoi.MaLoaiCauHoi equals cauHoi.MaLoaiCauHoi into modelB
                         from a in modelB
                         join monThi in getMonThi on a.MaMon equals monThi.MaMon into modelC
                         from b in modelC
                         select new CauHoiModel
                         {
                             MaCauHoi = a.MaCauHoi,
                             TenCauHoi = a.TenCauHoi,
                             TenLoaiCauHoi = tenLoaiCauHoi.TenLoaiCauHoi,
                             TenMonHoc = b.TenMon
                         };
                         
            return View(result);
        }

        // GET: Admin/CauHoi/Details/5
        public ActionResult Details(string id)
        {

            var model = _cauHoiRepo.GetCauHoiByID(id);

            List<LoaiCauHoiModel> listLoaiCauHoi = loaiCauHoiRepository.GetLoaiCauHoiToDropDownList();
            List<MonModel> listMonThi = monRepository.GetMonThiToDropDownList();

            var loaiCauHoi = new List<SelectListItem>();
            var monThi = new List<SelectListItem>();

            loaiCauHoi.AddRange(from a in listLoaiCauHoi
                                select new SelectListItem
                                {
                                    Text = a.TenLoaiCauHoi,
                                    Value = a.MaLoaiCauHoi,
                                    Selected = a.MaLoaiCauHoi == model.Data.FirstOrDefault().MaLoaiCauHoi
                                });
            monThi.AddRange(from a in listMonThi
                            select new SelectListItem
                            {
                                Text = a.TenMon,
                                Value = a.MaMon,
                                Selected = a.MaMon == model.Data.FirstOrDefault().MaMon
                            });

            if (listLoaiCauHoi.Count != 0)
            {
                ViewBag.LoaiCauHoi = loaiCauHoi;
            }
            if (listMonThi.Count != 0)
            {
                ViewBag.MonThi = monThi;
            }

            return View(model.Data.FirstOrDefault());
        }

        // GET: Admin/CauHoi/Create
        public ActionResult Create()
        {
            List<LoaiCauHoiModel> listLoaiCauHoi = loaiCauHoiRepository.GetLoaiCauHoiToDropDownList();
            List<MonModel> listMonThi = monRepository.GetMonThiToDropDownList();

            var loaiCauHoi = new List<SelectListItem>();
            var monThi = new List<SelectListItem>();

            loaiCauHoi.AddRange(from a in listLoaiCauHoi
                                select new SelectListItem
                                {
                                    Text = a.TenLoaiCauHoi,
                                    Value = a.MaLoaiCauHoi
                                });
            monThi.AddRange(from a in listMonThi
                            select new SelectListItem
                            {
                                Text = a.TenMon,
                                Value = a.MaMon
                            });

            if (listLoaiCauHoi.Count != 0)
            {
                ViewBag.LoaiCauHoi = loaiCauHoi;
            }
            if (listMonThi.Count != 0)
            {
                ViewBag.MonThi = monThi;
            }

            return View();
        }

        // POST: Admin/CauHoi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CauHoiModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var addNewCauHoi = _cauHoiRepo.CreateCauHoi(collection);
                    if (addNewCauHoi.CheckStatus())
                        return RedirectToAction("Index", "CauHoi");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CauHoi/Edit/5
        public ActionResult Edit(string id)
        {
            var model = _cauHoiRepo.GetCauHoiByID(id);

            List<LoaiCauHoiModel> listLoaiCauHoi = loaiCauHoiRepository.GetLoaiCauHoiToDropDownList();
            List<MonModel> listMonThi = monRepository.GetMonThiToDropDownList();

            var loaiCauHoi = new List<SelectListItem>();
            var monThi = new List<SelectListItem>();

            loaiCauHoi.AddRange(from a in listLoaiCauHoi
                                select new SelectListItem
                                {
                                    Text = a.TenLoaiCauHoi,
                                    Value = a.MaLoaiCauHoi,
                                    Selected = a.MaLoaiCauHoi == model.Data.FirstOrDefault().MaLoaiCauHoi
                                });
            monThi.AddRange(from a in listMonThi
                            select new SelectListItem
                            {
                                Text = a.TenMon,
                                Value = a.MaMon,
                                Selected = a.MaMon == model.Data.FirstOrDefault().MaMon
                            });

            if (listLoaiCauHoi.Count != 0)
            {
                ViewBag.LoaiCauHoi = loaiCauHoi;
            }
            if (listMonThi.Count != 0)
            {
                ViewBag.MonThi = monThi;
            }

            return View(model.Data.FirstOrDefault());
        }

        // POST: Admin/CauHoi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CauHoiModel collection)
        {
            try
            {
                // TODO: Add update logic here
                var model = _cauHoiRepo.UpdateCauHoi(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CauHoi/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Admin/CauHoi/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            try
            {
                bool isDeleted = false;
                // TODO: Add delete logic here
                var model = _cauHoiRepo.DeleteCauHoi(id);
                if(model.CheckStatus())
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

        public string SaveFile(HttpPostedFileBase file)
        {
            DateTime date = DateTime.Now;
            string relativePath = Server.MapPath("~/Images/CauHoi/");
            string virtualPath, returnPath = date.Year + "-" + date.Month + "-" + date.Day + "-" + date.Hour + "-" +
                                 date.Minute + "-" + date.Second + "-" + date.Millisecond;
            virtualPath = relativePath + returnPath;
            if (!Directory.Exists(virtualPath))
                Directory.CreateDirectory(virtualPath);
            string FileName = file.FileName;
            if (Request.Browser.Browser.Contains("InternetExplorer") || Request.Browser.Browser.Contains("IE"))
            {
                FileName = FileName.Substring(FileName.LastIndexOf("\\") + 1);
            }
            if (System.IO.File.Exists(Path.Combine(virtualPath, FileName)))
            {
                FileName = $"{Guid.NewGuid()}_{FileName}";
            }

            file.SaveAs(Path.Combine(virtualPath, FileName));
            return returnPath + "/" + FileName;
        }
    }
}
