using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SAC.DBOperations;

namespace DAL
{
    public class FaultDAL
    {
        private string sql = "";
        private object obj = null;

        DBLink dl = new DBLink();

        /// <summary>
        /// 根据风场期数获取机组ID和描述
        /// </summary>
        /// <param name="perid"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public DataTable GetUnitInfoByPID(string perid, out string errMsg)
        {
            errMsg = "";

            DataTable dt = null;

            sql = " select u.T_PERIODID,u.T_UNITID,u.T_UNITDESC,u.T_MACHINEID,p.T_FAULTTYPE from Administrator.T_BASE_POINTS_FD as p inner join Administrator.T_BASE_UNIT_FD as u on ";

            sql += "u.T_UNITID = p.T_UNITID where u.T_PERIODID='" + perid + "'";

            dt = dl.RunDataTable(sql, out errMsg);
            return dt;
        }

        /// <summary>
        /// 获取标准故障信息[故障次数维护]
        /// </summary>
        /// <param name="fType"></param>
        /// <returns></returns>
        public DataTable GetTabFaultTypeInfo(string fType)
        {
            string errMsg = "";
            DataTable dt = null;

            // T_BASE_FAULTSection_XNY & T_BASE_FAULTTYPE_XNY 联合查出标准故障信息
            sql = "select s.ID_KEY,s.T_SectionID,s.T_SectionDesc from Administrator.T_BASE_FAULTSection_XNY as s inner join  Administrator.T_BASE_FAULTTYPE_XNY as t ";

            sql += "on s.T_SectionID=t.T_Section where t.T_FaultType='" + fType + "'";

            dt = dl.RunDataTable(sql, out errMsg);

            return dt;
        }

        /// <summary>
        /// 获取错误次数[故障次数维护]
        /// </summary>
        /// <param name="uintID"></param>
        /// <param name="section"></param>
        /// <param name="qsrq"></param>
        /// <param name="jsrq"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public string GetFaultCount(string uintID, string section, string qsrq, string jsrq, out string errMsg)
        {

            errMsg = "";

            sql = "select sum(d_value) from Administrator.t_info_faultcount_xny where t_unitid='" + uintID + "' and t_faultsection='" + section + "' and t_time between '" + qsrq + "' and '" + jsrq + "'";

            obj = dl.RunDataTable(sql, out errMsg);

            return "";
        }
    }
}
