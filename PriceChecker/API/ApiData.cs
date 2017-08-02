using System;
using System.Net;
using Newtonsoft.Json;

namespace PriceChecker.API
{
    class ApiData
    {
        public static T GetJsonData<T>(string url) where T : new()
        {
            using (var client = new WebClient())
            {
                var json_data = string.Empty;
                
                try
                {
                    json_data = client.DownloadString(url);
                }
                catch (Exception) { }
                
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
}
