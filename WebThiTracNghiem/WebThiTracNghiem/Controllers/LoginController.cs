using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebThiTracNghiem.Areas.Admin.Code;
using WebThiTracNghiem.Areas.Admin.Models;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (Membership.ValidateUser(model.TenTaiKhoan, model.MatKhau) && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.TenTaiKhoan, true);
                var taikhoanRepo = new TaiKhoanRepository();
                var userInfo = taikhoanRepo.getTaiKhoanInfo(model.TenTaiKhoan);
                var userSession = new UserSession();
                userSession.UserName = model.TenTaiKhoan;
                userSession.Quyen = userInfo.Data.Select(m => m.MaQuyen).FirstOrDefault();
                Session.Add(Constance.Constance.USER_SESSION, userSession);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                if (string.IsNullOrEmpty(model.TenTaiKhoan))
                {
                    ModelState.AddModelError("", "Tên đăng nhập không được để trống");
                }

                if (string.IsNullOrEmpty(model.MatKhau))
                {
                    ModelState.AddModelError("", "Mật khẩu không được để trống");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}