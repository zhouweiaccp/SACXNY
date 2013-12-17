using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    /// <summary>
    /// 电量操作类
    /// </summary>
    public class BLL_STATISCS
    {
        DAL_STATISCS dSta = new DAL_STATISCS();

        #region 获取多个测点某段时间的电量  根据测点名称 开始时间 结束时间 机组
        /// <summary>
        /// 获取多个测点某段时间的电量
        /// </summary>
        /// <param name="st">开始时间</param>
        /// <param name="et">结束时间</param>
        /// <param name="unti">机组</param>
        /// <returns></returns>
        public DataTable GetDL(string st, string et, string units)
        {
            return dSta.GetDL(st, et, units);
        }
        #endregion

        public DataTable GetDlByTimeAndUnits(string st, string et, string untis)
        {
            return dSta.GetDlByTimeAndUnits(st, et, untis);
        }


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
            return dSta.GetDL(orgId, periodid, unitid, st, et, type, judge);
        }
        #endregion
    }
}
