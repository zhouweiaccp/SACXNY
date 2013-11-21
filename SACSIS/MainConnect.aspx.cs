using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string fncode = Request["fncode"];
            if (!string.IsNullOrWhiteSpace(fncode))
            {
                if (fncode == "zzjl")
                {
                    zzjl();
                }
            }
        }

        private void zzjl()
        {
            //string result = JsonConvert.SerializeObject(obj);
            string data = "[22]";
            string result = "{\"data\":" + data + "}";
            Response.Write(result);
            Response.End();
        }
    }
}