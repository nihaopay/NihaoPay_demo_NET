using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NihaoPayDemo
{
    public partial class Callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SortedDictionary<string, string> result = GetRequestGet();
                if (result.Count > 0)
                {
                    if (NihaoPay.Utils.VerifyNotify(result))
                    {
                        string status = Request.QueryString["status"];
                        string id = Request.QueryString["id"];
                       
                        Response.Write("transaction status = "+status);
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
            catch(Exception ex)
            {
                //Log(e);
                Response.Write("failed");
                Response.Write(ex);
            }
        }
        public SortedDictionary<string, string> GetRequestGet()
        {
            SortedDictionary<string, string> aResult = new SortedDictionary<string, string>();
            NameValueCollection coll = Request.QueryString;
            String[] requestItem = coll.AllKeys;
            for (int i = 0; i < requestItem.Length; i++)
            {
                if (!string.IsNullOrEmpty(Request.QueryString[requestItem[i]]))
                {
                    aResult.Add(requestItem[i], Request.QueryString[requestItem[i]]);
                }
            }
            return aResult;
        }

    }
}