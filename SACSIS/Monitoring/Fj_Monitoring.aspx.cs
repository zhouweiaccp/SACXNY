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
                    GetjzinfoByID(jzid);
                }
            }

        }

        private void GetjzinfoByID(string jz)
        {
            double[] val = null;

            dt = pointsdll.GetPointsByUnit(jz);
            if (dt != null && dt.Rows.Count > 0)
            {
                string[] points = new string[28];
                if (dt.Rows[0][0] != null && dt.Rows[0][0].ToString() != "") points[0] = dt.Rows[0][0].ToString(); else points[0] = "";
                if (dt.Rows[0][1] != null && dt.Rows[0][1].ToString() != "") points[1] = dt.Rows[0][1].ToString(); else points[1] = "";
                if (dt.Rows[0][7] != null && dt.Rows[0][2].ToString() != "") points[2] = dt.Rows[0][7].ToString(); else points[2] = "";
                if (dt.Rows[0][8] != null && dt.Rows[0][3].ToString() != "") points[3] = dt.Rows[0][8].ToString(); else points[3] = "";
                if (dt.Rows[0][9] != null && dt.Rows[0][4].ToString() != "") points[4] = dt.Rows[0][9].ToString(); else points[4] = "";
                if (dt.Rows[0][10] != null && dt.Rows[0][5].ToString() != "") points[5] = dt.Rows[0][10].ToString(); else points[5] = "";
                if (dt.Rows[0][11] != null && dt.Rows[0][6].ToString() != "") points[6] = dt.Rows[0][11].ToString(); else points[6] = "";
                if (dt.Rows[0][12] != null && dt.Rows[0][7].ToString() != "") points[7] = dt.Rows[0][12].ToString(); else points[7] = "";
                if (dt.Rows[0][13] != null && dt.Rows[0][8].ToString() != "") points[8] = dt.Rows[0][13].ToString(); else points[8] = "";
                if (dt.Rows[0][14] != null && dt.Rows[0][9].ToString() != "") points[9] = dt.Rows[0][14].ToString(); else points[9] = "";
                if (dt.Rows[0][15] != null && dt.Rows[0][10].ToString() != "") points[10] = dt.Rows[0][15].ToString(); else points[10] = "";
                if (dt.Rows[0][16] != null && dt.Rows[0][11].ToString() != "") points[11] = dt.Rows[0][16].ToString(); else points[11] = "";
                if (dt.Rows[0][17] != null && dt.Rows[0][12].ToString() != "") points[12] = dt.Rows[0][17].ToString(); else points[12] = "";
                if (dt.Rows[0][18] != null && dt.Rows[0][13].ToString() != "") points[13] = dt.Rows[0][18].ToString(); else points[13] = "";
                if (dt.Rows[0][19] != null && dt.Rows[0][14].ToString() != "") points[14] = dt.Rows[0][19].ToString(); else points[14] = "";
                if (dt.Rows[0][20] != null && dt.Rows[0][15].ToString() != "") points[15] = dt.Rows[0][20].ToString(); else points[15] = "";
                if (dt.Rows[0][21] != null && dt.Rows[0][16].ToString() != "") points[16] = dt.Rows[0][21].ToString(); else points[16] = "";
                if (dt.Rows[0][22] != null && dt.Rows[0][17].ToString() != "") points[17] = dt.Rows[0][22].ToString(); else points[17] = "";
                if (dt.Rows[0][23] != null && dt.Rows[0][18].ToString() != "") points[18] = dt.Rows[0][23].ToString(); else points[18] = "";
                if (dt.Rows[0][24] != null && dt.Rows[0][19].ToString() != "") points[19] = dt.Rows[0][24].ToString(); else points[19] = "";
                if (dt.Rows[0][25] != null && dt.Rows[0][20].ToString() != "") points[20] = dt.Rows[0][25].ToString(); else points[20] = "";
                if (dt.Rows[0][26] != null && dt.Rows[0][21].ToString() != "") points[21] = dt.Rows[0][26].ToString(); else points[21] = "";
                if (dt.Rows[0][27] != null && dt.Rows[0][22].ToString() != "") points[22] = dt.Rows[0][27].ToString(); else points[22] = "";
                if (dt.Rows[0][28] != null && dt.Rows[0][23].ToString() != "") points[23] = dt.Rows[0][28].ToString(); else points[23] = "";
                if (dt.Rows[0][29] != null && dt.Rows[0][24].ToString() != "") points[24] = dt.Rows[0][29].ToString(); else points[24] = "";
                if (dt.Rows[0][30] != null && dt.Rows[0][25].ToString() != "") points[25] = dt.Rows[0][30].ToString(); else points[25] = "";
                if (dt.Rows[0][31] != null && dt.Rows[0][26].ToString() != "") points[26] = dt.Rows[0][31].ToString(); else points[26] = "";
                if (dt.Rows[0][32] != null && dt.Rows[0][27].ToString() != "") points[27] = dt.Rows[0][32].ToString(); else points[27] = "";         

                val = pointdll.GetPointVal(points, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            object obj = new
            {
                val = val
            };

            string result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            Response.Write(result);
            Response.End();
        }

        #region 初始化风机数据
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
            StringBuilder stb = null;
            for (int i = 0; i < num; i++)
            {
                st.Append("<tr>");
                if (i != num - 1 && num - 1 != 0)
                {
                    string[] points = new string[24];
                    double[] val = new double[24];

                    for (int k = 0; k < 6; k++)
                    {
                        points[k * 4] = dt.Rows[k][4].ToString();
                        points[k * 4 + 1] = dt.Rows[k][5].ToString();
                        points[k * 4 + 2] = dt.Rows[k][6].ToString();
                        points[k * 4 + 3] = dt.Rows[k][7].ToString();
                    }
                    val = pointdll.GetPointVal(points, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 10px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[1] + "&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[0] + "&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[2] + "&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[3] + "&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + i * 5 + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 0][0] + "','" + dt.Rows[i * 5][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 10px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[5] + "&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[4] + "&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[6] + "&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[7] + "&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 1][0] + "','" + dt.Rows[i * 5 + 1][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 10px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 2][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[9] + "&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[8] + "&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[10] + "&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[11] + "&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 2) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 2][0] + "','" + dt.Rows[i * 5 + 2][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 10px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 3][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[13] + "&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[12] + "&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[14] + "&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[15] + "&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 3) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 3][0] + "','" + dt.Rows[i * 5 + 3][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 10px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 4][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[17] + "&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[16] + "&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[18] + "&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[19] + "&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 4) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 4][0] + "','" + dt.Rows[i * 5 + 4][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                    stb = new StringBuilder();
                    stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 10px;\">");
                    stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[21] + "&nbsp;m/s</td></tr>");
                    stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[20] + "&nbsp;kw</td></tr>");
                    stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[22] + "&nbsp;kvar</td></tr>");
                    stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[23] + "&nbsp;rpm</td></tr>");
                    stb.Append("</table>");
                    st.Append("<td><div id=\"dv_" + (i * 5 + 5) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 5][0] + "','" + dt.Rows[i * 5 + 5][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width: 220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

                }
                else
                {
                    if (dt.Rows.Count % 6 == 1)
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
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[1] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[0] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[2] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[3] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"6\"><div id=\"dv_" + i * 5 + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 0][0] + "','" + dt.Rows[i * 5][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                    }
                    else if (dt.Rows.Count % 6 == 2)
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
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[1] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[0] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[2] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[3] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 0][0] + "','" + dt.Rows[i * 5][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[5] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[4] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[6] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[7] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"5\" align=\"left\"><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 1][0] + "','" + dt.Rows[i * 5 + 1][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                    }
                    else if (dt.Rows.Count % 6 == 3)
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
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[1] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[0] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[2] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[3] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 0][0] + "','" + dt.Rows[i * 5][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[5] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[4] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[6] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[7] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 1][0] + "','" + dt.Rows[i * 5 + 1][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 2][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[9] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[8] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[10] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[11] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"4\" align=\"left\"><div id=\"dv_" + (i * 5 + 2) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 2][0] + "','" + dt.Rows[i * 5 + 2][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                    }
                    else if (dt.Rows.Count % 6 == 4)
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
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[1] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[0] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[2] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[3] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + i * 5 + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 0][0] + "','" + dt.Rows[i * 5][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[5] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[4] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[6] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[7] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 1][0] + "','" + dt.Rows[i * 5 + 1][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 2][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[9] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[8] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[10] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[11] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5 + 2) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 2][0] + "','" + dt.Rows[i * 5 + 2][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 3][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[13] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[12] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[14] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[15] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"3\" align=\"left\"><div id=\"dv_" + (i * 5 + 3) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 3][0] + "','" + dt.Rows[i * 5 + 3][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                    }
                    else if (dt.Rows.Count % 6 == 5)
                    {
                        string[] points = new string[20];
                        double[] val = new double[20];

                        for (int k = 0; k < 4; k++)
                        {
                            points[k * 4] = dt.Rows[k][4].ToString();
                            points[k * 4 + 1] = dt.Rows[k][5].ToString();
                            points[k * 4 + 2] = dt.Rows[k][6].ToString();
                            points[k * 4 + 3] = dt.Rows[k][7].ToString();
                        }
                        val = pointdll.GetPointVal(points, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[1] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[0] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[2] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[3] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + i * 5 + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 0][0] + "','" + dt.Rows[i * 5][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 1][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[5] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[4] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[6] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[7] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5 + 1) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 1][0] + "','" + dt.Rows[i * 5 + 1][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 2][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[9] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[8] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[10] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[11] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5 + 2) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 2][0] + "','" + dt.Rows[i * 5 + 2][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 3][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[13] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[12] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[14] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[15] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"1\"><div id=\"dv_" + (i * 5 + 3) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 3][0] + "','" + dt.Rows[i * 5 + 3][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");
                        stb = new StringBuilder();
                        stb.Append("<table style=\"float: right; margin-top: 15px; margin-right: 15px;\">");
                        stb.Append("<tr><td height=\"20px\" width=\"60px\">" + dt.Rows[i * 5 + 4][1] + "</td><td height=\"20px\" valign=\"middle\" align=\"left\">风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:</td><td height=\"20px\" width=\"60px\">" + val[17] + "&nbsp;m/s</td></tr>");
                        stb.Append("<tr><td height=\"20px\"></td><td height=\"20px\" valign=\"middle\" align=\"left\">有功功率:</td><td height=\"20px\" width=\"60px\">" + val[16] + "&nbsp;kw</td></tr>");
                        stb.Append("<tr><td rowspan=\"2\"><img src=\"../img/fjjk_yx.png\" /></td><td height=\"20px\" valign=\"middle\" align=\"left\">无功功率:</td><td height=\"20px\" width=\"60px\">" + val[18] + "&nbsp;kvar</td></tr>");
                        stb.Append("<tr><td height=\"20px\" valign=\"middle\" align=\"left\">转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:</td><td height=\"20px\" width=\"60px\">" + val[19] + "&nbsp;rpm</td></tr>");
                        stb.Append("</table>");
                        st.Append("<td colspan=\"2\" align=\"left\"><div id=\"dv_" + (i * 5 + 4) + "\" onclick=\"ShowInfo('" + dt.Rows[i * 5 + 4][0] + "','" + dt.Rows[i * 5 + 4][1] + "')\" style=\"margin-top: 5px; margin-left: 10px; width:220px; height: 107px;background-image: url(../img/fjjk_bg.jpg);\">" + stb.ToString() + "</div></td>");

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
        #endregion
    }
}