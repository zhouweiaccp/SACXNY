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
        private PointBLL pointdll = new PointBLL();
        private PointsBLL pointsdll = new PointsBLL();

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
                    string[] points = new string[20];
                    double[] val = new double[20];

                    for (int k = 0; k < 5; k++)
                    {
                        points[k * 4] = dt.Rows[k][4].ToString();
                        points[k * 4 + 1] = dt.Rows[k][5].ToString();
                        points[k * 4 + 2] = dt.Rows[k][6].ToString();
                        points[k * 4 + 3] = dt.Rows[k][7].ToString();
                    }
                    val = pointdll.GetPointVal(points, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[1] + "&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[0] + "&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[2] + "&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[3] + "&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + i * 5 + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[5] + "&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[4] + "&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[6] + "&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[7] + "&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + i + 1 + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 2][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[9] + "&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[8] + "&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[10] + "&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[11] + "&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 2) + "\" onclick=\"ShowInfo('" + i + 2 + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 3][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[13] + "&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[12] + "&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[14] + "&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[15] + "&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 3) + "\" onclick=\"ShowInfo('" + i + 3 + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 4][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[17] + "&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[16] + "&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[18] + "&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[19] + "&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 4) + "\" onclick=\"ShowInfo('" + i + 4 + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                }
                else
                {
                    if (dt.Rows.Count % 5 == 1)
                    {
                        string[] points = new string[4];
                        double[] val = new double[4];

                        for (int k = 0; k < 1; k++)
                        {
                            points[k * 4] = dt.Rows[k][4].ToString();
                            points[k * 4 + 1] = dt.Rows[k][5].ToString();
                            points[k * 4 + 2] = dt.Rows[k][6].ToString();
                            points[k * 4 + 3] = dt.Rows[k][7].ToString();
                        }
                        val = pointdll.GetPointVal(points, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[1] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">"+val[0]+"&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[2] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[3] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"4\"><div id=\"dv_" + i * 5 + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                    }
                    else if (dt.Rows.Count % 5 == 2)
                    {
                        string[] points = new string[8];
                        double[] val = new double[8];

                        for (int k = 0; k < 2; k++)
                        {
                            points[k * 4] = dt.Rows[k][4].ToString();
                            points[k * 4 + 1] = dt.Rows[k][5].ToString();
                            points[k * 4 + 2] = dt.Rows[k][6].ToString();
                            points[k * 4 + 3] = dt.Rows[k][7].ToString();
                        }
                        val = pointdll.GetPointVal(points, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[1] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[0] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[2] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[3] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"2\"><div id=\"dv_" + (i * 5) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[5] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[4] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[6] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[7] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"3\"><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                    }
                    else if (dt.Rows.Count % 5 == 3)
                    {
                        string[] points = new string[12];
                        double[] val = new double[12];

                        for (int k = 0; k < 3; k++)
                        {
                            points[k * 4] = dt.Rows[k][4].ToString();
                            points[k * 4 + 1] = dt.Rows[k][5].ToString();
                            points[k * 4 + 2] = dt.Rows[k][6].ToString();
                            points[k * 4 + 3] = dt.Rows[k][7].ToString();
                        }
                        val = pointdll.GetPointVal(points, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[1] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[0] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[2] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[3] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[5] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[4] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[6] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[7] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 2][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[9] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[8] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[10] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[11] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"3\"><div id=\"dv_" + (i * 5 + 2) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                    }
                    else if (dt.Rows.Count % 5 == 4)
                    {
                        string[] points = new string[16];
                        double[] val = new double[16];

                        for (int k = 0; k < 3; k++)
                        {
                            points[k * 4] = dt.Rows[k][4].ToString();
                            points[k * 4 + 1] = dt.Rows[k][5].ToString();
                            points[k * 4 + 2] = dt.Rows[k][6].ToString();
                            points[k * 4 + 3] = dt.Rows[k][7].ToString();
                        }
                        val = pointdll.GetPointVal(points, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[1] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[0] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[2] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[3] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + i * 5 + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[5] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[4] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[6] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[7] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 2][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[9] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[8] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[10] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[11] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + i + "')\" style=\"margin-top: 5px; margin-left: 10px; width:260px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"80px\">" + dt.Rows[i * 5 + 3][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"80px\">" + val[13] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"80px\">" + val[12] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"80px\">" + val[14] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"80px\">" + val[15] + "&nbsp;rpm</td></tr>");
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