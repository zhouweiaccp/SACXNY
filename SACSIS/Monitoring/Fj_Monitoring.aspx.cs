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
                else if (param == "point")
                {
                    string jzid = Request["id"];
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
                if (dt.Rows.Count % 5 == 0)
                    num = dt.Rows.Count / 5;
                else
                    num = dt.Rows.Count / 5 + 1;
            }
            st.Append("<table>");
            StringBuilder stb = null;
            for (int i = 0; i < num; i++)
            {
                st.Append("<tr>");
                if (i != num - 1 && num - 1 != 0)
                {

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + i * 5 + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + i + 1 + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 2][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 2) + "\" onclick=\"ShowInfo('" + i + 2 + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 3][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 3) + "\" onclick=\"ShowInfo('" + i + 3 + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 4][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 4) + "\" onclick=\"ShowInfo('" + i + 4 + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                }
                else
                {
                    if (dt.Rows.Count % 5 == 1)
                    {
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"4\"><div id=\"dv_" + i * 5 + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                    }
                    else if (dt.Rows.Count % 5 == 2)
                    {
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"2\"><div id=\"dv_" + (i * 5) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"3\"><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                    }
                    else if (dt.Rows.Count % 5 == 3)
                    {
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 2][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"3\"><div id=\"dv_" + (i * 5 + 2) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                    }
                    else if (dt.Rows.Count % 5 == 4)
                    {
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + i * 5 + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 2][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 3][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">0&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">0&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">0&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"2\"><div id=\"dv_" + (i * 5 + 3) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                    }
                }
                st.Append("</tr>");
            }

            st.Append("</table>");

            object obj = new
            {
                tb = st.ToString(),
                num = dt.Rows.Count
            };

            string result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            Response.Write(result);
            Response.End();
        }
    }
}