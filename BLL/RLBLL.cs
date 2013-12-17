using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public class RLBLL
    {
        private RLDAL dl = new RLDAL();

        #region 获取容量
        /// <summary>
        /// 获取容量
        /// </summary>
        /// <param name="id">工期</param>
        /// <returns></returns>
        public DataTable GetRL(string id)
        {
            return dl.GetRL(id);
        }
        #endregion
    }
}
