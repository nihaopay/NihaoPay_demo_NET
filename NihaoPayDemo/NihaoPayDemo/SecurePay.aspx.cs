using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NihaoPayDemo
{
    public partial class SecurePay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.reference.Text = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                Random ran = new Random();
                int RandKey = ran.Next(0, 999);
                this.amount.Text = Math.Round(Convert.ToDecimal(RandKey) * 0.01m, 2).ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string,object> param=new Dictionary<string,object>();
                //商户订单号
                param.Add("reference", this.reference.Text.Trim());
                //订单币种
                param.Add("currency", this.currency.SelectedValue.ToUpper());

                //订单金额，NihaoPay接受int类型的金额，最小单位是分
                param.Add("amount", NihaoPay.Utils.GetSubmitAmount(amount.Text.Trim(), currency.SelectedValue.ToUpper()));

                //付款方式（支付宝，微信，银联）
                param.Add("vendor", this.vendor.SelectedValue.ToLower());

                //订单描述，可以是商品信息等
                param.Add("description", this.description.Text.Trim());

                //备注，nihaopay会在通知中返回，商户可以自定义，允许为空
                param.Add("note", this.note.Text.Trim());

                //服务器地址
                param.Add("ipn_url",NihaoPay.Config.ipn_url);

                param.Add("callback_url", NihaoPay.Config.callback_url);

                Response.Write(NihaoPay.Submit.submit(NihaoPay.Config.SECUREPAY_URL,param,RestSharp.Method.POST));
                Response.End();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}