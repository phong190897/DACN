using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Models;
using WebThiTracNghiem.Repository;

namespace WebThiTracNghiem.Areas.Admin.Utils
{
    public class QuyenRepository
    {

        public ApiResponse<QuyenModel> GetAllQuyen()
        {
            var list = CoreRepo.GetApiResponse<QuyenModel>(Constance.Constance.UrlApi, "Quyens/GetAllQuyen/");

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<QuyenModel> GetQuyenById(string Id)
        {
            var list = CoreRepo.GetApiResponse<QuyenModel>(Constance.Constance.UrlApi, "Quyens/GetQuyenById/" + Id);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public List<QuyenModel> GetQuyenToDropDownList()
        {
            var list = CoreRepo.GetApiResponse<QuyenModel>(Constance.Constance.UrlApi, "Quyens/GetAllQuyen/");

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list.Data;

            return list.Data;
        }

        public ApiResponse<QuyenModel> CreateQuyen(QuyenModel quyenModel)
        {
            string jsonObject = JsonConvert.SerializeObject(quyenModel);

            var list = CoreRepo.PostToGetApiResponse<QuyenModel>(Constance.Constance.UrlApi, "Quyens/InsertQuyen/", jsonObject);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<QuyenModel> UpdateQuyen(QuyenModel quyenModel)
        {
            string jsonObject = JsonConvert.SerializeObject(quyenModel);

            var list = CoreRepo.PostToGetApiResponse<QuyenModel>(Constance.Constance.UrlApi, "Quyens/UpdateQuyen/", jsonObject);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<QuyenModel> DeleteQuyen(string Id)
        {
            string jsonObject = JsonConvert.SerializeObject("");

            var list = CoreRepo.DeleteToGetApiResponse<QuyenModel>(Constance.Constance.UrlApi, "Quyens/DeleteQuyen/" + Id);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }
    }
}