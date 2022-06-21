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
    public class BaiThiRepository
    {
        public ApiResponse<BaiThiModel> GetAllBaiThi()
        {
            var list = CoreRepo.GetApiResponse<BaiThiModel>(Constance.Constance.UrlApi, "BaiThi/GetAllBaiThi/");

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<BaiThiModel> CreateBaiThi(BaiThiModel baiThiModel)
        {
            string jsonObject = JsonConvert.SerializeObject(baiThiModel);

            var list = CoreRepo.PostToGetApiResponse<BaiThiModel>(Constance.Constance.UrlApi, "BaiThi/InsertBaiThi/", jsonObject);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<BaiThiModel> GetBaiThiByID(string ID)
        {
            var list = CoreRepo.GetApiResponse<BaiThiModel>(Constance.Constance.UrlApi, "BaiThi/GetBaiThiById/" + ID);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<BaiThiModel> UpdateBaiThi(BaiThiModel baiThiModel)
        {
            string jsonObject = JsonConvert.SerializeObject(baiThiModel);

            var list = CoreRepo.PostToGetApiResponse<BaiThiModel>(Constance.Constance.UrlApi, "BaiThi/UpdateBaiThi/", jsonObject);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<BaiThiModel> DeleteBaiThi(string Id)
        {

            var list = CoreRepo.DeleteToGetApiResponse<BaiThiModel>(Constance.Constance.UrlApi, "BaiThi/DeleteBaiThi/" + Id);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }
    }
}