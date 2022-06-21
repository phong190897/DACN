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
    public class LoaiCauHoiRepository
    {
        public List<LoaiCauHoiModel> GetLoaiCauHoiToDropDownList()
        {
            var list = CoreRepo.GetApiResponse<LoaiCauHoiModel>(Constance.Constance.UrlApi, "LoaiCauHoi/GetAllLoaiCauHoi/");

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list.Data;

            return list.Data;
        }

        public ApiResponse<LoaiCauHoiModel> GetLoaiCauHoiById(string Id)
        {
            var list = CoreRepo.GetApiResponse<LoaiCauHoiModel>(Constance.Constance.UrlApi, "LoaiCauHoi/GetLoaiCauHoiById/" + Id);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<LoaiCauHoiModel> CreateLoaiCauHoi(LoaiCauHoiModel loaiCauHoiModel)
        {
            string jsonObject = JsonConvert.SerializeObject(loaiCauHoiModel);

            var list = CoreRepo.PostToGetApiResponse<LoaiCauHoiModel>(Constance.Constance.UrlApi, "LoaiCauHoi/InsertLoaiCauHoi/", jsonObject);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<LoaiCauHoiModel> UpdateLoaiCauHoi(LoaiCauHoiModel loaiCauHoiModel)
        {
            string jsonObject = JsonConvert.SerializeObject(loaiCauHoiModel);

            var list = CoreRepo.PostToGetApiResponse<LoaiCauHoiModel>(Constance.Constance.UrlApi, "LoaiCauHoi/UpdateLoaiCauHoi/", jsonObject);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<LoaiCauHoiModel> DeleteLoaiCauHoi(string id)
        {
            var list = CoreRepo.DeleteToGetApiResponse<LoaiCauHoiModel>(Constance.Constance.UrlApi, "LoaiCauHoi/DeleteLoaiCauHoi/" + id);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }
    }
}