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
    public class MonThiController : ApiController
    {
        private MonThiRepository _monThiRepository;

        public MonThiController()
        {
            _monThiRepository = new MonThiRepository();
        }

        public MonThiResponse GetAllMonThi()
        {
            MonThiResponse monThiResponse = _monThiRepository.GetAllMonThi();
            return monThiResponse;
        }

        public MonThiResponse GetMonThiById(string id)
        {
            MonThiResponse monthiResponse = _monThiRepository.GetMonThiById(id);
            return monthiResponse;
        }

        public MonThiResponse InsertMonThi(MonThiModel monthiModel)
        {
            MonThiResponse monThiResponse = _monThiRepository.InsertMonThi(monthiModel);
            return monThiResponse;
        }

        public MonThiResponse updateMonThi(MonThiModel monThiModel)
        {
            MonThiResponse monThiResponse = _monThiRepository.UpdateMonThi(monThiModel);
            return monThiResponse;
        }

        public MonThiResponse DeleteMonThi(string id)
        {
            MonThiResponse monThiResponse = _monThiRepository.DeleteMonThi(id);
            return monThiResponse;
        }

    }
}
