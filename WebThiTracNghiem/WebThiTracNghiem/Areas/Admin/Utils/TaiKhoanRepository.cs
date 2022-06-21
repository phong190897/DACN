using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Models;
using WebThiTracNghiem.Repository;

namespace WebThiTracNghiem.Areas.Admin.Utils
{
    public class TaiKhoanRepository
    {
        public bool login(string userName, string password)
        {
            string jsonObject = JsonConvert.SerializeObject("");

            var apiResponse = CoreRepo.PostToGetApiResponse<TaiKhoanModel>(Constance.Constance.UrlApi, "TaiKhoan/Login?tk=" + userName+"&mk="+password, jsonObject);

            if (apiResponse.Status == (int)HttpStatusCode.NotFound)
                return false;

            return true;
        }

        public ApiResponse<TaiKhoanModel> getTaiKhoanInfo(string userName)
        {
            var apiResponse = CoreRepo.GetApiResponse<TaiKhoanModel>(Constance.Constance.UrlApi, "TaiKhoan/GetTaiKhoanById/" + userName);

            if (apiResponse.Status == (int)HttpStatusCode.NotFound)
                return apiResponse;

            return apiResponse;
        }

        public ApiResponse<TaiKhoanModel> InsertTaiKhoan(TaiKhoanModel taiKhoanModel)
        {
            string jsonObject = JsonConvert.SerializeObject(taiKhoanModel);

            var apiResponse = CoreRepo.PostToGetApiResponse<TaiKhoanModel>(Constance.Constance.UrlApi, "TaiKhoan/InsertTaiKhoan/", jsonObject);

            if (apiResponse.Status == (int)HttpStatusCode.NotFound)
                return apiResponse;

            return apiResponse;
        }
            
        public ApiResponse<TaiKhoanModel> GetAllTaiKhoan()
        {
            var apiResponse = CoreRepo.GetApiResponse<TaiKhoanModel>(Constance.Constance.UrlApi, "TaiKhoan/GetAllTaiKhoan/");

            if (apiResponse.Status == (int)HttpStatusCode.NotFound)
                return apiResponse;

            return apiResponse;
        }

        public ApiResponse<TaiKhoanModel> UpdateTaiKhoan(TaiKhoanModel taiKhoanModel)
        {
            string jsonObject = JsonConvert.SerializeObject(taiKhoanModel);

            var apiResponse = CoreRepo.PostToGetApiResponse<TaiKhoanModel>(Constance.Constance.UrlApi, "TaiKhoan/UpdateTaiKhoan/", jsonObject);

            if (apiResponse.Status == (int)HttpStatusCode.NotFound)
                return apiResponse;

            return apiResponse;
        }

        public ApiResponse<TaiKhoanModel> DeleteTaiKhoan(string Id)
        {
            var list = CoreRepo.DeleteToGetApiResponse<TaiKhoanModel>(Constance.Constance.UrlApi, "TaiKhoan/DeleteTaiKhoan/" + Id);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }
    }
}