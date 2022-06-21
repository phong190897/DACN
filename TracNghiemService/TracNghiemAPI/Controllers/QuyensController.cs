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
    public class QuyensController : ApiController
    {
        private QuyenRepository _quyenRepository;

        public QuyensController()
        {
            _quyenRepository = new QuyenRepository();
        }
        public QuyenResponse GetAllQuyen()
        {
            QuyenResponse quyenResponse = _quyenRepository.GetAllQuyen();
            return quyenResponse;
        }

        public QuyenResponse GetQuyenById(string id)
        {
            QuyenResponse quyenResponse = _quyenRepository.GetQuyenById(id);
            return quyenResponse;
        }

        public QuyenResponse InsertQuyen(QuyenModel quyenModel)
        {
            QuyenResponse quyenResponse = _quyenRepository.InsertQuyen(quyenModel);
            return quyenResponse;
        }

        public QuyenResponse UpdateQuyen(QuyenModel quyenModel)
        {
            QuyenResponse quyenResponse = _quyenRepository.UpdateQuyen(quyenModel);
            return quyenResponse;
        }

        public QuyenResponse DeleteQuyen(string id)
        {
            QuyenResponse quyenResponse = _quyenRepository.DeleteQuyen(id);
            return quyenResponse;
        }
    }
}
