using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NihaoPayDemo
{
    public partial class IPN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SortedDictionary<string, string> result = GetRequestPost();
                if (result.Count > 0)
                {
                    if (NihaoPay.Utils.VerifyNotify(result))
                    {
                        string status = Request.Form["status"];
                        string id = Request.Form["id"];
                        if (status.ToLower() == "success")
                        {
                            //订单支付成功
                            //更新网站中订单支付结果，注意不要重复更新
                        }
                        Response.Write("OK");
                    }
                    else
                    {
                        Response.Write("verify failed");
                    }
                }
                else
                {
                    Response.Write("无返回参数 no callback params");
                }
            }
            catch
            {
                //Log(e);
                Response.Write("failed");
            }
        }
        public SortedDictionary<string, string> GetRequestPost()
        {
            SortedDictionary<string, string> aResult = new SortedDictionary<string, string>();
            NameValueCollection coll = Request.Form;
            String[] requestItem = coll.AllKeys;
            for (int i = 0; i < requestItem.Length; i++)
            {
                aResult.Add(requestItem[i],Request.Form[requestItem[i]]);
            }
            return aResult;
        }
    }
}