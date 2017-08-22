using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace NihaoPayDemo.NihaoPay
{
    public class Utils
    {
        public static int GetSubmitAmount(string amount,string currency)
        {
            switch (currency.ToUpper())
            {
                case "JPY":
                    return Convert.ToInt32(amount);
                case "USD":
                case "GBP":
                case "CAD":
                case "EUR":
                case "HKD":
                case "CNY":
                    return Convert.ToInt32(Convert.ToDecimal(amount) * 100);
                default:
                    return Convert.ToInt32(amount);
            }

        }

        public static bool VerifyNotify(SortedDictionary<string, string> param)
        {
            string sign="";
            if (param.TryGetValue("verify_sign", out sign))
            {
                param.Remove("verify_sign");
                string message = "";
                foreach (KeyValuePair<string, string> temp in param)
                {
                    message += temp.Key +"="+ temp.Value + "&";
                }
                message += Md5(Config.API_TOKEN);
                if (sign.ToLower() == Md5(message).ToLower())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;

        }

        public static string Md5(string message)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(message))).Replace("-", "").ToLower();
        }
    }
}