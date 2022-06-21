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
    public class DeThiController : ApiController
    {

        private DeThiRepository _deThiRepository;

        public DeThiController()
        {
            _deThiRepository = new DeThiRepository();
        }

        public DeThiResponse GetAllDeThi()
        {
            DeThiResponse deThiResponse = _deThiRepository.GetAllDeThi();
            return deThiResponse;
        }

        public DeThiResponse GetDeThiById(string id)
        {
            DeThiResponse dethiResponse = _deThiRepository.GetDeThiById(id);
            return dethiResponse;
        }

        public DeThiResponse InsertDeThi(DeThiModel dethiModel)
        {
            DeThiResponse dethiResponse = _deThiRepository.InsertDeThi(dethiModel);
            return dethiResponse;
        }

        public DeThiResponse UpdateDeThi(DeThiModel dethiModel)
        {
            DeThiResponse dethiResponse = _deThiRepository.UpdateDeThi(dethiModel);
            return dethiResponse;
        }

        public DeThiResponse DeleteDeThi(string id)
        {
            DeThiResponse dethiResponse = _deThiRepository.DeleteDeThi(id);
            return dethiResponse;
        }
    }
}
