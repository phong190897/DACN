using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using TracNghiemAPI.Models;
using TracNghiemAPI.Models.ViewModels;
using TracNghiemAPI.Repositories;
using TracNghiemAPI.Repository;

namespace TracNghiemAPI.Controllers
{
    public class TaiKhoanController : ApiController
    {
        private TaiKhoanRepository _taiKhoanRepository;

        public TaiKhoanController()
        {
            _taiKhoanRepository = new TaiKhoanRepository();
        }

        public TaiKhoanResponse GetAllTaiKhoan()
        {
            TaiKhoanResponse taiKhoanResponse = _taiKhoanRepository.GetAllTaiKhoan();
            return taiKhoanResponse;
        }

        public TaiKhoanResponse GetTaiKhoanById(string id)
        {
            TaiKhoanResponse taiKhoanResponse = _taiKhoanRepository.GetTaiKhoanById(id);
            return taiKhoanResponse;
        }

        public TaiKhoanResponse InsertTaiKhoan(TaiKhoanModel taiKhoanModel)
        {
            TaiKhoanResponse taiKhoanResponse = _taiKhoanRepository.InsertTaiKhoan(taiKhoanModel);
            return taiKhoanResponse;
        }

        public TaiKhoanResponse UpdateTaiKhoan(TaiKhoanModel taiKhoanModel)
        {
            TaiKhoanResponse taiKhoanResponse = _taiKhoanRepository.UpdateTaiKhoan(taiKhoanModel);
            return taiKhoanResponse;
        }

        public TaiKhoanResponse DeleteTaiKhoan(string id)
        {
            TaiKhoanResponse taiKhoanResponse = _taiKhoanRepository.DeleteTaiKhoan(id);
            return taiKhoanResponse;
        }

        public TaiKhoanResponse Login(string Tk, string Mk)
        {
            TaiKhoanResponse taiKhoanResponse = _taiKhoanRepository.Login(Tk,Mk);
            return taiKhoanResponse;
        }
    }
}
