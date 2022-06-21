using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using TracNghiemAPI.Models;
using TracNghiemAPI.Models.ViewModels;
using TracNghiemAPI.Repository;

namespace TracNghiemAPI.Controllers
{
    public class BaiThiController : ApiController
    {
        private BaiThiRepository _baithiRepository;

        public BaiThiController()
        {
            _baithiRepository = new BaiThiRepository();
        }

        public BaiThiResponse GetAllBaiThi()
        {
            BaiThiResponse baiThiResponse = _baithiRepository.GetAllBaiThi();
            return baiThiResponse;
        }

        public BaiThiResponse GetBaiThiById(string id)
        {
            BaiThiResponse baiThiResponse = _baithiRepository.GetBaiThiById(id);
            return baiThiResponse;
        }

        public BaiThiResponse InsertBaiThi(BaiThiModel baiThiModel)
        {
            BaiThiResponse baiThiResponse = _baithiRepository.InsertBaiThi(baiThiModel);
            return baiThiResponse;
        }

        public BaiThiResponse UpdateBaiThi(BaiThiModel baiThiModel)
        {
            BaiThiResponse baiThiResponse = _baithiRepository.UpdateBaiThi(baiThiModel);
            return baiThiResponse;
        }

        public BaiThiResponse DeleteBaiThi(string id)
        {
            BaiThiResponse baiThiResponse = _baithiRepository.DeleteBaiThi(id);
            return baiThiResponse;
        }

        public BaiThiResponse GetAllBaiThiByTaiKhoan(string TaiKhoan)
        {
            BaiThiResponse baiThiResponse = _baithiRepository.GetAllBaiThiByTaiKhoan(TaiKhoan);
            return baiThiResponse;
        }

    }
}
