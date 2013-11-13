using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SAC.DBOperations;

namespace DAL
{
    /// <summary>
    /// 数据填报
    /// </summary>
    public class FormDAL
    {
        private string sql = "", errMsg = "";
        private object obj = null;
        private bool judge = false;
        private DataTable dt = new DataTable();
        private DBLink dl = new DBLink();

        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="tableName">数据表名称</param>
        /// <returns></returns>
        public string createTable(string tableName)
        {
            sql = "if object_id(N'" + tableName + "',N'U') is not null print '存在' else print '不存在'";
            obj = dl.RunSingle(sql, out errMsg);
            return obj.ToString();
        }

        /// <summary>
        /// 获取填报数据信息
        /// </summary>
        /// <param name="treeId">菜单树ID</param>
        /// <param name="orgId">组织机构ID</param>
        /// // <param name="formID">表单ID</param>
        /// <returns></returns>
        public DataTable GetCreateInfo(string treeId, string orgId, string formID)
        {
            sql = "select f.t_formname,f.t_Table,f.T_TIMEFIELD,f.t_orgfield,f.t_timetype,f.i_formtype,fa.t_paraid,fa.t_paradesc,fa.t_Parafield,fa.t_Paratype,fa.t_Formula,fa.t_Formulapara,fa.i_flag,fa.i_Order,fa.i_level,fa.I_INPUTTYPE,fa.T_JUDGESHARE,fa.T_TYPE from T_INFO_FORM f inner join T_INFO_FORMPARA fa on f.t_Formid = fa.t_Formid  and f.T_ORGID=fa.T_ORGID and f.T_TREEID=fa.T_TREEID where fa.t_orgid='" + orgId + "' and fa.t_Treeid='" + treeId + "' and f.T_FORMID='" + formID + "' order by fa.I_ORDER asc";
            dt = dl.RunDataTable(sql, out errMsg);
            return dt;
        }

        /// <summary>
        /// 为数据库表添加列
        /// </summary>
        /// <param name="tableName">数据库表名称</param>
        /// <param name="columns">列集合</param>
        /// <returns></returns>
        public bool CreateColumns(string tableName, string columns)
        {
            judge = true;
            //if (rlDBType == "SQL")
            //{
            for (int i = 0; i < columns.Split('*').Length; i++)
            {
                sql += "IF COL_LENGTH('" + tableName + "', '" + columns.Split('*')[i] + "') IS NULL alter table " + tableName + " add " + columns.Split('*')[i] + " char(255);";
            }
            judge = dl.RunNonQuery(sql, out errMsg);
            return judge;
        }

        #region 填报数据  指标数据
        /// <summary>
        /// 填报数据
        /// </summary>
        /// <param name="table">数据存储表名称</param>
        /// <param name="time">数据填报时间</param>
        /// <param name="timeName">数据存储表  时间字段名称</param>
        /// <param name="treeName">组织机构树名称</param>
        /// <param name="time">组织机构编号</param>
        /// <param name="value">填报的数据集</param>
        /// <param name="formID">表单编号</param>
        /// <returns></returns>
        public bool UpZBData(string table, string time, string timeName, string treeName, string orgId, string value, string formID)
        {
            DataTable dtList = new DataTable();

            dtList = dl.RunDataTable(sql, out errMsg);


            sql = "delete from " + table + " where T_TREEID='" + treeName + "' and T_ORGID='" + orgId + "' and " + timeName + "='" + time + "';";

            sql += "insert into " + table + "(";
            value = "T_TREEID~" + treeName + "`T_ORGID~" + orgId + "`" + value;
            string[] ht = value.Split('`');
            for (int i = 0; i < ht.Length; i++)
            {
                if (i < 2)
                    sql += ht[i].Split('~')[0].ToString() + ",";
                else
                    for (int k = 0; k < dtList.Rows.Count; k++)
                    {
                        if (dtList.Rows[k]["T_PARAID"].ToString() == ht[i].Split('~')[0].ToString())
                        {
                            sql += dtList.Rows[k]["T_PARAFIELD"].ToString() + ",";
                            break;
                        }
                    }

            }
            sql += timeName + ") values (";
            for (int i = 0; i < ht.Length; i++)
            {
                sql += "'" + ht[i].Split('~')[1].ToString() + "',";
            }

            sql += "'" + time + "')";
            judge = dl.RunNonQuery(sql, out errMsg);

            return judge;
        }
        #endregion

        #region  填报数据  组织机构维度数据
        /// <summary>
        /// 填报数据  组织机构维度数据
        /// </summary>
        /// <param name="table">数据存储表名称</param>
        /// <param name="time">填报时间</param>
        /// <param name="timeName">数据存储表时间字段名称</param>
        /// <param name="id">填报字段名称集合</param>
        /// <param name="orgId">组织维度集合</param>
        /// <param name="value">填报数据集合</param>
        /// <param name="xmlName">组织机构集合名称</param>
        /// <returns></returns>
        public bool UpData(string table, string time, string timeName, string id, string orgId, string value, string xmlName)
        {
            sql = "";
            id = id.Replace('*', ',');

            string[] ht = value.Split('`');
            string[] org = orgId.Split('*');
            int num = org.Length;
            int count = id.Split(',').Length;

            string orgIds = "";
            for (int i = 0; i < org.Length; i++)
            {
                orgIds += "'" + org[i] + "',";
            }
            orgIds = orgIds.Substring(0, orgIds.Length - 1);
            sql = "delete from " + table + " where T_TREEID='" + xmlName + "' and T_TIME='" + time + "' and T_ORGID in(" + orgIds + ")";

            judge = dl.RunNonQuery(sql, out errMsg);
            //}

            for (int k = 0; k < num; k++)
            {
                sql += "insert into " + table + "(" + id + ") values (";

                for (int i = 0; i < count - 3; i++)
                {
                    sql += "'" + ht[i + (count - 3) * k].Split('~')[1].ToString() + "',";
                }
                sql += "'" + xmlName + "','" + org[k].ToString() + "','" + time + "')";
                judge = dl.RunNonQuery(sql, out errMsg);

                sql = "";
            }
            return judge;
        }
        #endregion

        #region 查询填报数据  指标维度
        /// <summary>
        /// 查询填报数据  指标维度
        /// </summary>
        /// <param name="columns">查询字段</param>
        /// <param name="tableName">查询表名称</param>
        /// <param name="timeType">时间字段名称</param>
        /// <param name="time">查询时间</param>
        /// /// <param name="treeName">组织机构树名称</param>
        /// <param name="orgId">组织机构ID</param>
        /// <returns></returns>
        public DataTable GetCreateValueZB(string columns, string tableName, string timeType, string time, string treeName, string orgId)
        {

            sql = "select " + columns + " from " + tableName + " where " + timeType + "='" + time + "' and T_TREEID='" + treeName + "' and T_ORGID='" + orgId + "';";

            dt = dl.RunDataTable(sql, out errMsg);
            //}
            return dt;
        }

        /// <summary>
        /// 查询填报数据
        /// </summary>
        /// <param name="columns">查询字段</param>
        /// <param name="tableName">查询表名称</param>
        /// <param name="timeType">时间字段名称</param>
        /// <param name="time">查询时间</param>
        /// /// <param name="treeName">组织机构树名称</param>
        /// <param name="orgId">组织机构ID</param>
        /// <param name="fid">表单编号</param>
        /// <returns></returns>
        public DataTable GetCreateValue(string columns, string tableName, string timeType, string time, string treeName, string orgId, string fid)
        {
            columns = columns.Replace('*', ',');

            sql = "select " + columns + "T_ORGID from dbo." + tableName + " where " + timeType + "='" + time + "' and T_TREEID='" + treeName + "' and T_ORGID in(select T_PARAID from T_INFO_FORMPARA where T_ORGID='" + orgId + "' and T_PARATYPE=2 and T_FORMID='" + fid + "')";

            dt = dl.RunDataTable(sql, out errMsg);

            return dt;
        }

        /// <summary>
        /// 获取填报公式等级
        /// </summary>
        /// <param name="treeName">组织机构数名称</param>
        /// <param name="orgId">组织机构编码</param>
        /// <param name="formID">表单编号</param>
        /// <returns></returns>
        public DataTable GetFormGrade(string treeName, string orgId, string formID)
        {
            sql = "select distinct I_LEVEL From T_INFO_FORMPARA where T_TREEID='" + treeName + "' and T_ORGID='" + orgId + "' and T_FORMID='" + formID + "' order by I_LEVEL asc;";

            dt = dl.RunDataTable(sql, out errMsg);

            return dt;
        }

        /// <summary>
        /// 搜索公式
        /// </summary>
        /// <param name="treeName">组织机构数名称</param>
        /// <param name="orgId">组织机构编码</param>
        /// <param name="formID">表单编号</param>
        /// <param name="grade">优先级</param>
        /// <returns></returns>
        public DataTable GetFormGradeList(string treeName, string orgId, string formID, string grade)
        {
            sql = "select T_PARAID,T_PARAFIELD,T_FORMULA,T_FORMULAPARA,T_ORGID,I_ORDER From T_INFO_FORMPARA where T_TREEID='" + treeName + "' and T_ORGID='" + orgId + "' and T_FORMID='" + formID + "' and T_FORMULA!='';";

            dt = dl.RunDataTable(sql, out errMsg);

            return dt;
        }

        /// <summary>
        /// 获取组织机构数据  数据填报
        /// </summary>
        /// <param name="treeID">XML名称</param>
        /// <param name="orgID">组织机构编码</param>
        /// <param name="formId">表单编号</param>
        /// <param name="type">组织维度</param>
        /// <returns></returns>
        public DataTable GetDataOrgInfo(string treeID, string orgID, string formId, string type)
        {
            sql = "select T_PARAID  from T_INFO_FORMPARA where T_TREEID='" + treeID + "' and T_FORMID='" + formId + "' and T_ORGID='" + orgID + "' and T_PARATYPE='" + type + "'";

            dt = dl.RunDataTable(sql, out errMsg);

            return dt;
        }


        /// <summary>
        /// 获取组织机构数据  数据填报
        /// </summary>
        /// <param name="treeID">XML名称</param>
        /// <param name="orgID">组织机构编码</param>
        /// <param name="formId">表单编号</param>
        /// <param name="type">组织维度</param>
        /// <returns></returns>
        public DataTable GetDataParameter(string treeID, string orgID, string formId, string key)
        {
            sql = "select I_ORDER,T_PARAID  from T_INFO_FORMPARA where T_TREEID='" + treeID + "' and T_FORMID='" + formId + "' and T_ORGID='" + orgID + "' and T_PARAID in(" + key + ")";

            dt = dl.RunDataTable(sql, out errMsg);

            return dt;
        }

        #endregion

        #region 获取表单数据类型
        /// <summary>
        /// 获取表单数据类型
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="xmlName"></param>
        /// <param name="orgID"></param>
        /// <returns></returns>
        public DataTable GetDataType(string formID, string xmlName, string orgID)
        {
            sql = "select distinct T_TYPE from T_INFO_FORMPARA where T_FORMID='" + formID + "' and T_ORGID='" + orgID + "' and T_TREEID='" + xmlName + "'";

            dt = dl.RunDataTable(sql, out errMsg);

            return dt;
        }

        #endregion
    }
}