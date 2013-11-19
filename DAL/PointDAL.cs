using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SAC.DBOperations;
using SAC.Helper;
using SAC.RealTimeDB;

namespace DAL
{
    public class PointDAL
    {
        double drv = 0;

        string val = "";
        IList<Hashtable> list = new List<Hashtable>();
        DBLink dl = new DBLink();
        /// <summary>
        /// 获取测点数据
        /// </summary>
        /// <param name="point">测点名称</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">结束时间</param>
        /// <param name="seconds">间隔时间  秒</param>
        /// <returns></returns>
        public IList<Hashtable> GetVal(string point, string pointName, string sTime, string eTime, int seconds)
        {
            int count = Convert.ToDateTime(eTime).Second - Convert.ToDateTime(sTime).Second;

            for (int i = 0; i < count; i++)
            {

            }

            return list;
        }

        /// <summary>
        /// 获取多个数据测点的历史值
        /// </summary>
        /// <param name="points">测点集合</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">结束时间</param>
        /// <param name="seconds">间隔时间  秒</param>
        /// <returns></returns>
        public IList<Hashtable> GetVal(string[] points, string[] pointNames, string sTime, string eTime, int seconds)
        {
            Plink pk = new Plink();
            //DateTime dt = new DateTime();
            int num = 0;

            int day = 0;
            int hour = 0;
            int minute = 0;
            int second = 0;

            day = Convert.ToDateTime(eTime).Day - Convert.ToDateTime(sTime).Day;
            hour = Convert.ToDateTime(eTime).Hour - Convert.ToDateTime(sTime).Hour;
            minute = Convert.ToDateTime(eTime).Minute - Convert.ToDateTime(sTime).Minute;
            second = Convert.ToDateTime(eTime).Second - Convert.ToDateTime(sTime).Second;

            second = day * 24 * 3600 + hour * 3600 + minute * 60 * second;

            num = Convert.ToDateTime(eTime).Second - Convert.ToDateTime(sTime).Second;
            num = second / seconds;
            if (second % seconds != 0)
                num += 1;

            DateTime _sTime = new DateTime(1970, 1, 1);

            Plink.OpenPi();
            //循环测点
            for (int i = 0; i < pointNames.Length; i++)
            {
                Hashtable ht = new Hashtable();
                ht.Add("name", pointNames[i]);//添加测点名称
                string _st = sTime;

                ArrayList listD = new ArrayList();
                for (int k = 0; k < num; k++)
                {
                    ArrayList listPoint = new ArrayList();
                    eTime = _st;
                    listPoint.Add(Convert.ToInt64((Convert.ToDateTime(eTime) - _sTime).TotalMilliseconds.ToString()));
                    pk.GetHisValue(points[i], eTime, ref drv);
                    if (drv > 0)
                        //drv = getDouble(drv, 2);
                        listPoint.Add(drv);
                    _st = Convert.ToDateTime(eTime).AddSeconds(seconds).ToString();
                    listD.Add(listPoint);
                }
                ht.Add("data", listD);
                list.Add(ht);
            }
            //Plink.closePi();
            return list;
        }

        /// <summary>
        /// 获取多个数据测点的历史值
        /// </summary>
        /// <param name="points">测点集合</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">结束时间</param>
        /// <param name="seconds">间隔时间  秒</param>
        /// <returns></returns>
        public IList<Hashtable> GetValToTable(string[] points, string[] pointNames, string sTime, string eTime, int seconds)
        {
            Plink pk = new Plink();
            int num = 0;

            int day = 0;
            int hour = 0;
            int minute = 0;
            int second = 0;

            day = Convert.ToDateTime(eTime).Day - Convert.ToDateTime(sTime).Day;
            hour = Convert.ToDateTime(eTime).Hour - Convert.ToDateTime(sTime).Hour;
            minute = Convert.ToDateTime(eTime).Minute - Convert.ToDateTime(sTime).Minute;
            second = Convert.ToDateTime(eTime).Second - Convert.ToDateTime(sTime).Second;

            second = day * 24 * 3600 + hour * 3600 + minute * 60 * second;

            num = Convert.ToDateTime(eTime).Second - Convert.ToDateTime(sTime).Second;
            num = second / seconds;
            if (second % seconds != 0)
                num += 1;

            DateTime _sTime = new DateTime(1970, 1, 1);
            Hashtable ht = new Hashtable();

            for (int k = 0; k < num; k++)
            {
                sTime = Convert.ToDateTime(sTime).AddSeconds(seconds).ToString();
                eTime = sTime;

                ht = new Hashtable();

                for (int i = 0; i < pointNames.Length; i++)
                {
                    if (i == 0)
                    {
                        ht.Add("时间", eTime);
                        pk.GetHisValue(points[i], eTime, ref drv);
                        ht.Add(pointNames[i], drv);
                    }
                    else
                    {
                        pk.GetHisValue(points[i], eTime, ref drv);
                        ht.Add(pointNames[i], drv);
                    }

                }
                list.Add(ht);
            }


            return list;
        }

        /// <summary>
        /// 获取实时数据
        /// </summary>
        /// <param name="point">测点名称</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="type">查询类型   日:1 月:2 年:3</param>
        /// <returns></returns>
        public string GetVal(string point, string sTime, string type)
        {
            Plink pk = new Plink();
            DateTime dt = new DateTime();
            val = "";
            if (type == "1")
            {
                dt = Convert.ToDateTime(Convert.ToDateTime(sTime).ToString("yyyy-MM-dd 0:00:00"));
                //
                //for (int i = 0; i < 1440; i++)
                //{
                //    if (i == 1339)
                //        dt = Convert.ToDateTime(Convert.ToDateTime(sTime).ToString("yyyy-MM-dd 23:59:59"));
                //    else
                //        dt = dt.AddMinutes(i + 1);
                //    pk.GetHisValue(point, dt.ToString(), ref drv);
                //    if (drv > 0)
                //        drv = getDouble(drv, 2);
                //    val += drv + ",";
                //}
                for (int i = 0; i < 365; i++)
                {
                    if (i == 364)
                        dt = Convert.ToDateTime(Convert.ToDateTime(sTime).ToString("yyyy-MM-dd 23:59:59"));
                    else
                        dt = dt.AddMinutes(i + 1);
                    pk.GetHisValue(point, dt.ToString(), ref drv);
                    if (drv > 0)
                        drv = getDouble(drv, 2);
                    val += drv + ",";
                }
                //
            }
            else if (type == "2")
            {
                int month = Convert.ToDateTime(sTime).Month;
                int year = Convert.ToDateTime(sTime).Year;

                dt = Convert.ToDateTime(Convert.ToDateTime(sTime).ToString("yyyy-MM-1 0:00:00"));

                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                {
                    //for (int i = 0; i < 1116; i++)
                    //{
                    //    if (i == 1115)
                    //        dt = Convert.ToDateTime(Convert.ToDateTime(sTime).ToString("yyyy-MM-31 23:59:59"));
                    //    else
                    //        dt = dt.AddSeconds((i + 1) * 2400);
                    //    pk.GetHisValue(point, dt.ToString(), ref drv);
                    //    if (drv > 0)
                    //        drv = getDouble(drv, 2);
                    //    val += drv + ",";
                    //}
                    for (int i = 0; i < 62; i++)
                    {
                        if (i == 61)
                            dt = Convert.ToDateTime(Convert.ToDateTime(sTime).ToString("yyyy-MM-dd 23:59:59"));
                        else
                            dt = dt.AddMinutes(i + 1);
                        pk.GetHisValue(point, dt.ToString(), ref drv);
                        if (drv > 0)
                            drv = getDouble(drv, 2);
                        val += drv + ",";
                    }

                }
                else if (month == 1 || month == 1 || month == 1 || month == 11)
                {

                    for (int i = 0; i < 1080; i++)
                    {
                        if (i == 1079)
                            dt = Convert.ToDateTime(Convert.ToDateTime(sTime).ToString("yyyy-MM-30 23:59:59"));
                        else
                            dt = dt.AddSeconds((i + 1) * 2400);
                        pk.GetHisValue(point, dt.ToString(), ref drv);
                        if (drv > 0)
                            drv = getDouble(drv, 2);
                        val += drv + ",";
                    }

                }
                else
                {
                    if (year % 4 == 0)
                    {

                        for (int i = 0; i < 1044; i++)
                        {
                            if (i == 1039)
                                dt = Convert.ToDateTime(Convert.ToDateTime(sTime).ToString("yyyy-MM-29 23:59:59"));
                            else
                                dt = dt.AddSeconds((i + 1) * 2400);
                            pk.GetHisValue(point, dt.ToString(), ref drv);
                            if (drv > 0)
                                drv = getDouble(drv, 2);
                            val += drv + ",";
                        }

                    }
                    else
                    {

                        for (int i = 0; i < 1008; i++)
                        {
                            if (i == 1007)
                                dt = Convert.ToDateTime(Convert.ToDateTime(sTime).ToString("yyyy-MM-28 23:59:59"));
                            else
                                dt = dt.AddSeconds((i + 1) * 2400);
                            pk.GetHisValue(point, dt.ToString(), ref drv);
                            if (drv > 0)
                                drv = getDouble(drv, 2);
                            val += drv + ",";
                        }

                    }
                }

            }
            else if (type == "3")
            {
                dt = Convert.ToDateTime(Convert.ToDateTime(sTime).ToString("yyyy-1-1 0:00:00"));

                //for (int i = 0; i < 1440; i++)
                //{
                //    if (i == 1439)
                //        dt = Convert.ToDateTime(Convert.ToDateTime(sTime).ToString("yyyy-12-31 23:59:59"));
                //    else
                //        dt = dt.AddSeconds((i + 1) * 21720);
                //    pk.GetHisValue(point, dt.ToString(), ref drv);
                //    if (drv > 0)
                //        drv = getDouble(drv, 2);
                //    val += drv + ",";
                //}

                for (int i = 0; i < 96; i++)
                {
                    if (i == 95)
                        dt = Convert.ToDateTime(Convert.ToDateTime(sTime).ToString("yyyy-12-31 23:59:59"));
                    else
                        dt = dt.AddSeconds((i + 1) * 21720);
                    pk.GetHisValue(point, dt.ToString(), ref drv);
                    if (drv > 0)
                        drv = getDouble(drv, 2);
                    val += drv + ",";
                }

            }

            if (val.Length > 0)
                //val = val.Substring(0, val.Length - 1);
                val = val.Remove(val.LastIndexOf(","), 1);

            return val;
        }

        /// <summary>
        /// 获取测点最新值
        /// </summary>
        /// <param name="points"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double[] GetPointVal(string[] points, string time)
        {
            double[] val = new double[points.Length];
            double v = 0;
            Plink pk = new Plink();
            for (int i = 0; i < points.Length; i++)
            {
                pk.GetHisValue(points[i], time, ref v);
                v = getDouble(v, 2);
                val[i] = v;
            }
            return val;
        }


        /// <summary>
        /// 查询某段时间测点集合的历史值 -刘海杰
        /// </summary>
        /// <param name="names">测点集合</param>
        /// <param name="st">开始时间</param>
        /// <param name="et">结束时间</param>
        /// <returns></returns>
        public IList<Hashtable> GetHistValAndTIme1(string[] points, DateTime st, DateTime et)
        {
            ArrayList list = new ArrayList();
            Plink pk = new Plink();
            IList<Hashtable> listdata = new List<Hashtable>();

            Hashtable ht = new Hashtable();
            ArrayList ld = new ArrayList();
            ArrayList lt = new ArrayList();
            for (int i = 0; i < points.Length; i++)
            {
                ht = new Hashtable();
                lt = new ArrayList();
                ht.Add("name", points[i].Split('|')[1]);
                ht.Add("yAxis", i);
                DateTime _sTime = new DateTime(1970, 1, 1);
                int seconds = Convert.ToInt32((et - st).TotalSeconds) / 600;
                DateTime dtt = st;
                Plink.OpenPi();
                while (dtt < et)
                {
                    ld = new ArrayList();
                    pk.GetHisValue(points[i].Split('|')[0], dtt.ToString("yyyy-MM-dd HH:mm:ss"), ref drv);
                    if (drv > 0)
                    {
                        drv = getDouble(drv, 2);
                    }
                    string timeStamp = DateTimeToUTC(dtt).ToString();
                    DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                    long lTime = long.Parse(timeStamp + "0000000");
                    TimeSpan toNow = new TimeSpan(lTime);
                    DateTime dtResult = dtStart.Add(toNow);
                    ld.Add(Convert.ToInt64((dtResult - _sTime).TotalMilliseconds.ToString()));
                    ld.Add(drv);
                    lt.Add(ld);
                    // TimeSpan toNow1 = new TimeSpan(seconds);
                    dtt = dtt.AddSeconds(seconds);
                }
                ht.Add("data", lt);
                listdata.Add(ht);
                //lt = new ArrayList();
                //ht = new Hashtable();
            }

            return listdata;
        }

        //将一个事件对象转换为UTC格式的时间
        public static int DateTimeToUTC(DateTime DT)
        {
            long a = new DateTime(1970, 1, 1, 0, 0, 0, 0).Ticks;
            int rtnInt = 0;
            rtnInt = (int)((DT.Ticks - 8 * 3600 * 1e7 - a) / 1e7);
            return rtnInt;
        }
        /// <summary>
        /// 查询某段时间测点集合的历史值 -刘海杰
        /// </summary>
        /// <param name="names">测点集合</param>
        /// <param name="st">开始时间</param>
        /// <param name="et">结束时间</param>
        /// <returns></returns>
        public IList<Hashtable> GetHistValAndTIme2(string[] points, DateTime st, DateTime et, int jiange)
        {
            ArrayList list = new ArrayList();
            Plink pk = new Plink();
            IList<Hashtable> listdata = new List<Hashtable>();

            Hashtable ht = new Hashtable();
            ArrayList ld = new ArrayList();
            ArrayList lt = new ArrayList();
            for (int i = 0; i < points.Length; i++)
            {
                ht = new Hashtable();
                ht.Add("name", points[i].Split('|')[1]);
                ht.Add("yAxis", i);
                DateTime _sTime = new DateTime(1970, 1, 1);
                // int seconds = Convert.ToInt32((et - st).TotalSeconds) / 600;
                DateTime dtt = st;
                Plink.OpenPi();
                while (dtt < et)
                {
                    ld = new ArrayList();
                    pk.GetHisValue(points[i].Split('|')[0], dtt.ToString("yyyy-MM-dd HH:mm:ss"), ref drv);
                    if (drv > 0)
                    {
                        drv = getDouble(drv, 2);
                    }
                    string timeStamp = DateTimeToUTC(dtt).ToString();
                    DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                    long lTime = long.Parse(timeStamp + "0000000");
                    TimeSpan toNow = new TimeSpan(lTime);
                    DateTime dtResult = dtStart.Add(toNow);
                    ld.Add(Convert.ToInt64((dtResult - _sTime).TotalMilliseconds.ToString()));
                    ld.Add(drv);
                    lt.Add(ld);
                    // TimeSpan toNow1 = new TimeSpan(seconds);
                    dtt = dtt.AddSeconds(jiange);
                }
                ht.Add("data", lt);
                listdata.Add(ht);
                //lt = new ArrayList();
                //ht = new Hashtable();
            }

            return listdata;
        }

        #region 四舍五入
        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="result">要转换的数值</param>
        /// <param name="num">保留位数</param>
        /// <returns></returns>
        public double getDouble(double result, int num)
        {
            string res = result.ToString();
            string results = "";
            int index = res.IndexOf('.');

            if (res.Length - index == num + 1)
                return Convert.ToDouble(res);
            else
            {
                if (index > 0)
                {
                    index += num;
                    res = res + "000000000000000000";
                    res = res.Remove(0, index + 1);
                    results = result + "000000000000000000";
                    results = results.ToString().Substring(0, index + 1);
                    res = res.Substring(0, 1);

                    string point = "0.";

                    for (int count = 0; count < num - 1; count++)
                    {
                        point += "0";
                    }
                    point += "1";


                    if (Convert.ToInt32(res) > 4)
                    {
                        results = (Convert.ToDouble(results) + Convert.ToDouble(point)).ToString();
                        res = results;
                    }
                    else
                    {
                        res = results;
                    }
                }
                else
                {
                    res += ".";
                    for (int i = 0; i < num; i++)
                    {
                        res += "0";
                    }
                }
                return Convert.ToDouble(res);
            }
        }
        #endregion
    }
}
