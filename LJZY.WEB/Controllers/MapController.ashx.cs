using LJZY.BLL.Map;
using LJZY.MODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// MapController 的摘要说明
    /// </summary>
    public class MapController : IHttpHandler
    {
        private static string DB_KLRB = System.Configuration.ConfigurationManager.AppSettings["DB_KLRB"];
        private static string T_01 = System.Configuration.ConfigurationManager.AppSettings["T_01"];
        private static string T_61 = System.Configuration.ConfigurationManager.AppSettings["T_61"];
        private static string dtName1 = DB_KLRB + T_01;
        private static string dtName61 = DB_KLRB + T_61;
        MapBLL mapBLL = new MapBLL();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                //地图坐标列表
                case "MapList":
                    MapList(context);
                    break;
                case "MapListByJH":
                    MapListByJH(context);
                    break;
                //统计区域数据
                case "CountNum":
                    CountNum(context);
                    break;
            }
        }

        /// <summary>
        /// 地图坐标列表
        /// </summary>
        /// <param name="context"></param>
        private void MapList(HttpContext context)
        {
            string json = "";
            try
            {
                string strWhere = "";
                string SC3 = context.Request["SC3"];       //甲方单位
                string LJFGS = context.Request["LJFGS"];   //录井项目部
                string SC2 = context.Request["SC2"];       //地区
                string TYPE = context.Request["TYPE"];       //地区
                string FL = context.Request["FL"];
                string JH = context.Request["JH"] ?? "";

                if (!string.IsNullOrEmpty(JH))
                {
                    strWhere = string.Format(" AND T1.JH='{0}'", JH);
                }
                else
                {
                    if (!string.IsNullOrEmpty(LJFGS))
                    {
                        strWhere = string.Format(" AND T1.LJFGS='{0}'", LJFGS);
                    }
                    if (!string.IsNullOrEmpty(SC3))
                    {
                        strWhere = string.Format(" AND T1.SC3='{0}'", SC3);
                    }
                    if (!string.IsNullOrEmpty(SC2))
                    {
                        strWhere = string.Format(" AND T1.SC2='{0}'", SC2);
                    }
                    if (!string.IsNullOrEmpty(TYPE))
                    {
                        strWhere = string.Format(" AND T1.REPORT_TYPE='{0}'", TYPE);
                    }
                    string str = context.Request["strWhere"];
                    if (string.IsNullOrEmpty(str))
                    {
                        strWhere += str;
                    }
                    switch (SC3)
                    {
                        case "勘探公司":
                            strWhere += " AND T1.REPORT_TYPE='探井' ";
                            break;
                        case "开发公司":
                            strWhere += " AND T1.REPORT_TYPE='开发井' ";
                            break;
                    }
                    switch (FL)
                    {
                        case "勘探":
                            strWhere += " AND SC3='勘探公司' ";
                            break;
                        case "开发":
                            strWhere += " AND SC3='开发公司' ";
                            break;
                        case "正钻":
                            strWhere += " AND NVL(DRJS, 0) > 0 ";
                            break;
                        case "待派":
                            strWhere += " AND NVL(T1.ISLATESTRECORD, 0)= 0 ";
                            break;
                        case "卫星":
                            strWhere += " AND T1.STARSTART IS NOT NULL AND (T1.STAREND IS NULL OR T1.STAREND !='') ";
                            break;
                            //default:
                            //    break;
                    }
                }

                List<BDMap> list = new List<BDMap>();

                string Time = DateTime.Now.ToString("yyyy/MM/dd");
                list = mapBLL.List_Map(Time, strWhere, dtName1, dtName61);
                json = JsonConvert.SerializeObject(list);
                json = "{\"IsSuccess\":\"true\",\"Data\":" + json + "}";

            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void MapListByJH(HttpContext context)
        {
            string json = "";
            try
            {
                string strWhere = "";
                string JH = context.Request["JH"] ?? "";


                strWhere = string.Format(" AND T1.JH='{0}'", JH);

                List<BDMap> list = new List<BDMap>();
                list = mapBLL.List_MapByJH(strWhere, dtName1, dtName61);
                json = JsonConvert.SerializeObject(list);
                json = "{\"IsSuccess\":\"true\",\"Data\":" + json + "}";

            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 统计区域数据
        /// </summary>
        /// <param name="context"></param>
        private void CountNum(HttpContext context)
        {
            string json = "";
            try
            {

                string Time = DateTime.Now.ToString("yyyy/MM/dd");
                List<int> list = mapBLL.CountNum(Time, dtName1, dtName61);
                json = JsonConvert.SerializeObject(list);
                json = "{\"IsSuccess\":\"true\",\"Data\":" + json + "}";

            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}