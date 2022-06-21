using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Areas.Admin.Controllers
{
    [Authorize]
    public class DeThiController : BaseController
    {
        DeThiRepository _deThiRepo = new DeThiRepository();
        MonRepository _monThiRepo = new MonRepository();
        CauHoiRepository _cauHoiRepo = new CauHoiRepository();
        // GET: Admin/DeThi
        public ActionResult Index()
        {
            var model = _deThiRepo.GetAllDeThi();
            var tenMon = _monThiRepo.GetMonThiToDropDownList();

            var result = (from dt in model.Data
                          join m in tenMon on dt.MaMon equals m.MaMon
                          select new DeThiModel
                          {
                              MaDe = dt.MaDe,
                              TenMon = m.TenMon,
                              TacGia = dt.TacGia,
                              ThoiGianLamBai = dt.ThoiGianLamBai,
                              TongCauHoi = dt.TongCauHoi,
                          }).ToList();

            return View(result);
        }

        // GET: Admin/DeThi/Details/5
        public ActionResult Details(string id)
        {
            var model = _deThiRepo.GetDeThiByID(id);
            var tenMon = _monThiRepo.GetMonThiToDropDownList();
            List<string> ListCauHoi = new List<string>();
            int i = 1;

            var result = (from dt in model.Data
                          join m in tenMon on dt.MaMon equals m.MaMon
                          select new DeThiModel
                          {
                              MaDe = dt.MaDe,
                              TenMon = m.TenMon,
                              TacGia = dt.TacGia,
                              ThoiGianLamBai = dt.ThoiGianLamBai,
                              TongCauHoi = dt.TongCauHoi,
                              ChuThich = dt.ChuThich
                          }).FirstOrDefault();

            var listMaCauHoi = model.Data.FirstOrDefault().Cauhoi.Split(',');

            foreach (var item in listMaCauHoi)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    ListCauHoi.Add(i + "/ " + _cauHoiRepo.GetCauHoiByID(item).Data.FirstOrDefault().TenCauHoi);
                    i++;
                }
            }

            ViewBag.ListCauHoi = ListCauHoi;

            return View(result);
        }

        // GET: Admin/DeThi/Create
        public ActionResult Create()
        {
            List<MonModel> listMonThi = _monThiRepo.GetMonThiToDropDownList();
            var monThi = new List<SelectListItem>();

            monThi.AddRange(from a in listMonThi
                            select new SelectListItem
                            {
                                Text = a.TenMon,
                                Value = a.MaMon
                            });

            if (listMonThi.Count != 0)
            {
                ViewBag.MonThi = monThi;
            }

            return View();
        }

        private string RanDomCauHoi(int soLuong, string MaMon)
        {
            string ch = "";

            var cauHoi = _cauHoiRepo.GetAllCauHoi();
            List<CauHoiModel> getCauHoiByMaMon = (from chData in cauHoi.Data
                                                  where chData.MaMon == MaMon
                                                  select new CauHoiModel
                                                  {
                                                      MaCauHoi = chData.MaCauHoi
                                                  }).ToList();

            for (int i = 0; i < soLuong; i++)
            {
                var random = new Random();
                int index = random.Next(getCauHoiByMaMon.Count);

                if (!ch.Contains(getCauHoiByMaMon[index].MaCauHoi))
                {
                    ch += getCauHoiByMaMon[index].MaCauHoi + ",";
                }
            }

            return ch;
        }

        // POST: Admin/DeThi/Create
        [HttpPost]
        public ActionResult Create(DeThiModel deThi)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    deThi.Cauhoi = RanDomCauHoi(deThi.TongCauHoi, deThi.MaMon);

                    if (string.IsNullOrEmpty(deThi.ChuThich))
                    {
                        deThi.ChuThich = "Không có";
                    }

                    var result = _deThiRepo.CreateDeThi(deThi);

                    if (result.CheckStatus())
                    {
                        return RedirectToAction("Index", "DeThi");
                    }


                }
                else
                {
                    ModelState.AddModelError("", "Create Failed");

                    List<MonModel> listMonThi = _monThiRepo.GetMonThiToDropDownList();
                    var monThi = new List<SelectListItem>();

                    monThi.AddRange(from a in listMonThi
                                    select new SelectListItem
                                    {
                                        Text = a.TenMon,
                                        Value = a.MaMon
                                    });

                    if (listMonThi.Count != 0)
                    {
                        ViewBag.MonThi = monThi;
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

        // GET: Admin/DeThi/Edit/5
        public ActionResult Edit(string id)
        {
            var model = _deThiRepo.GetDeThiByID(id);

            List<MonModel> listMonThi = _monThiRepo.GetMonThiToDropDownList();
            var monThi = new List<SelectListItem>();

            monThi.AddRange(from a in listMonThi
                            select new SelectListItem
                            {
                                Text = a.TenMon,
                                Value = a.MaMon,
                                Selected = a.MaMon == model.Data.FirstOrDefault().MaMon
                            });

            if (listMonThi.Count != 0)
            {
                ViewBag.MonThi = monThi;
            }

            return View(model.Data.FirstOrDefault());
        }

        // POST: Admin/DeThi/Edit/5
        [HttpPost]
        public ActionResult Edit(DeThiModel deThiModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (deThiModel.TronDe)
                    {
                        deThiModel.Cauhoi = RanDomCauHoi(deThiModel.TongCauHoi, deThiModel.MaMon);
                    }

                    var result = _deThiRepo.UpdateDeThi(deThiModel);

                    if (result.CheckStatus())
                    {
                        return RedirectToAction("Index");
                    }
                }    
                else
                {
                    var model = _deThiRepo.GetDeThiByID(deThiModel.MaDe);

                    List<MonModel> listMonThi = _monThiRepo.GetMonThiToDropDownList();
                    var monThi = new List<SelectListItem>();

                    monThi.AddRange(from a in listMonThi
                                    select new SelectListItem
                                    {
                                        Text = a.TenMon,
                                        Value = a.MaMon,
                                        Selected = a.MaMon == model.Data.FirstOrDefault().MaMon
                                    });

                    if (listMonThi.Count != 0)
                    {
                        ViewBag.MonThi = monThi;
                    }

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

        // GET: Admin/DeThi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/DeThi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
