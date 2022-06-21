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
    public class MonRepository
    {
        public List<MonModel> GetMonThiToDropDownList()
        {
            var list = CoreRepo.GetApiResponse<MonModel>(Constance.Constance.UrlApi, "MonThi/GetAllMonThi/");

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list.Data;

            return list.Data;
        }

        public ApiResponse<MonModel> GetMonThiById(string id)
        {
            var list = CoreRepo.GetApiResponse<MonModel>(Constance.Constance.UrlApi, "MonThi/GetMonThiById/" + id);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<MonModel> CreateMonThi(MonModel monModel)
        {
            string jsonObject = JsonConvert.SerializeObject(monModel);

            var list = CoreRepo.PostToGetApiResponse<MonModel>(Constance.Constance.UrlApi, "MonThi/InsertMonThi/", jsonObject);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<MonModel> UpdateMonThi(MonModel monModel)
        {
            string jsonObject = JsonConvert.SerializeObject(monModel);

            var list = CoreRepo.PostToGetApiResponse<MonModel>(Constance.Constance.UrlApi, "MonThi/updateMonThi/", jsonObject);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<MonModel> DeleteMonThi(string id)
        {
            var list = CoreRepo.DeleteToGetApiResponse<MonModel>(Constance.Constance.UrlApi, "MonThi/DeleteMonThi/" + id);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }
    }
}