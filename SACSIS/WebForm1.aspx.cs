using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAC.DBOperations;
using System.Data;
using System.Text;

namespace SACSIS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string funCode = Request["funCode"];

            if (!string.IsNullOrWhiteSpace(funCode))
            {
                if (funCode == "init")
                {
                    LoadData();
                }
            }

        }

        private void LoadData()
        {
            string sql = "";
            string errMsg = "";

            DBLink dl = new DBLink();
            sql = @"select  p.T_PERIODDESC 风电场,r.容量 装机容量 from ADMINISTRATOR.T_BASE_PERIOD p
                    inner join ADMINISTRATOR.T_INFO_RL r on p.T_PERIODID=r.T_ORGID";
            DataTable dt = dl.RunDataTable(sql, out errMsg);








            string data = ConvertDataTableToHTML(dt);
            string result = "{\"data\":" + data + "}";
            Response.Write(result);
            Response.End();
        }


        public string ConvertDataTableToHTML(DataTable dt)
        {
            StringBuilder htmlTable = new StringBuilder();
            if (dt != null)
            {
                htmlTable.Append("\"<table cellSpacing='0' cellPadding='0' width ='100%' border='1'>");
                //htmlTable.Append("<tr>");
                //for (int i = 0; i < dt.Columns.Count; i++)
                //{
                //    htmlTable.Append(string.Format("<td>{0}</td>", dt.Columns[i].ColumnName));
                //}
                //htmlTable.Append("</tr>");

                ////htmlTable.Append("<tr height='18'><td rowspan='2' height='36' width='111'>风电场</td><td colspan='2' width='116'>装机情况</td><td colspan='3' width='141'>出力情况</td><td colspan='10' width='752'>电量情况</td><td colspan='8' width='509'>机组运行状态</td></tr>");

                //if (dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        htmlTable.Append("<tr>");
                //        //htmlTable.Append(string.Format("<td>{0}</td>", i + 1));
                //        for (int j = 0; j < dt.Columns.Count; j++)
                //        {
                //            htmlTable.Append(string.Format("<td>{0}</td>", dt.Rows[i][j].ToString()));
                //        }
                //        htmlTable.Append("<tr>");
                //    }
                //}
                string s = @"<tr><td rowspan='2' height='36' width='111'>风电场</td><td colspan='2' width='116'>装机情况</td><td colspan='3' width='141'>出力情况</td><td colspan='10' width='752'>电量情况</td><td colspan='8' width='509'>机组运行状态</td></tr>  <tr><td>装机容量</td><td>机型</td><td>风速</td><td>功率</td><td>限负荷</td><td>日电量</td>    <td>日等效利用小时</td>    <td>月电量</td>    <td>月计划</td>    <td>月完成率</td>    <td>月等效利用小时</td>    <td>年累计</td>    <td>年计划</td>    <td>年完成率</td>    <td>年等效利用小时</td>    <td>总台数</td>    <td>运行</td>    <td>计划检修</td>    <td>故障</td><td>待机</td><td>机组故障率</td><td>机组状态排名</td><td>出力率排名</td>  </tr> ";



                string ss = "<tr><td>玫瑰营风电场</td><td>50.25</td><td>东汽风机</td><td>8.16</td><td>378.23</td><td>　</td><td>　</td><td>　</td><td>　</td>    <td>　</td><td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td><td>　</td><td>　</td><td>　</td><td>　</td></tr>";
                string ss1 = "<tr><td>玫瑰营一期</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td>    <td>　</td><td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td><td>　</td><td>　</td><td>　</td><td>　</td></tr>";
                string ss2 = "<tr><td>玫瑰营二期</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td>    <td>　</td><td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td><td>　</td><td>　</td><td>　</td><td>　</td></tr>";
                string ss3 = "<tr><td>富丽达风电场</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td>    <td>　</td><td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td><td>　</td><td>　</td><td>　</td><td>　</td></tr>";
                string ss4 = "<tr><td>三胜风电场</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td><td>　</td>    <td>　</td><td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td>    <td>　</td><td>　</td><td>　</td><td>　</td><td>　</td></tr>";

                htmlTable.Append(s);
                htmlTable.Append(ss);
                htmlTable.Append(ss1);
                htmlTable.Append(ss2);
                htmlTable.Append(ss3);
                htmlTable.Append(ss4);
                htmlTable.Append("</table>\"");
            }
            return htmlTable.ToString();
        }

    }
}