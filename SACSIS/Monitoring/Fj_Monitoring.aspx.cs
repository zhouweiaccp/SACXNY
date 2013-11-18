using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BLL;
using System.Data;

namespace SACSIS.Monitoring
{
    public partial class Fj_Monitoring : System.Web.UI.Page
    {
        private PeriodBLL dll = new PeriodBLL();
        private StringBuilder st = new StringBuilder();
        private string id = "MGY3";
        private DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            string param = Request["param"];
            if (Request["id"] != null)
            {
                id = Request["id"];
            }
            if (param != "")
            {
                if (param == "Init")
                {
                    GetInit(id);
                }
            }

        }

        //初始化风机信息
        private void GetInit(string id)
        {
            dt = dll.GetUnit(id);
            int num = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows.Count % 6 == 0)
                    num = dt.Rows.Count / 6;
                else
                    num = dt.Rows.Count / 6 + 1;
            }
            st.Append("<table>");

            for (int i = 0; i < num; i++)
            {
                st.Append("<tr>");
                if (i != num - 1 && num - 1 != 0)
                {
                    st.Append("<td><div id=\"dv_" + i * 6 + "\" style=\"margin-top: 5px; margin-left: 10px; width: 200px; height: 100px;background-image: url(../img/bg08.jpg);\"></div></td>");
                    st.Append("<td><div id=\"dv_" + (i * 6 + 1) + "\" style=\"margin-top: 5px; margin-left: 10px; width: 200px; height: 100px;background-image: url(../img/bg08.jpg);\"></div></td>");
                    st.Append("<td><div id=\"dv_" + (i * 6 + 2) + "\" style=\"margin-top: 5px; margin-left: 10px; width: 200px; height: 100px;background-image: url(../img/bg08.jpg);\"></div></td>");
                    st.Append("<td><div id=\"dv_" + (i * 6 + 3) + "\" style=\"margin-top: 5px; margin-left: 10px; width: 200px; height: 100px;background-image: url(../img/bg08.jpg);\"></div></td>");
                    st.Append("<td><div id=\"dv_" + (i * 6 + 4) + "\" style=\"margin-top: 5px; margin-left: 10px; width: 200px; height: 100px;background-image: url(../img/bg08.jpg);\"></div></td>");
                    st.Append("<td><div id=\"dv_" + (i * 6 + 5) + "\" style=\"margin-top: 5px; margin-left: 10px; width: 200px; height: 100px;background-image: url(../img/bg08.jpg);\"></div></td>");
                }
                else
                {
                    st.Append("<td colspan=\"" + dt.Rows.Count % 6 + "\"><div id=\"dv_" + i + "\" style=\"margin-top: 5px; margin-left: 10px; width: 200px; height: 100px;background-image: url(../img/bg08.jpg);\"></div></td>");
                }
                st.Append("</tr>");
            }

            st.Append("</table>");

            object obj = new
            {
                tb = st.ToString()
            };

            string result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            Response.Write(result);
            Response.End();
        }
    }
}