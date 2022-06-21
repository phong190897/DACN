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
    public class CauHoiController : ApiController
    {
        private CauHoiRepository _cauHoiRepository;

        public CauHoiController()
        {
            _cauHoiRepository = new CauHoiRepository();
        }

        public CauHoiResponse GetAllCauHoi()
        {
            CauHoiResponse cauHoiResponse = _cauHoiRepository.GetAllCauHoi();
            return cauHoiResponse;
        }

        public CauHoiResponse GetCauHoiById(string id)
        {
            CauHoiResponse cauHoiResponse = _cauHoiRepository.GetCauHoiById(id);
            return cauHoiResponse;
        }

        public CauHoiResponse InsertCauHoi(CauHoiModel cauHoiModel)
        {
            CauHoiResponse cauHoiResponse = _cauHoiRepository.InsertCauHoi(cauHoiModel);
            return cauHoiResponse;
        }

        public CauHoiResponse UpdateCauHoi(CauHoiModel cauHoiModel)
        {
            CauHoiResponse cauHoiResponse = _cauHoiRepository.UpdateCauHoi(cauHoiModel);
            return cauHoiResponse;
        }

        public CauHoiResponse DeleteCauHoi(string id)
        {
            CauHoiResponse cauHoiResponse = _cauHoiRepository.DeleteCauHoi(id);
            return cauHoiResponse;
        }
    }
}
