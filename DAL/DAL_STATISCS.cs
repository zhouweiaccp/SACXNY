using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAC.DBOperations;
using System.Data;

namespace DAL
{
    /// <summary>
    /// 电量操作类
    /// </summary>
    public class DAL_STATISCS
    {
        string sql = "";
        string errMsg = "";

        DBLink dl = new DBLink();

        #region 获取机组指定时间内电量集合      根据测点名称 开始时间 结束时间 XML名称 组织机构编码 机组 和工期
        /// <summary>
        /// 获取机组指定时间内电量集合 
        /// </summary>
        /// <param name="st">开始时间</param>
        /// <param name="et">结束时间</param>
        /// <param name="unti">机组</param>
        /// <returns></returns>
        public DataTable GetDL(string st, string et, string units)
        {
            sql = @"select sum(t.D_VALUE) as result ,t.T_UNITDESC 
                    from (
                        select s.D_VALUE,s.T_UNITID,s.T_TIME,u.T_UNITDESC,u.T_PERIODID from Administrator.T_INFO_STATISCS s 
                        inner join Administrator.T_BASE_UNIT u on s.T_UNITID=u.T_UNITID  
                        where s.T_UNITID in (" + units + ") and s.T_Time >'" + st + "' and s.T_Time<'" + et + "' and s.T_TJID='DL' and u.T_PERIODID='SDFDC-QB') as t group by t.T_UNITDESC";
            return dl.RunDataTable(sql, out errMsg);
        }
        #endregion

        /// <summary>
        /// 获取机组指定时间内电量明细
        /// </summary>
        /// <param name="st">开始时间</param>
        /// <param name="et">结束时间</param>
        /// <param name="untis">机组</param>
        /// <returns></returns>
        public DataTable GetDlByTimeAndUnits(string st, string et, string untis)
        {
            sql = @"select  s.D_VALUE,s.T_UNITID,s.T_TIME,u.T_UNITDESC,u.T_PERIODID  from Administrator.T_INFO_STATISCS s
                    inner join Administrator.T_BASE_UNIT u on s.T_UNITID=u.T_UNITID  
                    where s.T_UNITID in (" + untis + ") and s.T_Time >'" + st + "' and s.T_Time<'" + et + "' and s.T_TJID='DL' and u.T_PERIODID='SDFDC-QB'";
            return dl.RunDataTable(sql, out errMsg);
        }

        // public DataTable GetValByTime(string time, string units, 
        private DataTable dt = new DataTable();
        private string sqlWhere = "";

        #region 获取统计数据
        /// <summary>
        /// 统计数据
        /// </summary>
        /// <param name="orgId">风场ID</param>
        /// <param name="periodid">工期ID</param>
        /// <param name="unitid">机组ID </param>
        /// <param name="st">开始时间</param>
        /// <param name="et">结束时间</param>
        /// <param name="type">统计类型</param>
        /// <param name="judge">统计方式: 0 求和; 1 获取详细信息</param>
        /// <returns></returns>
        public DataTable GetDL(string orgId, string periodid, string unitid, string st, string et, string type, int judge)
        {
            sqlWhere += " where 1=1";
            sql = "";
            if (orgId != "")
                sqlWhere += " and T_ORGID='" + orgId + "'";

            if (periodid != "")
                sqlWhere += " and T_PERIODID='" + periodid + "'";

            if (unitid != "")
                sqlWhere += " and T_UNITID='" + unitid + "'";

            if (st != "" && et != "")
                sqlWhere += " and T_TIME>='" + st + "' and T_TIME<'" + et + "'";
            if (judge == 0)
                sql += "select select sum(decimal(D_VALUE,31,4)) D_VALUE from ADMINISTRATOR.T_INFO_STATISCS where T_TJID='" + type + "'";
            else
                sql += "select D_VALUE,T_TIME,T_OGGID,T_PERIODID,T_UNITID from ADMINISTRATOR.T_INFO_STATISCS where T_TJID='" + type + "'";
            sql += sqlWhere;

            dt = dl.RunDataTable(sql, out errMsg);

            return dt;
        }
        #endregion
    }
}
