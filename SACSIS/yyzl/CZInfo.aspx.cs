using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAC.DBOperations;
using System.Data;
using System.Text;
using System.Collections;
using Newtonsoft.Json;

namespace SACSIS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string sql = "";
        string errMsg = "";
        double[] _cll = null;
        double[] _ywcl = null;
        double[] _nwcl = null;
        double[] _jzgzl = null;

        List<czInfo> czxxList = new List<czInfo>();
        DBLink dl = new DBLink();

        protected void Page_Load(object sender, EventArgs e)
        {
            string funCode = Request["funCode"];

            if (!string.IsNullOrWhiteSpace(funCode))
            {
                if (funCode == "init")
                {
                    LoadData();
                }
            }
        }

        /// <summary>
        /// 初始化场站信息
        /// </summary>
        private void LoadData()
        {
            sql = @"select * from ADMINISTRATOR.T_BASE_ORG";
            DataTable dt = dl.RunDataTable(sql, out errMsg);

            //把信息加载到czInfo类中
            GetCZInfo(dt);

            //排序
            SortCZList(czxxList);

            string data=ConvertDataTableFromList(czxxList);
           // string result = "{\"data\":" + data + "}";

            object _obj = new
            {
                data = data,
                cll = _cll,
                ywcl = _ywcl,
                nwcl = _nwcl,
                jzgzl = _jzgzl
            };
            string result = JsonConvert.SerializeObject(_obj);
            Response.Write(result);
            Response.End();
        }

        /// <summary>
        /// 将厂站类LIST转变为table
        /// </summary>
        /// <param name="czxxList"></param>
        /// <returns></returns>
        private string ConvertDataTableFromList(List<czInfo> czxxList)
        {
            StringBuilder htmlTable = new StringBuilder();
            htmlTable.Append("<table cellSpacing='0' cellPadding='0' width ='1700px' border='1'>");
            //标题行
            string strTitle = @"<tr><td rowspan='2' style='width:130px'>风电场</td><td colspan='2' style='width:60px'>装机情况</td><td colspan='4' >出力情况</td><td colspan='10' >电量情况</td><td colspan='8'>机组运行状态</td></tr>  <tr><td style='width:60px'>装机容量</td><td style='width:60px'>机型</td><td style='width:60px'>风速</td><td style='width:60px'>功率</td><td style='width:120px'>出力率</td><td style='width:60px'>限负荷</td><td style='width:60px'>日电量</td>    <td style='width:60px'>日等效利用小时</td>    <td style='width:60px'>月电量</td>    <td style='width:60px'>月计划</td>    <td style='width:120px'>月完成率</td>    <td style='width:60px'>月等效利用小时</td>    <td style='width:60px'>年累计</td>    <td style='width:60px'>年计划</td>    <td style='width:120px'>年完成率</td>    <td style='width:60px'>年等效利用小时</td>    <td style='width:60px'>总台数</td>    <td style='width:60px'>运行</td>    <td style='width:60px'>计划检修</td>    <td style='width:60px'>故障</td><td style='width:60px'>待机</td><td style='width:120px'>机组故障率</td><td style='width:60px'>机组状态排名</td><td style='width:60px'>出力率排名</td>  </tr> ";

            string strTr = "";

            _cll = new double[czxxList.Count];
            _ywcl = new double[czxxList.Count];
            _nwcl = new double[czxxList.Count];
            _jzgzl = new double[czxxList.Count];
            for (int z = 0; z < czxxList.Count; z++)
            { 
                //onMouseOver="this.className='over';" onMouseOut="this.className='out';"
                strTr += "<tr style='display:inline;' T_ORGID='" + czxxList[z].T_ORGID + "'";
                if (czxxList[z].T_PERIODID != null)
                {
                    strTr += "T_PERIODID='" + czxxList[z].T_PERIODID + "'>";
                    strTr += "<td style='text-align:left;'>&nbsp;" + czxxList[z].风电场 + "</td>";
                }
                else
                {
                    // strTr += " T_PERIODID='' onclick='HidenShowTr(this)' onMouseOver='MouseAct(this,1);' onMouseOut='MouseAct(this,2);'>";
                    strTr += " T_PERIODID='' onclick='HidenShowTr(this)'>";
                    strTr += "<td style='text-align:left;'><img id='" + czxxList[z].T_ORGID+ "_img' src='../img/bg10.png'>&nbsp;" + czxxList[z].风电场 + "</td>";
                }

                strTr += "<td>" + czxxList[z].装机容量 + "</td>";
                strTr += "<td>" + czxxList[z].机型 + "</td>";
                strTr += "<td>" + czxxList[z].风速 + "</td>";
                strTr += "<td>" + czxxList[z].功率 + "</td>";
                _cll[z] = czxxList[z].出力率;
                strTr += "<td><div id='cll_" + z + "'></div></td>";
                strTr += "<td>" + czxxList[z].限负荷 + "</td>";
                strTr += "<td>" + czxxList[z].日电量 + "</td>";
                strTr += "<td>" + czxxList[z].日等效利用小时 + "</td>";
                strTr += "<td>" + czxxList[z].月电量 + "</td>";
                strTr += "<td>" + czxxList[z].月计划 + "</td>";
                _ywcl[z] = czxxList[z].月完成率;
                strTr += "<td><div id='ywcl_" + z + "'></div></td>";
                strTr += "<td>" + czxxList[z].月等效利用小时 + "</td>";
                strTr += "<td>" + czxxList[z].年电量 + "</td>";
                strTr += "<td>" + czxxList[z].年计划 + "</td>";
                _nwcl[z] = czxxList[z].年完成率;
                strTr += "<td><div id='nwcl_" + z + "'></div></td>";
                strTr += "<td>" + czxxList[z].年等效利用小时 + "</td>";
                strTr += "<td>" + czxxList[z].总台数 + "</td>";
                strTr += "<td>" + czxxList[z].运行 + "</td>";
                strTr += "<td>" + czxxList[z].计划检修 + "</td>";
                strTr += "<td>" + czxxList[z].故障 + "</td>";
                strTr += "<td>" + czxxList[z].待机 + "</td>";
                _jzgzl[z] = czxxList[z].机组故障率;
                strTr += "<td><div id='jzgzl_" + z + "'></div></td>";
                strTr += "<td>" + czxxList[z].机组状态排名 + "</td>";
                strTr += "<td>" + czxxList[z].出力率排名 + "</td>";
                strTr += "</tr>";
            }

            string strEnd = "<tr><td>备注</td><td  colspan='24' style='text-align:left'>单位：功率(MW),风速(M/S),功率(KWh),率(%)</td></tr>";
            htmlTable.Append(strTitle);
            htmlTable.Append(strTr);
            htmlTable.Append(strEnd);
            htmlTable.Append("</table>");
            return htmlTable.ToString();
        }

        /// <summary>
        /// 排序加上排名信息
        /// </summary>
        /// <param name="czxxList"></param>
        private void SortCZList(List<czInfo> czxxList)
        {
            List<czInfo> fzList = czxxList.FindAll(a => a.T_PERIODID == "" || a.T_PERIODID == null);
            fzList.Sort(new cllCompar());
            fzList.Reverse();
            if (fzList.Count > 0)
            {
                czxxList.Find(a => a.T_ORGID == fzList[0].T_ORGID).出力率排名 = 1;
                if (fzList.Count > 1)
                {
                    int count = 2;
                    for (int y = 1; y < fzList.Count; y++)
                    {
                        if (fzList[y-1].出力率 == fzList[y].出力率)
                        {
                            czxxList.Find(a => a.T_ORGID == fzList[y].T_ORGID).出力率排名 = count;
                        }
                        else
                        {
                            czxxList.Find(a => a.T_ORGID == fzList[y].T_ORGID).出力率排名 = count;
                            count++; 
                        }
                    }
                }
            }

            List<czInfo> gqList = czxxList.FindAll(a => a.T_PERIODID != "" && a.T_PERIODID != null);
            for (int x = 0; x < fzList.Count; x++)
            {
                List<czInfo> gqListDetail = gqList.FindAll(a => a.T_ORGID == fzList[x].T_ORGID);
                gqListDetail.Sort(new cllCompar());
                gqListDetail.Reverse();
                if (gqListDetail.Count > 0)
                {
                    czxxList.Find(a => a.T_PERIODID == gqListDetail[0].T_PERIODID).出力率排名 = 1;
                    if (gqListDetail.Count > 1)
                    {
                        int countTwo = 2;
                        for (int p = 1; p < gqListDetail.Count; p++)
                        {
                            if (gqListDetail[p - 1].出力率 == gqListDetail[p].出力率)
                            {
                                czxxList.Find(a => a.T_PERIODID == gqListDetail[p].T_PERIODID).出力率排名 = countTwo;
                            }
                            else
                            {
                                czxxList.Find(a => a.T_PERIODID == gqListDetail[p].T_PERIODID).出力率排名 = countTwo;
                                countTwo++;
                            }
                        }
                    }
                }
            }


            //机组状态排序

            List<czInfo> fzList2 = czxxList.FindAll(a => a.T_PERIODID == "" || a.T_PERIODID == null);
            fzList2.Sort(new cllCompar());
            fzList2.Reverse();
            if (fzList2.Count > 0)
            {
                czxxList.Find(a => a.T_ORGID == fzList2[0].T_ORGID).机组状态排名 = 1;
                if (fzList2.Count > 1)
                {
                    int count = 2;
                    for (int y = 1; y < fzList2.Count; y++)
                    {
                        if (fzList2[y - 1].机组故障率 == fzList2[y].机组故障率)
                        {
                            czxxList.Find(a => a.T_ORGID == fzList2[y].T_ORGID).机组状态排名 = count;
                        }
                        else
                        {
                            czxxList.Find(a => a.T_ORGID == fzList2[y].T_ORGID).机组状态排名 = count;
                            count++;
                        }
                    }
                }
            }

            List<czInfo> gqList2 = czxxList.FindAll(a => a.T_PERIODID != "" && a.T_PERIODID != null);
            for (int x = 0; x < fzList2.Count; x++)
            {
                List<czInfo> gqList2Detail2 = gqList2.FindAll(a => a.T_ORGID == fzList2[x].T_ORGID);
                gqList2Detail2.Sort(new cllCompar());
                gqList2Detail2.Reverse();
                if (gqList2Detail2.Count > 0)
                {
                    czxxList.Find(a => a.T_PERIODID == gqList2Detail2[0].T_PERIODID).机组状态排名 = 1;
                    if (gqList2Detail2.Count > 1)
                    {
                        int countTwo = 2;
                        for (int p = 1; p < gqList2Detail2.Count; p++)
                        {
                            if (gqList2Detail2[p - 1].机组故障率 == gqList2Detail2[p].机组故障率)
                            {
                                czxxList.Find(a => a.T_PERIODID == gqList2Detail2[p].T_PERIODID).机组状态排名 = countTwo;
                            }
                            else
                            {
                                czxxList.Find(a => a.T_PERIODID == gqList2Detail2[p].T_PERIODID).机组状态排名 = countTwo;
                                countTwo++;
                            }
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// 获得场站信息
        /// </summary>
        /// <param name="dt"></param>
        private void GetCZInfo(DataTable dt)
        {
            DataTable Sdt = null;

            for (int a = 0; a < dt.Rows.Count; a++)
            {
                czInfo c = new czInfo();
                Sdt = dl.RunDataTable("select * from ADMINISTRATOR.T_BASE_PERIOD where T_ORGID='" + dt.Rows[a]["T_ORGID"] + "'", out errMsg);

                if (Sdt.Rows.Count > 0)
                {
                    if (Sdt.Rows.Count > 1)
                    {
                        c.T_ORGID = dt.Rows[a]["T_ORGID"].ToString();
                        c.风电场 = dt.Rows[a]["T_ORGDESC"].ToString();
                        GetStr(dt.Rows[a]["T_ORGID"].ToString(), "1", c);
                        for (int b = 0; b < Sdt.Rows.Count; b++)
                        {
                            c = new czInfo();
                            c.T_ORGID = dt.Rows[a]["T_ORGID"].ToString();
                            c.T_PERIODID = Sdt.Rows[b]["T_PERIODID"].ToString();
                            c.风电场 = Sdt.Rows[b]["T_PERIODDESC"].ToString();
                            GetStr(Sdt.Rows[b]["T_PERIODID"].ToString(), "2", c);
                        }
                    }
                    else
                    {
                        if (Sdt.Rows[0]["T_PERIODDESC"].ToString() == "全部")
                        {
                            c = new czInfo();
                            c.T_ORGID = dt.Rows[a]["T_ORGID"].ToString();
                            c.风电场 = dt.Rows[a]["T_ORGDESC"].ToString();
                            GetStr(dt.Rows[a]["T_ORGID"].ToString(), "1", c);
                        }
                        else
                        {
                            c = new czInfo();
                            c.T_ORGID = dt.Rows[a]["T_ORGID"].ToString();
                            c.T_PERIODID = Sdt.Rows[0]["T_PERIODID"].ToString();
                            c.风电场 = Sdt.Rows[0]["T_PERIODDESC"].ToString();
                            GetStr(Sdt.Rows[0]["T_PERIODID"].ToString(), "2", c);
                        }
                    }
                }
                else
                {
                    c = new czInfo();
                    c.T_ORGID = dt.Rows[a]["T_ORGID"].ToString();
                    c.风电场 = dt.Rows[a]["T_ORGDESC"].ToString();
                    GetStr(dt.Rows[a]["T_ORGID"].ToString(), "1", c);
                }
            }
        }

        /// <summary>
        /// 把信息加载到场站类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typ"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private string GetStr(string id,string typ,czInfo c)
        {
            //装机容量	机型	风速	功率	限负荷	日电量	日等效利用小时	月电量	月计划	月完成率	月等效利用小时	年累计	年计划	年完成率	年等效利用小时	总台数	运行	计划检修	故障	待机	机组故障率	机组状态排名	出力率排名
            string s = "";

            //装机容量
            if (typ == "1")
                sql = @"SELECT SUM(INT(容量)) FROM            
                (select t.T_ORGID T_PERIODID,(select p.T_ORGID from ADMINISTRATOR.T_BASE_PERIOD p where p.T_PERIODID=t.T_ORGID) T_ORGID,t.容量
                from ADMINISTRATOR.T_INFO_RL t )
                where T_ORGID='" + id + "'";
            else
                sql = "select sum(int(容量)) from ADMINISTRATOR.T_INFO_RL  where T_ORGID='" + id + "'";

            object o = dl.RunSingle(sql, out errMsg);

            if (o == null)
                s += "<td></td>";
            else
            {
                s += "<td>" + o.ToString() + "</td>";
                c.装机容量 = double.Parse(o.ToString());
            }


            //机型
            sql = @"select DISTINCT T_COMPANYDESC from
                    (SELECT * FROM (select t.T_MACHINEID,t.T_PERIODID,(select T_ORGID from ADMINISTRATOR.T_BASE_PERIOD p where p.T_PERIODID=t.T_PERIODID) T_ORGID,
                    (select T_COMPANYDESC from  ADMINISTRATOR.T_BASE_MACHINE m where m.T_MACHINEID=t.T_MACHINEID )
                    from ADMINISTRATOR.T_BASE_UNIT t) WHERE ";

            if (typ == "1")
                sql += "T_ORGID='" + id + "') ";
            else
                sql += "T_PERIODID='" + id + "') ";

            DataTable jxDt = dl.RunDataTable(sql, out errMsg);
            s += "<td>";
            string jx = "";
            if (jxDt.Rows.Count > 0)
            {
                for (int n = 0; n < jxDt.Rows.Count; n++)
                {
                    s += jxDt.Rows[n]["T_COMPANYDESC"].ToString() + ",";
                    jx += jxDt.Rows[n]["T_COMPANYDESC"].ToString() + ",";
                }
                s = s.Substring(0, s.Length - 1);
                jx = jx.Substring(0, jx.Length - 1);
            }
            c.机型 = jx;
            s += "</td>";


            //风速 测点

            s += "<td></td>";


            //功率 

            s += "<td></td>";


            //出力率
            //s += "<td><table   style='width:100px' ><tr  ><td style='width: 80%;background-color:red;'></td><td style='width: 20%;background-color:black;'> </td></tr></table></td>";
           // s += "<td><div class='easyui-progressbar' style='width:200px;'></div></td>";

            //限负荷
            s += "<td></td>";



            //日电量
            object rdl = GetDl(id, typ, 1);
            if (rdl == null)
                s += "<td></td>";
            else
            {
                s += "<td>" + rdl.ToString() + "</td>";
                c.日电量 = double.Parse(rdl.ToString());
            }


            //日等效利用小时
            if (o == null || rdl == null)
                s += "<td></td>";
            else
            {
                s += "<td>" + Math.Round(double.Parse(rdl.ToString()) / double.Parse(o.ToString()), 2) + "</td>";
                c.日等效利用小时 = Math.Round(double.Parse(rdl.ToString()) / double.Parse(o.ToString()), 2);
            }


            //月电量
            object ydl = GetDl(id, typ, 2);
            if (ydl == null)
                s += "<td></td>";
            else
            {
                s += "<td>" + ydl.ToString() + "</td>";
                c.月电量 = double.Parse(ydl.ToString());
            }

            //月计划  
            object yjh = GetJHDl(id,typ,1);
            if (yjh == null)
                s += "<td></td>";
            else
            {
                s += "<td>" + yjh.ToString() + "</td>";
                c.月计划 = double.Parse(yjh.ToString());
            }


            //月完成率
            if (ydl == null || yjh == null)
                s += "<td></td>";
            else
            {
                s += "<td>" + Math.Round(double.Parse(ydl.ToString()) / double.Parse(yjh.ToString()), 2) + "</td>";

                c.月完成率 = Math.Round(double.Parse(ydl.ToString()) / double.Parse(yjh.ToString()), 2);
            }


            //月等效利用小时
            if (ydl == null || o == null)
                s += "<td></td>";
            else
            {
                s += "<td>" + Math.Round(double.Parse(ydl.ToString()) / double.Parse(o.ToString()), 2) + "</td>";
                c.月等效利用小时 = Math.Round(double.Parse(ydl.ToString()) / double.Parse(o.ToString()), 2);
            }


            //年电量
            object ndl = GetDl(id, typ, 3);
            if (ndl == null)
                s += "<td></td>";
            else
            {
                s += "<td>" + ndl.ToString() + "</td>";
                c.年电量 = double.Parse(ndl.ToString());
            }

            //年计划  
            object njh = GetJHDl(id, typ, 2);
            if (yjh == null)
                s += "<td></td>";
            else
            {
                s += "<td>" + njh.ToString() + "</td>";
                c.年计划 = double.Parse(njh.ToString());
            }


            //年完成率
            if (ndl == null || njh == null)
                s += "<td></td>";
            else
            {
                s += "<td>" + Math.Round(double.Parse(ndl.ToString()) / double.Parse(njh.ToString()), 2) + "</td>";
                c.年完成率 = Math.Round(double.Parse(ndl.ToString()) / double.Parse(njh.ToString()), 2);
            }


            //年等效利用小时
            if (ndl == null || o == null)
                s += "<td></td>";
            else
            {
                s += "<td>" + Math.Round(double.Parse(ndl.ToString()) / double.Parse(o.ToString()), 2) + "</td>";
                c.年等效利用小时 = Math.Round(double.Parse(ndl.ToString()) / double.Parse(o.ToString()), 2);
            }



            //总台数
            s += "<td></td>";

            //运行
            s += "<td></td>";

            //计划检修
            s += "<td></td>";

            //故障
            s += "<td></td>";

            //待机 
            s += "<td></td>";

            //机组故障率
            s += "<td></td>";


            //机组状态排名


            //出力率排名 


            czxxList.Add(c);
            return s ;
        }

        /// <summary>
        /// 获取电量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typ">1：风场 2：工期</param>
        /// <param name="p">1:日 2：月 3：年</param>
        /// <returns></returns>
        private object GetDl(string id, string typ, int p)
        {
            sql = "select sum(D_VALUE) from ADMINISTRATOR.T_INFO_STATISCS where T_TJID='DL' and ";

            if (typ == "1")
                sql += "T_ORGID='" + id + "'";
            else
                sql += "T_PERIODID='" + id + "'";

            string sTime = "";
            string etime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (p == 1)
            {
                sTime = DateTime.Now.ToString("yyyy-MM-dd 0:00:00");
            }
            if (p == 2)
            {
                sTime = DateTime.Now.ToString("yyyy-MM-01 0:00:00");
            }
            if (p == 3)
            {
                sTime = DateTime.Now.ToString("yyyy-01-01 0:00:00");
            }

            sql += " and T_TIME>='" + sTime + "' and T_TIME<='" + etime + "'";

            return dl.RunSingle(sql, out errMsg);
        }

        /// <summary>
        /// 获取计划电量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typ"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private object GetJHDl(string id, string typ, int p)
        {
            sql = @"SELECT SUM(月计划电量) FROM            
                        (select t.T_ORGID T_PERIODID,t.T_TIME,(select p.T_ORGID from ADMINISTRATOR.T_BASE_PERIOD p where p.T_PERIODID=t.T_ORGID) T_ORGID,t.月计划电量
                        from ADMINISTRATOR.T_INFO_YJHDL t )
                        where ";
            if (typ == "1")
                sql += "T_ORGID='" + id + "'";
            else
                sql += "T_PERIODID='" + id + "'";

            if (p == 1)
            {
                sql += " and T_TIME='" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-01 0:00:00'";
            }
            if (p == 2)
            {
                sql += " and T_TIME>='" + DateTime.Now.Year + "-01-01 0:00:00' and T_TIME<='" + DateTime.Now.Year + "-12-01 0:00:00'";
            }

            return dl.RunSingle(sql, out errMsg);
        }


        public class jzztCompar : IComparer<czInfo>
        {
            public int Compare(czInfo x, czInfo y)
            {
                return x.机组故障率.CompareTo(y.机组故障率);
            }
        }

        public class cllCompar : IComparer<czInfo>
        {
            public int Compare(czInfo x, czInfo y)
            {
                return x.出力率.CompareTo(y.出力率);
            }
        }
    }
}