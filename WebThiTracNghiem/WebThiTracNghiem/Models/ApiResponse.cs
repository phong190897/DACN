using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThiTracNghiem.Models
{
    public class ApiResponse<T>
    {
        [JsonProperty(PropertyName = "StatusCode")]
        public int Status { get; set; }

        // message
        [JsonProperty(PropertyName = "Message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        // list
        [JsonProperty(PropertyName = "Data", NullValueHandling = NullValueHandling.Ignore)]
        public List<T> Data { get; set; }

        public bool CheckStatus()
        {
            if (Status == 200 || Status == 201)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CheckLogin()
        {
            int a = 0;
            if (Status == 0)
                a = 0;
            else if (Status == 401)
                a = 401;
            else if (Status == 417)
                a = 417;
            return a;
        }
    }
}
