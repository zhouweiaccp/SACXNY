﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAC.DBOperations;
using System.Data;

namespace DAL
{
    public class PointsDAL
    {
        private string sql = "", errMsg = "";
        private object obj = null;
        private bool judge = false;
        private DataTable dt = new DataTable();
        private DBLink dl = new DBLink();

        #region 获取机组对应测点 BY  机组编码
        /// <summary>
        /// 获取机组对应测点
        /// </summary>
        /// <param name="unit">机组编号</param>
        /// <returns></returns>
        public DataTable GetPointsByUnit(string unit)
        {
            sql = "select T_POWERTAG,T_WINDTAG,T_ELECTRICTAG,T_STOPTIMETAG,T_FAULTTYPE,T_EXPLAINTYPE,T_CALCTIMETYPE,T_WUGONGGLV,T_GONGLVYINSHU,T_GONGLVYINSHUSHEDINGZHI,";
            sql += "T_ZHUANZHISUDU,T_MUXIANPINLV,T_FADIANJISUDUCPU,T_FADIANJISUDUPLC,T_TATONGPIANZHUANJIAODU,T_JICANGWEIZHI,T_CILUNXIANGZHOUCHENGWENDU,T_CHILUNXIANGWENDU,";
            sql += "T_JICANGWENDU,T_LIUYAYUYA,T_YEYAYUYA,T_JICANGZHUANDONG,T_10FENGXIANGCHAZHI,T_1MIAOFENGXIAGNCHAZHI,T_ZHUANJUSHIJIZHI,T_ZHUANJUSHEDINGZHI,T_HUANJINGWENDU,";
            sql += "T_WEIZHOUZHOUCHENGWENDU,T_FADIANJI1DIANWENDU,T_FADIANJI2DIANWENDU,T_FADIANJILENGQUEKONGQIWENDU,T_ZHOUCHENGAWENDU,T_ZHOUCHENGBWENDU";
            sql += " from Administrator.T_BASE_POINTS where T_UNITID='" + unit + "'";
            dt = dl.RunDataTable(sql, out errMsg);
            return dt;
        }
        #endregion
    }
}
