using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SAC.DBOperations;

namespace DAL
{
    public class RLDAL
    {
        private DataTable dt = new DataTable();
        private DBLink dl = new DBLink();
        private string sql = "", errMsg = "";
        /// <summary>
        /// 获取容量
        /// </summary>
        /// <param name="id">工期</param>
        /// <returns></returns>
        public DataTable GetRL(string id)
        {

            sql = "select sum(decimal(容量,31,4)) 容量,sum(decimal(接入容量,31,4)) 接入容量,sum(decimal(在建容量,31,4)) 在建容量,sum(decimal(投产容量,31,4)) 投产容量 from ADMINISTRATOR.T_INFO_RL where T_ORGID='" + id + "'";
            dt = dl.RunDataTable(sql, out errMsg);
            return dt;
        }
    }
}
