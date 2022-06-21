using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Code;
using WebThiTracNghiem.Areas.Admin.Controllers;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        MonRepository _monThiRepo = new MonRepository();
        DeThiRepository _deThiRepo = new DeThiRepository();
        CauHoiRepository _cauHoiRepo = new CauHoiRepository();
        BaiThiRepository _baiThiRepo = new BaiThiRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThiThu()
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

        public ActionResult ThongTinBaiThi(FormCollection MaMon)
        {
            string mon = MaMon["MaMon"];

            if (!string.IsNullOrEmpty(mon))
            {
                var DeThi = _deThiRepo.GetAllDeThi().Data.Where(m => m.MaMon == mon).ToList();
                var tenMonThi = _monThiRepo.GetMonThiById(mon).Data.FirstOrDefault();

                ViewBag.MonThi = tenMonThi.TenMon;

                return View(DeThi);
            }


            return View();
        }

        public ActionResult LamBaiThi(string ID)
        {
            var model = _deThiRepo.GetDeThiByID(ID);
            ViewBag.MonThi = _monThiRepo.GetMonThiById(model.Data.FirstOrDefault().MaMon).Data.FirstOrDefault().TenMon;

            return View(model.Data.FirstOrDefault());
        }

        public ActionResult BatDau(string ID)
        {
            var model = _deThiRepo.GetDeThiByID(ID).Data.FirstOrDefault();
            List<CauHoiModel> ListCauHoi = new List<CauHoiModel>();
            int i = 1;

            ViewBag.Time = model.ThoiGianLamBai;
            ViewBag.MaDe = model.MaDe;

            if (!string.IsNullOrEmpty(model.Cauhoi))
            {
                var listMaCauHoi = model.Cauhoi.Split(',');

                foreach (var item in listMaCauHoi)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        var cauHoi = _cauHoiRepo.GetCauHoiByID(item).Data.FirstOrDefault();
                        ListCauHoi.Add(new CauHoiModel
                        {
                            MaCauHoi = cauHoi.MaCauHoi,
                            TenCauHoi = i + "/ " + cauHoi.TenCauHoi,
                            A = cauHoi.A,
                            B = cauHoi.B,
                            C = cauHoi.C,
                            D = cauHoi.D,
                            DapAn = cauHoi.DapAn
                        });
                        i++;
                    }
                }
            }

            return View(ListCauHoi);
        }

        public ActionResult NopBai(FormCollection form)
        {
            string maDe = form.Keys[0];
            DateTime ThoiGianKetThuc = DateTime.Now;
            DateTime ThoiGianBatDau = DateTime.Parse(form.Keys[2]);
            TimeSpan ThoiGianLamBai;
            int diem = 0;
            int soCauDung = 0;
            List<CauHoiModel> ListCauHoi = new List<CauHoiModel>();
            KetQuaBaiThiModel kqBaiThi = new KetQuaBaiThiModel();
            BaiThiModel baiThi = new BaiThiModel();
            string cauTraLoi = "";

            if (!string.IsNullOrEmpty(maDe))
            {
                var model = _deThiRepo.GetDeThiByID(maDe).Data.FirstOrDefault();

                ViewBag.MonThi = _monThiRepo.GetMonThiById(model.MaMon).Data.FirstOrDefault().TenMon;

                if (!string.IsNullOrEmpty(model.Cauhoi))
                {
                    var listMaCauHoi = model.Cauhoi.Split(',');

                    foreach (var item in listMaCauHoi)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            var cauHoi = _cauHoiRepo.GetCauHoiByID(item).Data.FirstOrDefault();
                            ListCauHoi.Add(new CauHoiModel
                            {
                                MaCauHoi = cauHoi.MaCauHoi,
                                TenCauHoi = cauHoi.TenCauHoi,
                                A = cauHoi.A,
                                B = cauHoi.B,
                                C = cauHoi.C,
                                D = cauHoi.D,
                                DapAn = cauHoi.DapAn
                            });
                        }
                    }
                }

                foreach (var item in form.AllKeys)
                {
                    if (item.Contains("answer_"))
                    {
                        string UserAnswer = form[item];
                        string[] maCauHoi = item.Split('_');
                        string[] dapAnChu = UserAnswer.Split('_');

                        if (ListCauHoi.Where(m => m.MaCauHoi == maCauHoi[1]).Select(da => da.DapAn).Contains(dapAnChu[1]))
                        {
                            soCauDung++;
                            diem++;
                        }
                        ListCauHoi.Where(m => m.MaCauHoi == maCauHoi[1]).FirstOrDefault().DapAnChu = dapAnChu[0];
                        string dapAnKoDau = dapAnChu[1].Replace(",", "*");
                        cauTraLoi += maCauHoi[1] + "_" + dapAnKoDau + ",";
                    }
                }

                ThoiGianLamBai = ThoiGianKetThuc - ThoiGianBatDau;

                kqBaiThi.MaDe = maDe;
                if (ThoiGianLamBai.TotalMinutes < 1)
                    kqBaiThi.ThoiGianLamBai = 1;
                else
                {
                    kqBaiThi.ThoiGianLamBai = int.Parse(ThoiGianLamBai.TotalMinutes.ToString());
                }
                kqBaiThi.SoCauDung = soCauDung;
                kqBaiThi.Diem = diem;
                kqBaiThi.TongSoCau = ListCauHoi.Count();
                kqBaiThi.CauHois = ListCauHoi;

                baiThi.MaBaiThi = Guid.NewGuid().ToString().Substring(0, 8);
                UserSession session = (UserSession)HttpContext.Session["USER_SESSION"];
                baiThi.TaiKhoan = session.UserName;
                baiThi.MaDe = model.MaDe;
                baiThi.ThoiGianHoanThanh = Convert.ToInt32(Math.Round(ThoiGianLamBai.TotalMinutes, 0, MidpointRounding.AwayFromZero));
                baiThi.SoCauDung = soCauDung.ToString();
                baiThi.Diem = diem;
                baiThi.CauTraLoi = cauTraLoi;
                baiThi.NgayThi = DateTime.Now;
                baiThi.TongSoCau = ListCauHoi.Count();

                var createBaiThi = _baiThiRepo.CreateBaiThi(baiThi);
            }

            return View(kqBaiThi);
        }

        public ActionResult BaiThi()
        {
            var model = _baiThiRepo.GetAllBaiThi().Data;

            UserSession session = (UserSession)HttpContext.Session["USER_SESSION"];

            var BaiThi = model.Where(m => m.TaiKhoan == session.UserName).ToList();

            foreach (var item in BaiThi)
            {
                var DeThi = _deThiRepo.GetDeThiByID(item.MaDe).Data.FirstOrDefault();
                item.TongSoCau = DeThi.TongCauHoi;
                int count = 0;
                double diem = 0;

                if (!String.IsNullOrEmpty(DeThi.Cauhoi))
                {
                    var listMaCauHoi = DeThi.Cauhoi.Split(',');

                    foreach (var ch in listMaCauHoi)
                    {
                        if (!string.IsNullOrEmpty(ch))
                        {
                            var cauHoi = _cauHoiRepo.GetCauHoiByID(ch).Data.FirstOrDefault();
                            if (cauHoi != null)
                            {
                                count++;
                            }
                        }
                    }
                    diem = (double.Parse(item.SoCauDung) / (double)count) * 10;
                    item.Diem10 = Math.Round(diem, 1, MidpointRounding.AwayFromZero);
                }
            }

            return View(BaiThi);
        }

        public ActionResult ChiTietBaiThi(string id)
        {
            var BaiThi = _baiThiRepo.GetBaiThiByID(id).Data.FirstOrDefault();
            var DeThi = _deThiRepo.GetDeThiByID(BaiThi.MaDe).Data.FirstOrDefault();
            DetailsBaiThiViewModel detailBaiThi = new DetailsBaiThiViewModel();
            List<CauHoiModel> lstCauHoi = new List<CauHoiModel>();

            detailBaiThi.DeThi = DeThi;
            detailBaiThi.BaiThi = BaiThi;

            if (!String.IsNullOrEmpty(DeThi.Cauhoi))
            {

                var DapAn = BaiThi.CauTraLoi.Split(',');

                foreach (var item in DapAn)
                {
                    var UserAns = item.Split('_');
                    if (!String.IsNullOrEmpty(UserAns[0]))
                    {
                        var cauHoi = _cauHoiRepo.GetCauHoiByID(UserAns[0]).Data.FirstOrDefault();
                        string usrAnsChangeSymbol = UserAns[1].Replace("*", ",");
                        if (cauHoi.A.Contains(usrAnsChangeSymbol))
                        {
                            cauHoi.DapAnChu = "A";
                        }
                        else if (cauHoi.B.Contains(usrAnsChangeSymbol))
                        {
                            cauHoi.DapAnChu = "B";
                        }
                        else if (cauHoi.C.Contains(usrAnsChangeSymbol))
                        {
                            cauHoi.DapAnChu = "C";
                        }
                        else if (cauHoi.D.Contains(usrAnsChangeSymbol))
                        {
                            cauHoi.DapAnChu = "D";
                        }
                        lstCauHoi.Add(cauHoi);
                    }
                }
                detailBaiThi.CauHois = lstCauHoi;
                detailBaiThi.BaiThi.Diem10 = Math.Round((double.Parse(detailBaiThi.BaiThi.SoCauDung)/lstCauHoi.Count)*10, 1, MidpointRounding.AwayFromZero);
            }

            return View(detailBaiThi);
        }
    }
}