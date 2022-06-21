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
    public class LoaiCauHoiController : ApiController

    {
        private LoaiCauHoiRepository _loaiCauHoiRepository;

        public LoaiCauHoiController()
        {
            _loaiCauHoiRepository = new LoaiCauHoiRepository();
        }

        public LoaiCauHoiResponse GetAllLoaiCauHoi()
        {
            LoaiCauHoiResponse loaiCauHoiResponse = _loaiCauHoiRepository.GetAllLoaiCauHoi();
            return loaiCauHoiResponse;
        }

        public LoaiCauHoiResponse GetLoaiCauHoiById(string id)
        {
            LoaiCauHoiResponse loaiCauHoiResponse = _loaiCauHoiRepository.GetLoaiCauHoiById(id);
            return loaiCauHoiResponse;
        }

        public LoaiCauHoiResponse InsertLoaiCauHoi(LoaiCauHoiModel loaicauhoi)
        {
            LoaiCauHoiResponse loaiCauHoiResponse = _loaiCauHoiRepository.InsertLoaiCauHoi(loaicauhoi);
            return loaiCauHoiResponse;
        }

        public LoaiCauHoiResponse UpdateLoaiCauHoi(LoaiCauHoiModel loaicauhoi)
        {
            LoaiCauHoiResponse loaiCauHoiResponse = _loaiCauHoiRepository.UpdateLoaiCauHoi(loaicauhoi);
            return loaiCauHoiResponse;
        }

        public LoaiCauHoiResponse DeleteLoaiCauHoi(string id)
        {
            LoaiCauHoiResponse loaiCauHoiResponse = _loaiCauHoiRepository.DeleteLoaiCauHoi(id);
            return loaiCauHoiResponse;
        }


    }
}
