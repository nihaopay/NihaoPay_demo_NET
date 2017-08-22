using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NihaoPayDemo.NihaoPay
{
    public class Config
    {
        //NihaoPay SecurePay api url
        //public static string SECUREPAY_URL = "https://api.nihaopay.com/v1.2/transactions/securepay"; //production
        public static string SECUREPAY_URL = "https://apitest.nihaopay.com/v1.2/transactions/securepay";//test

        // ExpressPay api url
        //public static string EXPRESSPAY_URL = "https://api.nihaopay.com/v1.2/transactions/expresspay";// production
        public static string EXPRESSPAY_URL = "https://apitest.nihaopay.com/v1.2/transactions/expresspay";//test


        /// <summary>
        /// NihaoPay生成的唯一token，可以在NihaoPay商户后台下载
        /// </summary>
        public static string API_TOKEN = "4847fed22494dc22b1b1a478b34e374e0b429608f31adf289704b4ea093e60a8";

        /// <summary>
        /// 支付完成后页面同步返回的路径，需要http://格式的完成路径，且外网可以正常访问
        /// </summary>
        public static string callback_url = "http://localhost:1620/callback.aspx";
        /// <summary>
        /// 服务器异步通知页面路径，需要http://格式的完成路径，且外网可以正常访问
        /// </summary>
        public static string ipn_url = "http://yourdomain.com/ipn.aspx";
    }
}