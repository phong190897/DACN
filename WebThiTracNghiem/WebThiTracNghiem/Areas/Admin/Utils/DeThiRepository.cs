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
    public class DeThiRepository
    {
        public ApiResponse<DeThiModel> GetAllDeThi()
        {
            var list = CoreRepo.GetApiResponse<DeThiModel>(Constance.Constance.UrlApi, "DeThi/GetAllDeThi/");

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<DeThiModel> CreateDeThi(DeThiModel deThiModel)
        {
            string jsonObject = JsonConvert.SerializeObject(deThiModel);

            var list = CoreRepo.PostToGetApiResponse<DeThiModel>(Constance.Constance.UrlApi, "DeThi/InsertDeThi/", jsonObject);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<DeThiModel> GetDeThiByID(string ID)
        {
            var list = CoreRepo.GetApiResponse<DeThiModel>(Constance.Constance.UrlApi, "DeThi/GetDeThiById/" + ID);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<DeThiModel> UpdateDeThi(DeThiModel deThiModel)
        {
            string jsonObject = JsonConvert.SerializeObject(deThiModel);

            var list = CoreRepo.PostToGetApiResponse<DeThiModel>(Constance.Constance.UrlApi, "DeThi/UpdateDeThi/", jsonObject);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<DeThiModel> DeleteDeThi(string Id)
        {

            var list = CoreRepo.DeleteToGetApiResponse<DeThiModel>(Constance.Constance.UrlApi, "DeThi/DeleteDeThi/" + Id);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }
    }
}