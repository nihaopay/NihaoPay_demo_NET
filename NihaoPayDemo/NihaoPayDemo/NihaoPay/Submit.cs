using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace NihaoPayDemo.NihaoPay
{
    public class Submit
    {
         private static string _token = "";
        static Submit()
        {
            _token = "Bearer " + Config.API_TOKEN;
        }

        public static string submit(string ApiURL, Dictionary<string,object> param,Method httpMethod)
        {
            RestClient client = new RestClient(ApiURL);
            RestRequest request = new RestRequest(httpMethod);
            request.AddHeader("authorization", _token);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");
            foreach(KeyValuePair<string,object> temp in param)
            {
                request.AddParameter(temp.Key, temp.Value);
            }
            IRestResponse resp = client.Execute(request);
            return resp.Content;

        }
    }
}