using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class FaultBLL
    {
        FaultDAL dal = new FaultDAL();

        /// <summary>
        /// 获取风场下属风机所有故障次数[故障次数维护]
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string GetFaultDataByPerId(string pId, string date)
        {
            string id = "", qsrq = "", jsrq = "", errMsg = "";
            DataTable dt = null, dtGzBJ = null;

            StringBuilder sb = new StringBuilder();

            qsrq = DateTime.Parse(date).ToString("yyyy-MM-dd 0:00:00");
            jsrq = DateTime.Parse(date).ToString("yyyy-MM-dd 23:59:59");

            dt = dal.GetUnitInfoByPID(pId, out errMsg);  //T_BASE_POINTS_XNY & T_BASE_UNIT_XNY 联合查出风场下属风机信息

            if (dt != null && dt.Rows.Count > 0)
            {
                // T_BASE_FAULTSection_XNY & T_BASE_FAULTTYPE_XNY 联合查出标准故障信息
                dtGzBJ = dal.GetTabFaultTypeInfo(dt.Rows[0]["T_FAULTTYPE"].ToString());

                sb.Append("<table class=\"admintable\">");

                for (int i = -1; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    if (i == -1)
                    {
                        sb.Append("<td class=\"admincls1\" align=\"center\" width=\"100px\">&nbsp;&nbsp;&nbsp;</td>");
                        for (int j = 0; j < dtGzBJ.Rows.Count; j++)
                        {
                            sb.Append("<td class=\"admincls1\" align=\"center\">" + dtGzBJ.Rows[j]["T_SectionDesc"] + "</td>");
                        }
                    }
                    else
                    {
                        sb.Append("<td class=\"admincls0\" align=\"center\"><div style=\"width:100px;\">" + dt.Rows[i]["T_UNITDESC"] + "</div></td>");

                        for (int j = 0; j < dtGzBJ.Rows.Count; j++)
                        {
                            object obj = dal.GetFaultCount(dt.Rows[i]["t_unitid"].ToString(), dtGzBJ.Rows[j]["T_SectionID"].ToString(), qsrq, jsrq, out errMsg);

                            if (obj != null && obj.ToString() != "")
                            {
                                sb.Append("<td class=\"admincls0\" align=\"center\"><input class=\"ipt\" id=\"" + dt.Rows[i]["t_unitid"].ToString() + "*" + dtGzBJ.Rows[j]["T_SectionID"].ToString() + "\" type=\"text\" value=\"" + obj.ToString() + "\"/></td>");
                                id += dt.Rows[i]["t_unitid"].ToString() + "*" + dtGzBJ.Rows[j]["T_SectionID"].ToString() + "+" + obj.ToString() + ";";
                            }
                            else
                            {
                                sb.Append("<td class=\"admincls0\" align=\"center\"><input class=\"ipt\" id=\"" + dt.Rows[i]["t_unitid"].ToString() + "*" + dtGzBJ.Rows[j]["T_SectionID"].ToString() + "\" type=\"text\" value=0 /></td>");
                                id += dt.Rows[i]["t_unitid"].ToString() + "*" + dtGzBJ.Rows[j]["T_SectionID"].ToString() + "+0;";
                            }
                        }
                    }
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
            }
            id = id.TrimEnd(';');

            return sb.ToString();
        }

    }
}
