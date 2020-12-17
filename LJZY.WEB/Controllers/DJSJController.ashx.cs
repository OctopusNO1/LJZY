using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LJZY.MODEL;
using LJZY.BLL.LQGL;
using System.Collections;
using LJZY.WEB.Common;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// DJSJController 的摘要说明
    /// </summary>
    public class DJSJController : IHttpHandler
    {
        #region ------------------------变量------------------------
        private static string DB_KLRB = System.Configuration.ConfigurationManager.AppSettings["DB_KLRB"];
        private static string T_01 = System.Configuration.ConfigurationManager.AppSettings["T_01"];
        private static string T_61 = System.Configuration.ConfigurationManager.AppSettings["T_61"];
        private static string dtName1 = DB_KLRB + T_01;
        LQGLBLL LqglBLL = new LQGLBLL();
        #endregion


        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                //单井设计表格数据根据井号获取
                case "DJSJInfoByZJH":
                    DJSJInfoByZJH(context);
                    break;
                //单井设计表格数据根据井筒号获取
                case "DJSJInfoByJH":
                    DJSJInfoByJH(context);
                    break;
                ////单井设计表格数据 
                //case "DJSJInfo_List": DJSJInfo_List(context); break;
                //单井设计表格数据 
                case "DJSJDataGrid":
                    DJSJDataGrid(context);
                    break;
                //井号下拉列表
                case "ZJH_List":
                    ZJH_List(context);
                    break;
                //单井设计表格数据(首页)
                case "DJSJInfo_Home":
                    DJSJInfo_Home(context);
                    break;
                //单井设计表格数据(尾页)
                case "DJSJInfo_End":
                    DJSJInfo_End(context);
                    break;
                //单井设计表格数据(上页)
                case "DJSJInfo_Up":
                    DJSJInfo_Up(context);
                    break;
                //单井设计表格数据(下页)
                case "DJSJInfo_Down":
                    DJSJInfo_Down(context);
                    break;
                //数据保存
                case "DJSJ_Save":
                    DJSJ_Save(context);
                    break;
                //数据删除
                case "DJSJ_Del":
                    DJSJ_Del(context);
                    break;
                //数据导入
                case "DJSJ_Import":
                    DJSJ_Import(context);
                    break;
            }
        }

        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="context"></param>
        private void DJSJ_Save(HttpContext context)
        {
            string json = "";
            try
            {
                LQ_DJSJ DJSJ = new LQ_DJSJ();
                DJSJ.ZJH = context.Request["ZJH"];  //井号
                                                    //DJSJ.XH = 0;
                DJSJ.SC3 = context.Request["SC3"];  //甲方单位
                DJSJ.SC2 = context.Request["SC2"];  //地区
                DJSJ.QK = context.Request["QK"];    //区块
                DJSJ.REPORT_TYPE = context.Request["REPORT_TYPE"];    //井别
                DJSJ.JX = context.Request["JX"];    //井型
                DJSJ.JH = context.Request["JH"];    //井筒号

                DJSJ.SJJS = 0;//设计井深
                if (context.Request["SJJS"] != "")
                {
                    DJSJ.SJJS = Convert.ToDecimal(context.Request["SJJS"]);
                }

                DJSJ.JSSJJS = 0;//加深设计井深
                if (context.Request["JSSJJS"] != "")
                {
                    DJSJ.JSSJJS = Convert.ToDecimal(context.Request["JSSJJS"]);
                }

                DJSJ.WZJS = 0;//完钻井深
                if (context.Request["WZJS"] != "")
                {
                    DJSJ.WZJS = Convert.ToDecimal(context.Request["WZJS"]);
                }

                DJSJ.DLWZ = context.Request["DLWZ"]; //地理位置
                DJSJ.GZWZ = context.Request["GZWZ"]; //构造位置
                DJSJ.CXWZ = context.Request["CXWZ"]; //测线位置
                DJSJ.SJZZBB = 0; //设计纵坐标(北京)
                if (context.Request["SJZZBB"] != "")
                {
                    DJSJ.SJZZBB = Convert.ToDecimal(context.Request["SJZZBB"]);
                }
                DJSJ.SJHZBB = 0; //设计横坐标(北京)
                if (context.Request["SJHZBB"] != "")
                {
                    DJSJ.SJHZBB = Convert.ToDecimal(context.Request["SJHZBB"]);
                }

                DJSJ.SJZZBX = 0; //设计纵坐标(西安)
                if (context.Request["SJZZBX"] != "")
                {
                    DJSJ.SJZZBX = Convert.ToDecimal(context.Request["SJZZBX"]);
                }

                DJSJ.SJHZBX = 0; //设计横坐标(西安)
                if (context.Request["SJHZBX"] != "")
                {
                    DJSJ.SJHZBX = Convert.ToDecimal(context.Request["SJHZBX"]);
                }

                DJSJ.SJZZB = 0; //实测纵坐标
                if (context.Request["SJZZB"] != "")
                {
                    DJSJ.SJZZB = Convert.ToDecimal(context.Request["SJZZB"]);
                }

                DJSJ.SJHZB = 0; //实测横坐标
                if (context.Request["SJHZB"] != "")
                {
                    DJSJ.SJHZB = Convert.ToDecimal(context.Request["SJHZB"]);
                }

                DJSJ.DMHB = 0; //地面海拔
                if (context.Request["DMHB"] != "")
                {
                    DJSJ.DMHB = Convert.ToDecimal(context.Request["DMHB"]);
                }

                DJSJ.BXG = 0; //补心高
                if (context.Request["BXG"] != "")
                {
                    DJSJ.BXG = Convert.ToDecimal(context.Request["BXG"]);
                }

                DJSJ.ZYMDC = context.Request["ZYMDC"]; //目的层
                if (string.IsNullOrEmpty(context.Request["SJR"]))
                {
                    DJSJ.SJR = " ";
                }
                else
                {
                    DJSJ.SJR = context.Request["SJR"]; //设计人
                }     
                if (string.IsNullOrEmpty(context.Request["SPR"]))
                {
                    DJSJ.SPR = " ";
                }
                else
                {
                    DJSJ.SPR = context.Request["SPR"]; //审批人
                }
                if (string.IsNullOrEmpty(context.Request["SJRQ"]))
                {
                    DJSJ.SJRQ = null;
                    DJSJ.SJRQ_date = null;
                }
                else
                {
                    DJSJ.SJRQ = context.Request["SJRQ"]; //设计日期
                    DJSJ.SJRQ_date = Convert.ToDateTime(context.Request["SJRQ"]);
                }

                if (string.IsNullOrEmpty(context.Request["SPRQ"]))
                {
                    DJSJ.SPRQ = null;
                    DJSJ.SPRQ_date = null;
                }
                else
                {
                    DJSJ.SPRQ = context.Request["SPRQ"]; //审批日期
                    DJSJ.SPRQ_date = Convert.ToDateTime(context.Request["SPRQ"]);
                }
                DJSJ.TJR = CFunctions.getUserId(context);  //添加人
                DJSJ.BZ = context.Request["BZ"];  //备注
                DJSJ.LJFGS = context.Request["LJFGS"]; //录井项目部
                DJSJ.ISLATESTRECORD = 0;
                DJSJ.ISFINISH = 0;
                if (context.Request["ISLATESTRECORD"] != "")
                {
                    DJSJ.ISLATESTRECORD = Convert.ToInt32(context.Request["ISLATESTRECORD"]); //新增是否派工标识
                }
                if (context.Request["ISFINISH"] != "")
                {
                    DJSJ.ISFINISH = Convert.ToInt32(context.Request["ISFINISH"]); //新增派工完成标识
                }
                 
                string Message = "";
                if (LqglBLL.DJSJInfo_Check(DJSJ.JH, out Message, dtName1))//判断井号是否存在
                {
                    if (LqglBLL.Update(DJSJ, dtName1)) //修改操作
                    {
                        json = "{\"IsSuccess\":\"true\",\"Message\":\"修改成功！\"}";
                    }
                    else
                    {
                        json = "{\"IsSuccess\":\"false\",\"Message\":\"修改失败！\"}";
                    }
                }
                else
                {
                    if (Message.Trim() == "")
                    {
                        if (LqglBLL.Add(DJSJ, dtName1))   //新增操作
                        {
                            json = "{\"IsSuccess\":\"true\",\"Message\":\"添加成功！\"}";
                        }
                        else
                        {
                            json = "{\"IsSuccess\":\"false\",\"Message\":\"添加失败！\"}";
                        }
                    }
                    else
                    {
                        json = "{\"IsSuccess\":\"false\",\"Message\":" + Message + "}";
                    }

                }



            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"发生错误!\"}";
            }
            //json = JsonConvert.SerializeObject ( json );
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 数据导入
        /// </summary>
        /// <param name="context"></param>
        private void DJSJ_Import(HttpContext context)
        {
            string json = "";
            try
            {
                string content = context.Request["Content"] ?? "";  //设计导入的
                content = content.Trim().Replace("\t", "");//清除\t
                content = content.Replace("井别", "\t");//将字段名改成\t区分开
                content = content.Replace("井型", "\t");//将字段名改成\t区分开
                content = content.Replace("井号", "\t");//将字段名改成\t区分开
                content = content.Replace("地理位置", "\t");//将字段名改成\t区分开
                content = content.Replace("构造位置", "\t");//将字段名改成\t区分开
                content = content.Replace("测线位置", "\t");//将字段名改成\t区分开
                content = content.Replace("大地坐标", "\t");//将字段名改成\t区分开
                content = content.Replace("大地坐标", "\t");//将字段名改成\t区分开
                content = content.Replace("北京54", "\t");//将字段名改成\t区分开
                content = content.Replace("X：", "\t");//将字段名改成\t区分开
                content = content.Replace("Y：", "\t");//将字段名改成\t区分开
                content = content.Replace("地面海拔", "\t");//将字段名改成\t区分开
                content = content.Replace("西安80", "\t");//将字段名改成\t区分开
                content = content.Replace("X：", "\t");//将字段名改成\t区分开
                content = content.Replace("Y：", "\t");//将字段名改成\t区分开
                content = content.Replace("设计井深", "\t");//将字段名改成\t区分开
                content = content.Replace("目的层", "\t");//将字段名改成\t区分开
                content = content.Trim();

                //通过\t将导入数据转成数组
                string[] arr = content.Trim().Split('\t');

                LQ_DJSJ DJSJ = new LQ_DJSJ();
                //循环数组通过下标赋值LQ_DJSJ
                for (int i = 0; i < arr.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            DJSJ.REPORT_TYPE = arr[i];
                            break;
                        case 1:
                            DJSJ.JX = arr[i];
                            break;
                        case 2:
                            DJSJ.ZJH = arr[i];
                            DJSJ.JH = arr[i];
                            break;
                        case 3:
                            DJSJ.DLWZ = arr[i];
                            break;
                        case 4:
                            DJSJ.GZWZ = arr[i];
                            break;
                        case 5:
                            DJSJ.CXWZ = arr[i];
                            break;
                        //case 6:
                        //	//DJSJ.DLWZ = arr[i];
                        //	break;
                        //case 7:

                        //	break;
                        case 8:
                            DJSJ.SJHZBB = Convert.ToDecimal(arr[i].Replace("m", ""));
                            break;
                        case 9:
                            DJSJ.SJZZBB = Convert.ToDecimal(arr[i].Replace("m", ""));
                            break;
                        case 10:
                            DJSJ.DMHB = Convert.ToDecimal(arr[i].Replace("m", ""));
                            break;
                        //case 11:

                        //	break;
                        case 12:
                            DJSJ.SJHZBX = Convert.ToDecimal(arr[i].Replace("m", ""));
                            break;
                        case 13:
                            DJSJ.SJZZBX = Convert.ToDecimal(arr[i].Replace("m", ""));
                            break;
                        case 14:
                            DJSJ.SJJS = Convert.ToDecimal(arr[i].Replace("m", ""));
                            break;
                        case 15:
                            DJSJ.ZYMDC = arr[i];
                            break;
                        default:
                            break;
                    }

                }


                json = JsonConvert.SerializeObject(DJSJ);
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"请注意录入数据格式！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="context"></param>
        private void DJSJ_Del(HttpContext context)
        {
            string json = "";
            try
            {
                string JH = context.Request["JH"] ?? ""; //井号
                string JX = context.Request["JX"] ?? ""; //井型

                if (LqglBLL.Del(JH, JX, dtName1))
                {
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"删除成功！\"}";
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"删除失败！\"}";
                }

            }
            catch (Exception e)
            {
                json = "";
            }
            //json = JsonConvert.SerializeObject ( json );
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 单井设计表格数据
        /// </summary>
        /// <param name="context"></param>
        private void DJSJDataGrid(HttpContext context)
        {
            string json = "";
            string strSql = "";
            try
            {
                int rows = Convert.ToInt32(context.Request["limit"]);
                int page = Convert.ToInt32(context.Request["page"]);
                string strWhere = context.Request["strWhere"] ?? "";//搜索条件 
                string REPORT_TYPE = context.Request["TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }
                if (strWhere.Trim() != "")
                {
                    strSql += strWhere;
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();
                //获取表格数据
                dic = LqglBLL.DJSJDataGrid(strSql, rows, page, dtName1);

                json = JsonConvert.SerializeObject(dic);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 井号下拉列表数据
        /// </summary>
        /// <param name="context"></param>
        private void ZJH_List(HttpContext context)
        {
            string json = "";
            try
            {
                string ZJH = context.Request["ZJH"];//井号 
                string strSql = "";


                if (!string.IsNullOrEmpty(ZJH))
                {
                    strSql += " And ZJH LIKE '%" + ZJH + "%'";
                }
                List<LQ_DJSJ> list = new List<LQ_DJSJ>();

                list = LqglBLL.JH_List(strSql, dtName1);

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {

                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
                //throw e;
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 通过井号获取单井设计信息
        /// </summary>
        /// <param name="context"></param>
        private void DJSJInfoByZJH(HttpContext context)
        {
            string json = "";
            try
            {
                string ZJH = context.Request["ZJH"] ?? ""; //井筒号
                string strSql = "";

                strSql = " And ZJH ='" + ZJH + "'"; //条件
                LQ_DJSJ DJSJ = new LQ_DJSJ();
                List<LQ_DJSJ> list = new List<LQ_DJSJ>();
                list = LqglBLL.DJSJInfo_List(strSql, dtName1);  //单井设计信息

                if (list.Count > 0)
                {
                    DJSJ = list[0];
                }


                json = JsonConvert.SerializeObject(DJSJ);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 通过井号获取单井设计信息
        /// </summary>
        /// <param name="context"></param>
        private void DJSJInfoByJH(HttpContext context)
        {
            string json = "";
            try
            {
                string JH = context.Request["JH"] ?? ""; //井号
                string strSql = "";

                strSql = " And JH ='" + JH + "'";   //条件
                LQ_DJSJ DJSJ = new LQ_DJSJ();
                List<LQ_DJSJ> list = new List<LQ_DJSJ>();
                list = LqglBLL.DJSJInfo_List(strSql, dtName1);  //单井设计信息

                if (list.Count > 0)
                {
                    DJSJ = list[0];
                }

                json = JsonConvert.SerializeObject(DJSJ);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 单井设计表格数据(上页)
        /// </summary>
        /// <param name="context"></param>
        private void DJSJInfo_Up(HttpContext context)
        {
            string json = "";
            string strSql = "";
            int row = 1; //起始页序号  
            try
            {
                List<LQ_DJSJ> list_ZJH = new List<LQ_DJSJ>();
                List<LQ_DJSJ> list_TROW = new List<LQ_DJSJ>();
                LQ_DJSJ model = new LQ_DJSJ();
                string JH = context.Request["JH"];  //JH
                string JX = context.Request["JX"];  //JX 
                string REPORT_TYPE = context.Request["TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }

                int TROW = 0;
                list_ZJH = LqglBLL.DJSJInfo_JH(strSql, JH, JX, dtName1);//当前页面信息
                if (list_ZJH.Count > 0)
                {
                    TROW = list_ZJH[0].TROW;
                    TROW = TROW - 1;
                    if (TROW > row)
                    {
                        row = TROW; //上页序号
                    }
                }
                list_TROW = LqglBLL.DJSJInfo(row, strSql, dtName1);//根据序号获取单井设计信息 
                if (list_TROW.Count > 0)
                {
                    model = list_TROW[0];
                }

                json = JsonConvert.SerializeObject(model);
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }
        /// <summary>
        /// 单井设计表格数据(下页)
        /// </summary>
        /// <param name="context"></param>
        private void DJSJInfo_Down(HttpContext context)
        {
            string json = "";
            string strSql = "";
            try
            {
                string JH = context.Request["JH"];//JH
                string JX = context.Request["JX"];  //JX  
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }
                LQ_DJSJ model = new LQ_DJSJ();
                int TROW_Max = LqglBLL.COUNT_List(dtName1, strSql);//当前页序号
                List<LQ_DJSJ> list_ZJH = new List<LQ_DJSJ>();
                List<LQ_DJSJ> list_TROW = new List<LQ_DJSJ>();
                int row = 1;
                list_ZJH = LqglBLL.DJSJInfo_JH(strSql, JH, JX, dtName1);//当前页面信息
                for (int i = 0; i < list_ZJH.Count; i++)
                {
                    row = list_ZJH[i].TROW;
                    row = row + 1;
                    if (row > TROW_Max)
                    {
                        row = TROW_Max;  //下页序号
                    }
                }

                list_TROW = LqglBLL.DJSJInfo(row, strSql, dtName1);  //通过序号获取下页信息

                if (list_TROW.Count > 0)
                {
                    model = list_TROW[0];
                }

                json = JsonConvert.SerializeObject(model);
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 单井设计表格数据(首页)
        /// </summary>
        /// <param name="context"></param>
        private void DJSJInfo_Home(HttpContext context)
        {
            string json = "";
            string strSql = "";
            try
            {
                List<LQ_DJSJ> list = new List<LQ_DJSJ>();
                LQ_DJSJ model = new LQ_DJSJ();
                int TROW = 1; //首页序号
                string REPORT_TYPE = context.Request["TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }

                list = LqglBLL.DJSJInfo(TROW, strSql, dtName1); //首页单井设计信息

                if (list.Count > 0)
                {
                    model = list[0];
                }



                json = JsonConvert.SerializeObject(model);
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 单井设计表格数据(尾页)
        /// </summary>
        /// <param name="context"></param>
        private void DJSJInfo_End(HttpContext context)
        {
            string json = "";
            string strSql = "";
            try
            {

                List<LQ_DJSJ> list = new List<LQ_DJSJ>();
                LQ_DJSJ model = new LQ_DJSJ();
                string REPORT_TYPE = context.Request["TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }
                int TROW = LqglBLL.COUNT_List(dtName1, strSql); //获取尾页序号
                if (TROW > 0)
                {
                    list = LqglBLL.DJSJInfo(TROW, strSql, dtName1);
                }


                if (list.Count > 0)
                {
                    model = list[0];
                }

                json = JsonConvert.SerializeObject(model);
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
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