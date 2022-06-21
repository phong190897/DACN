using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using WebThiTracNghiem.Models;

namespace WebThiTracNghiem.Repository
{
    public class CoreRepo
    {

        // Get ApiResponse
        public static ApiResponse<T> GetApiResponse<T>(string uri, string api)
        {
            var res = _GetApiResponse<T>(uri, api);
            return res;
        }

        private static ApiResponse<T> _GetApiResponse<T>(string uri, string api)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            HttpResponseMessage respone = client.GetAsync(api).Result;
            var json = respone.Content.ReadAsStringAsync();

            ApiResponse<T> jsonResult = JsonConvert.DeserializeObject<ApiResponse<T>>(json.Result);


            return jsonResult;
        }

        // Post to get ApiResponse
        public static ApiResponse<T> PostToGetApiResponse<T>(string uri, string api, string jsonObject)
        {
            var res = _PostToGetApiResponse<T>(uri, api, jsonObject);
            return res;
        }

        private static ApiResponse<T> _PostToGetApiResponse<T>(string uri, string api, string jsonObject)
        {

            System.Net.ServicePointManager.Expect100Continue = false;
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);

            HttpResponseMessage respone = client.PostAsync(api, content).Result;
            var json = respone.Content.ReadAsStringAsync();

            ApiResponse<T> jsonResult = JsonConvert.DeserializeObject<ApiResponse<T>>(json.Result);

            return jsonResult;
        }

        // Put to get ApiResponse
        public static ApiResponse<T> PutToGetApiResponse<T>(string uri, string api, string jsonObject)
        {
            var res = _PutToGetApiResponse<T>(uri, api, jsonObject);
            return res;
        }

        private static ApiResponse<T> _PutToGetApiResponse<T>(string uri, string api, string jsonObject)
        {

            System.Net.ServicePointManager.Expect100Continue = false;
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);


            HttpResponseMessage respone = client.PutAsync(api, content).Result;
            var json = respone.Content.ReadAsStringAsync();

            ApiResponse<T> jsonResult = JsonConvert.DeserializeObject<ApiResponse<T>>(json.Result);

            return jsonResult;
        }


        public static ApiResponse<T> DeleteToGetApiResponse<T>(string uri, string api)
        {
            var res = _DeleteToGetApiResponse<T>(uri, api);
            return res;
        }

        private static ApiResponse<T> _DeleteToGetApiResponse<T>(string uri, string api)
        {
            System.Net.ServicePointManager.Expect100Continue = false;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);


            HttpResponseMessage respone = client.DeleteAsync(api).Result;
            var json = respone.Content.ReadAsStringAsync();

            ApiResponse<T> jsonResult = JsonConvert.DeserializeObject<ApiResponse<T>>(json.Result);

            return jsonResult;
        }    
    }
}
