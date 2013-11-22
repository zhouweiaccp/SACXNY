﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using System.Collections;

namespace BLL
{
    public class WppBLL
    {
        WppDAL wd = new WppDAL();


        #region 获取工期信息  根据组织机构编号
        /// <summary>
        /// 获取工期信息
        /// </summary>
        /// <param name="orgID">组织机构编号</param>
        /// <returns></returns>
        public IList<Hashtable> GetPeriod(string orgID)
        {
            return wd.GetPeriod(orgID);
        }
        #endregion


        #region 获取机组信息  根据工期编号
        /// <summary>
        /// 获取机组信息 
        /// </summary>
        /// <param name="periodId"></param>
        /// <returns></returns>
        public DataTable GetUnit(string periodId)
        {
            return wd.GetUnit(periodId);
        }
        /// <summary>
        /// 获取机组信息
        /// </summary>
        /// <param name="periodId">工期编号</param>
        /// <returns></returns>
        public IList<Hashtable> GetUnits(string periodId)
        {
            return wd.GetUnits(periodId);
        }
        #endregion

        #region 获得风机型号 根据机组ID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idpt"></param>
        /// <param name="gq"></param>
        /// <returns></returns>
        public DataTable GetMachineID(string idpt,string gq)
        {
            return wd.GetMachineID(idpt,gq);
        }
        
        #endregion

        #region 获得风速，功率 根据风机ID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_machineIDs"></param>
        /// <returns></returns>
        public DataTable GetWppNWSpeed(string _machineIDs)
        {
            return wd.GetWppNWSpeed(_machineIDs);
        }

        #endregion


        #region 获得风速，功率 根据机组ID，开始时间，结束实际，工期ID
       /// <summary>
       /// 
       /// </summary>
       /// <param name="idpt"></param>
       /// <param name="gq"></param>
       /// <param name="sTime"></param>
       /// <param name="eTime"></param>
       /// <returns></returns>
        public DataTable GetInfoWppNWSpeed(string idpt, string gq, string sTime, string eTime)
        {
            return wd.GetWppNWSpeed(idpt,gq,sTime,eTime);
        }

        #endregion
    }
}
