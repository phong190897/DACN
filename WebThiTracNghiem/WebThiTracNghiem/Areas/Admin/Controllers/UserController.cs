using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        TaiKhoanRepository _taiKhoanRepository = new TaiKhoanRepository();
        QuyenRepository quyenRepository = new QuyenRepository();

        public ActionResult Index()
        {
            var model = _taiKhoanRepository.GetAllTaiKhoan();
            var quyen = quyenRepository.GetAllQuyen();

            var query = from tk in model.Data
                        join q in quyen.Data on tk.MaQuyen equals q.MaQuyen
                        select new TaiKhoanModel
                        {
                            TenTaiKhoan = tk.TenTaiKhoan,
                            Matkhau = tk.Matkhau,
                            TenQuyen = q.TenQuyen,
                            HoTen = tk.HoTen,
                            GioiTinh = tk.GioiTinh,
                            NgaySinh = tk.NgaySinh,
                            DiaChi = tk.DiaChi
                        };

            return View(query);
        }

        [HttpGet]
        public ActionResult Create()
        {

            List<QuyenModel> listQuyen = quyenRepository.GetQuyenToDropDownList();
            List<SelectListItem> quyen = new List<SelectListItem>();

            quyen.AddRange(from a in listQuyen
                           select new SelectListItem
                           {
                               Text = a.TenQuyen,
                               Value = a.MaQuyen
                           });
            if (listQuyen.Count != 0)
            {
                ViewBag.Quyen = quyen;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaiKhoanModel taiKhoanModel)
        {
            if (ModelState.IsValid)
            {
                var createTaiKhoan = _taiKhoanRepository.InsertTaiKhoan(taiKhoanModel);

                if (createTaiKhoan.CheckStatus())
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo tài khoản không thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(string Id)
        {
            var model = _taiKhoanRepository.getTaiKhoanInfo(Id);
            List<QuyenModel> listQuyen = quyenRepository.GetQuyenToDropDownList();
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

            var query = (from tk in model.Data
                        join q in listQuyen on tk.MaQuyen equals q.MaQuyen
                        select new TaiKhoanModel
                        {
                            TenTaiKhoan = tk.TenTaiKhoan,
                            Matkhau = tk.Matkhau,
                            TenQuyen = q.TenQuyen,
                            HoTen = tk.HoTen,
                            GioiTinh = tk.GioiTinh,
                            NgaySinh = tk.NgaySinh,
                            DiaChi = tk.DiaChi
                        }).FirstOrDefault();

            return View(query);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaiKhoanModel taiKhoanModel)
        {
            try
            {
                // TODO: Add update logic here
                var model = _taiKhoanRepository.UpdateTaiKhoan(taiKhoanModel);

                return RedirectToAction("Index");
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
                var model = _taiKhoanRepository.DeleteTaiKhoan(id);
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

        public ActionResult Details(string Id)
        {
            var model = _taiKhoanRepository.getTaiKhoanInfo(Id);
            var quyen = quyenRepository.GetAllQuyen();

            List<QuyenModel> listQuyen = quyenRepository.GetQuyenToDropDownList();
            List<SelectListItem> quyenVB = new List<SelectListItem>();

            quyenVB.AddRange(from a in listQuyen
                           select new SelectListItem
                           {
                               Text = a.TenQuyen,
                               Value = a.MaQuyen,
                               Selected = a.MaQuyen == model.Data.FirstOrDefault().MaQuyen
                               
                           });
            if (listQuyen.Count != 0)
            {
                ViewBag.Quyen = quyenVB;
            }

            var query = (from tk in model.Data
                        join q in quyen.Data on tk.MaQuyen equals q.MaQuyen
                        select new TaiKhoanModel
                        {
                            TenTaiKhoan = tk.TenTaiKhoan,
                            Matkhau = tk.Matkhau,
                            TenQuyen = q.TenQuyen,
                            HoTen = tk.HoTen,
                            GioiTinh = tk.GioiTinh,
                            NgaySinh = tk.NgaySinh,
                            DiaChi = tk.DiaChi
                        }).FirstOrDefault();

            return View(query);
        }
    }
}