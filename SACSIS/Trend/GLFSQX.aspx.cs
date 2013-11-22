using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Collections;
using BLL;
using Newtonsoft.Json;
using System.Text;

namespace SACSIS.Trend
{
    public partial class GLFSQX : System.Web.UI.Page
    {
        private static string _xml = "FD";
        //private PeriodBLL _pd = new PeriodBLL();
        private WppBLL _wd = new WppBLL();
        //private PointBLL _pb = new PointBLL();
        private string result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string param = Request["param"];
            if (param != "")
            {
                if (param == "line")
                {
                    //string tyep = Request["type"];
                    string gq = Request["gq"];
                    string sTime = Request["sTime"];
                    string eTime = Request["eTime"];
                    string idpt = HttpUtility.UrlDecode(Request["id_pt"]);
                    string namept = HttpUtility.UrlDecode(Request["name_pt"]);
                    GetList(idpt,namept, sTime, eTime, gq);
                }
                else if (param == "Init")
                {
                    GetInit();
                }
                else if (param == "unit")
                {
                    string id = Request["id"];
                    GetUnit(id);
                }
            }
            else
            {
                _xml = "FD";// Request["XML"];
            }
            txtS.Value = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 0:00:00");
            txtE.Value = DateTime.Now.ToString("yyyy-MM-dd 0:00:00");
        }

        #region 获取机组数据
        private void GetUnit(string gq)
        {
            IList<Hashtable> list = new List<Hashtable>();
            list = _wd.GetUnits(gq);
            string _treePt_Info = "";
            if (list != null)
            {
                _treePt_Info += "{id:'0',pId:'00',name:'风机',t:'风机', open:true},";
                foreach (Hashtable ht in list)
                {
                        _treePt_Info += "{id:'" + ht["T_UNITID"] + "',pId:'0',name:'" + ht["T_UNITDESC"] + "',t:'" + ht["T_UNITDESC"] + "'},";
                }
                if (_treePt_Info.Length > 0)
                {
                    _treePt_Info = _treePt_Info.Substring(0, _treePt_Info.Length - 1);
                    _treePt_Info = "[" + _treePt_Info + "]";
                }
            }
            object obj = new
            {
                infoPt = _treePt_Info
            };
            result = JsonConvert.SerializeObject(obj);
            Response.Write(result);
            Response.End();
        }
        #endregion

        private void GetList(string idpt, string namept, string sTime, string eTime, string gq)
        {
            IList<Hashtable> listTitle = new List<Hashtable>();  //Table表格存放列名
            IList<Hashtable> listData = new List<Hashtable>();   //Table 表格具体数据
            IList<Hashtable> list = new List<Hashtable>();

            if (idpt.Length > 0)
            {
                idpt = idpt.Substring(0, idpt.Length - 1);
                namept = namept.Substring(0, namept.Length - 1);
            }

            /*Hashtable timeht = new Hashtable();
            timeht.Add("时间", "时间");
            listTitle.Add(timeht);

            for (int i = 0; i < namept.Split(',').Length; i++)
            {
                Hashtable ht = new Hashtable();
                ht.Add(namept.Split(',')[i], namept.Split(',')[i]);
                listTitle.Add(ht);
            }*/
            Hashtable htSpeed = new Hashtable();
            Hashtable htPower = new Hashtable();
            DataTable _dtMachineID = _wd.GetMachineID(idpt,gq);
            string _machineIDs = "";
            if (_dtMachineID != null)
            {
                //string[] _machineIDs = new string[_dtMachineID.Rows.Count];
                
                for (int i = 0; i < _dtMachineID.Rows.Count; i++)
                {
                    _machineIDs += _dtMachineID.Rows[i][0].ToString();
                }
            }
            DataTable _dtNormWpp = _wd.GetWppNWSpeed(_machineIDs);//T_BASE_NORMWPP 表中的数据
            list=GetListTable(_dtNormWpp);
            if (_dtNormWpp.Rows.Count > 0)
            {
                
                for (int i = 0; i < _dtNormWpp.Rows.Count; i++)
                {
                    string a = _dtNormWpp.Rows[i][1].ToString();
                    htSpeed.Add(i, _dtNormWpp.Rows[i][0].ToString());
                    htPower.Add(i, _dtNormWpp.Rows[i][1].ToString());
                }
            }
            /*string[] idpts=idpt.Split(',');
            for (int i = 0; i < idpt.Split(',').Length ; i++)
            {
                string idptss=idpts[i].Substring(1,idpts[i].Length-1);
                DataTable _dtInfoWpp = _wd.GetInfoWppNWSpeed(idptss, gq, sTime, eTime);//T_BASE_NORMWPP 表中的数据

            }*/

            list.Add(htPower);
            object obj = new
            {
                columns = ListToString(listTitle),
                rows = listData,
                list = list,
            };

            string result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            Response.Write(result);
            Response.End();
        }

        public List<Hashtable> GetListTable(DataTable dt) 
        { 
            List<Hashtable> mList = new List<Hashtable>(); 
            int count = dt.Rows.Count; 
            if (count > 0) 
            { 
                for (int i = 0; i <= count - 1; i++) 
                { 
                    Hashtable ht = new Hashtable(); 
                    foreach (DataColumn col in dt.Columns) 
                    { 
                        ht.Add(col.ColumnName, dt.Rows[i][col.ColumnName]); 
                    } 
                    mList.Add(ht); 
                } 
            } 
            return mList; 
        }


        private string ListToString(IList<Hashtable> iList)
        {
            int width = 0;
            StringBuilder columns = new StringBuilder("[[");

            if (iList.Count > 0)
            {
                //Hashtable ht = iList[0];

                foreach (Hashtable ht in iList)
                {

                    ArrayList list = new ArrayList(ht.Keys);
                    foreach (string skey in list)
                    {
                        if (skey.ToString() == "时间")
                        {
                            width = 120;
                        }
                        else
                        {
                            width = 103;
                        }
                        columns.AppendFormat("{{field:'{0}',title:'{1}',align:'center',width:{2}}},", skey, skey, width);
                    }
                }
            }
            if (iList.Count > 0)
            {
                columns.Remove(columns.Length - 1, 1);//去除多余的','号  
            }
            columns.Append("]]");
            return columns.ToString();
        }

        #region 获取风场  工期  机组信息
        Hashtable _ht = null;
        private void GetInit()
        {
            DataTable _dtXml = GetDataTableXml(_xml);
            DataRow[] _drXml = _dtXml.Select("PID=10001");

            IList<Hashtable> _company = new List<Hashtable>();  //公司
            IList<Hashtable> _fc = new List<Hashtable>();       //风场
            string _str_b = "";
            string _str_f = "";
            if (_drXml.Length > 0)
            {
                for (int i = 0; i < _drXml.Length; i++)
                {
                    _ht = new Hashtable();
                    _ht.Add("ID", _drXml[i][0].ToString());     //公司编码
                    _ht.Add("NAME", _drXml[i][1].ToString());   //公司名称
                    _company.Add(_ht);
                }

                string _companyId = _drXml[0][0].ToString();
                _fc = _wd.GetPeriod(_companyId);

                if (_fc != null)
                {
                    _ht = new Hashtable();
                    _ht = _fc[0];

                    string _pid = _ht["T_PERIODID"].ToString();
                    DataTable _dtUnit = _wd.GetUnit(_pid);
                    if(_dtUnit.Rows.Count>0)
                    {
                         _str_f += "{id:'0',pId:'00',name:'普通风机',t:'普通风机', open:true},";
                        for (int i = 0; i < _dtUnit.Rows.Count; i++)
                        {
                            _str_f += "{id:'" + _dtUnit.Rows[i]["T_UNITID"] + "',pId:'0',name:'" + _dtUnit.Rows[i]["T_UNITDESC"] + "',t:'" + _dtUnit.Rows[i]["T_UNITDESC"] + "', open:true},";
                        }
                    }
                }
            }
            if (_str_f != "")
            {
                _str_f = _str_f.Substring(0, _str_f.Length - 1);
                _str_f = "[" + _str_f + "]";
            }

            object obj = new
            {
                list = _company,
                listB = _str_b,
                listF = _str_f,
                lt = _fc
            };
            result = JsonConvert.SerializeObject(obj);
            Response.Write(result);
            Response.End();

        }
        #endregion

        #region XML 操作

        private static DataTable dt = new DataTable();

        #region 将XML转换成DataTable

        private DataTable GetDataTableXml(string xmlName)
        {
            dt = new DataTable();
            if (xmlName != "")
            {
                //XmlTextReader reader = new XmlTextReader(Server.MapPath("Xml/" + xmlName + ".xml"));
                XmlTextReader reader = new XmlTextReader(Server.MapPath("../Xml/" + xmlName + ".xml"));
                reader.WhitespaceHandling = WhitespaceHandling.None;
                XmlDocument xmlDoc = new XmlDocument();
                //将文件加载到XmlDocument对象中
                xmlDoc.Load(reader);

                //关闭连接
                reader.Close();

                XmlNode xnod = xmlDoc.DocumentElement;

                if (!dt.Columns.Contains("ID"))
                    dt.Columns.Add("ID");
                if (!dt.Columns.Contains("NAME"))
                    dt.Columns.Add("NAME");
                if (!dt.Columns.Contains("PID"))
                    dt.Columns.Add("PID");
                XmlToDataTable(xnod);
            }
            return dt;
        }

        /// <summary>
        /// 将XML转换成DataTable
        /// </summary>
        /// <param name="xnod"></param>
        /// <param name="intLevel"></param>
        private void XmlToDataTable(XmlNode xnod)
        {
            DataRow dr = dt.NewRow();
            XmlNode xnodWorking;

            //如果是元素节点，获取它的属性
            if (xnod.NodeType == XmlNodeType.Element)
            {
                XmlNamedNodeMap mapAttributes = xnod.Attributes;
                if (mapAttributes.Count > 0)
                {
                    dr[0] = mapAttributes.Item(0).Value;
                    dr[1] = mapAttributes.Item(1).Value;
                    dr[2] = mapAttributes.Item(2).Value;
                    dt.Rows.Add(dr);
                }

                //如果还有子节点，就递归地调用这个程序
                if (xnod.HasChildNodes)
                {
                    xnodWorking = xnod.FirstChild;
                    while (xnodWorking != null)
                    {
                        XmlToDataTable(xnodWorking);
                        xnodWorking = xnodWorking.NextSibling;
                    }
                }
            }
        }

        #endregion

        #endregion

    }
}