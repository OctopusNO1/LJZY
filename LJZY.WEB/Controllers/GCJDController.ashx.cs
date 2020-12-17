using LJZY.BLL.LQGL;
using LJZY.MODEL;
using LJZY.WEB.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// GCJDController 的摘要说明
    /// </summary>
    public class GCJDController : IHttpHandler
    {
        #region 连接数据库
        private static string DB_KLRB = System.Configuration.ConfigurationManager.AppSettings["DB_KLRB"];
        private static string T_01 = System.Configuration.ConfigurationManager.AppSettings["T_01"];
        private static string T_61 = System.Configuration.ConfigurationManager.AppSettings["T_61"];
        private static string dtName1 = DB_KLRB + T_01;
        private static string dtName61 = DB_KLRB + T_61;
        #endregion
        LQ_GCJDBLL GcjdBLL = new LQ_GCJDBLL();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                #region 工程进度
                //工程进度保存
                case "GCJD_Save":
                    GCJD_Save(context);
                    break;
                //工程进度预览
                case "PreviewExcel":
                    PreviewExcel(context);
                    break;
                //工程进度导入
                case "GCJD_Import":
                    GCJD_Import(context);
                    break;
                //数据删除
                case "GCJD_Del":
                    GCJD_Del(context);
                    break;
                //井筒号下拉列表
                case "ZJH_List":
                    ZJH_List(context);
                    break;
                //工程进度表格分页数据
                case "GCJDDataGrid":
                    GCJDDataGrid(context);
                    break;
                //工程进度表格数据(首页)
                case "GCJDInfo_Home":
                    GCJDInfo_Home(context);
                    break;
                //工程进度表格数据(尾页)
                case "GCJDInfo_End":
                    GCJDInfo_End(context);
                    break;
                //工程进度表格数据(上页)
                case "GCJDInfo_Up":
                    GCJDInfo_Up(context);
                    break;
                //工程进度表格数据(下页)
                case "GCJDInfo_Down":
                    GCJDInfo_Down(context);
                    break;
                #endregion
                //根据井号获取表单数据
                case "GCJDInfoByJH":
                    GCJDInfoByJH(context);
                    break;
            }
        }

        #region 工程进度模块
        /// <summary>
        /// 井号下拉列表数据
        /// </summary>
        /// <param name="context"></param>
        private void ZJH_List(HttpContext context)
        {
            string json = "";
            try
            {
                string strSql = "";
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }
                List<LQ_GCJD> list = new List<LQ_GCJD>();
                list = GcjdBLL.GCJDInfo_List(strSql, dtName1, dtName61);
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
        /// 工程进度表格数据(上页)
        /// </summary>
        /// <param name="context"></param>
        private void GCJDInfo_Up(HttpContext context)
        {
            string json = "";
            try
            {
                LQ_GCJD ZJH = new LQ_GCJD();
                List<LQ_GCJD> list = new List<LQ_GCJD>();
                LQ_GCJD model = new LQ_GCJD();
                string JH = context.Request["JH"];  //JH
                string JX = context.Request["JX"];  //JH 
                string strSql = "";
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += "  And REPORT_TYPE='" + REPORT_TYPE + "' ";
                }
                int row = 1; //起始页序号 
                ZJH = GcjdBLL.GCJDInfo_JH(JH, strSql, dtName1, dtName61);//当前页面信息
                if (ZJH.TROW > 0)
                {
                    row = ZJH.TROW - 1;
                    if (row <= 0)
                    {
                        row = 1; //上页序号
                    }
                }
                model = GcjdBLL.GCJDInfo(row, strSql, dtName1, dtName61);//根据序号获取工程进度信息


                json = JsonConvert.SerializeObject(model);
            }
            catch (Exception e)
            {
                json = " ";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }
        /// <summary>
        /// 工程进度表格数据(下页)
        /// </summary>
        /// <param name="context"></param>
        private void GCJDInfo_Down(HttpContext context)
        {
            string json = "";
             
            try
            {
                LQ_GCJD ZJH = new LQ_GCJD();
                List<LQ_GCJD> list = new List<LQ_GCJD>();
                LQ_GCJD model = new LQ_GCJD();
                string JH = context.Request["JH"];//JH	
                string JX = context.Request["JX"];//JX               
                string strSql = "";
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += " And REPORT_TYPE='" + REPORT_TYPE + "' ";
                }
                int MaxRow = GcjdBLL.COUNT_List(strSql, dtName1, dtName61);//所有数据
                ZJH = GcjdBLL.GCJDInfo_JH(JH, strSql, dtName1, dtName61);//当前页面信息
                int row = ZJH.TROW + 1;
                if (row >= MaxRow)
                {
                    row = MaxRow;
                }
                model = GcjdBLL.GCJDInfo(row, strSql, dtName1, dtName61);  //通过序号获取下页信息


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
        /// 工程进度表格数据(首页)
        /// </summary>
        /// <param name="context"></param>
        private void GCJDInfo_Home(HttpContext context)
        {
            string json = "";
            try
            {

                List<LQ_GCJD> list = new List<LQ_GCJD>();
                LQ_GCJD model = new LQ_GCJD();

                string strSql = "";
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += "  And REPORT_TYPE='" + REPORT_TYPE + "'";
                }

                int TROW = 1; //首页序号
                list = GcjdBLL.AllGCJDInfo(strSql, dtName1, dtName61);
                model = GcjdBLL.GCJDInfo(TROW, strSql, dtName1, dtName61); //首页工程进度信息		

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
        /// 工程进度表格数据(尾页)
        /// </summary>
        /// <param name="context"></param>
        private void GCJDInfo_End(HttpContext context)
        {
            string json = "";
            try
            {
                List<LQ_GCJD> list = new List<LQ_GCJD>();
                LQ_GCJD model = new LQ_GCJD();
                string strSql = "";
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += "  And REPORT_TYPE='" + REPORT_TYPE + "'";
                }

                int row = 1;
                list = GcjdBLL.AllGCJDInfo(strSql, dtName1, dtName61); //获取尾页序号
                if (list.Count > 0)
                {
                    model = GcjdBLL.GCJDInfo(row, strSql, dtName1, dtName61);
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
        /// 工程进度数据保存
        /// </summary>
        /// <param name="context"></param>
        public void GCJD_Save(HttpContext context)
        {
            string json = "";
            try
            {
                LQ_GCJD GCJD = new LQ_GCJD();
                LQ_GCJD_CZ CZ = new LQ_GCJD_CZ();
                LQ_GCJD_ZT ZT = new LQ_GCJD_ZT();
                //GCJD.ID = context.Request["ID"];
                GCJD.ZJH = context.Request["ZJH"];
                GCJD.SC3 = context.Request["SC3"];
                GCJD.SC2 = context.Request["SC2"];
                GCJD.QK = context.Request["QK"];
                GCJD.REPORT_TYPE = context.Request["REPORT_TYPE"];
                GCJD.JX = context.Request["JX"];
                GCJD.JH = context.Request["JH"];
                GCJD.LJXL = context.Request["LJXL"];
                GCJD.DZLJKSJS = 0;
                if (!string.IsNullOrEmpty(context.Request["DZLJKSJS"]))
                {
                    GCJD.DZLJKSJS = Convert.ToDecimal(context.Request["DZLJKSJS"]);
                }
                if (!string.IsNullOrEmpty(context.Request["DZLJKSSJ"]))
                {
                    GCJD.DZLJKSSJ_Str = context.Request["DZLJKSSJ"];
                    GCJD.DZLJKSSJ = Convert.ToDateTime(context.Request["DZLJKSSJ"]);
                }
                else
                {
                    GCJD.DZLJKSSJ_Str = null;
                    GCJD.DZLJKSSJ = null;
                }

                GCJD.YXLJKSJS = 0;
                if (!string.IsNullOrEmpty(context.Request["YXLJKSJS"]))
                {
                    GCJD.YXLJKSJS = Convert.ToDecimal(context.Request["YXLJKSJS"]);
                }
                if (!string.IsNullOrEmpty(context.Request["YXLJKSSJ"]))
                {
                    GCJD.YXLJKSSJ_Str = context.Request["YXLJKSSJ"];
                    GCJD.YXLJKSSJ = Convert.ToDateTime(context.Request["YXLJKSSJ"]);
                }
                else
                {
                    GCJD.YXLJKSSJ_Str = null;
                    GCJD.YXLJKSSJ = null;
                }


                GCJD.QCLJKSJS = 0;
                if (!string.IsNullOrEmpty(context.Request["QCLJKSJS"]))
                {
                    GCJD.QCLJKSJS = Convert.ToDecimal(context.Request["QCLJKSJS"]);
                }
                if (!string.IsNullOrEmpty(context.Request["QCLJKSSJ"]))
                {
                    GCJD.QCLJKSSJ_Str = context.Request["QCLJKSSJ"];
                    GCJD.QCLJKSSJ = Convert.ToDateTime(context.Request["QCLJKSSJ"]);
                }
                else
                {
                    GCJD.QCLJKSSJ_Str = null;
                    GCJD.QCLJKSSJ = null;
                }

                GCJD.ZHLJKSJS = 0;
                if (!string.IsNullOrEmpty(context.Request["ZHLJKSJS"]))
                {
                    GCJD.ZHLJKSJS = Convert.ToDecimal(context.Request["ZHLJKSJS"]);
                }
                if (!string.IsNullOrEmpty(context.Request["ZHLJKSSJ"]))
                {
                    GCJD.ZHLJKSSJ_Str = context.Request["ZHLJKSSJ"];
                    GCJD.ZHLJKSSJ = Convert.ToDateTime(context.Request["ZHLJKSSJ"]);
                }
                else
                {
                    GCJD.ZHLJKSSJ_Str = null;
                    GCJD.ZHLJKSSJ = null;
                }

                GCJD.SJJS = 0;
                if (!string.IsNullOrEmpty(context.Request["SJJS"]))
                {
                    GCJD.SJJS = Convert.ToDecimal(context.Request["SJJS"]);
                }
                GCJD.JSSJJS = 0;
                if (!string.IsNullOrEmpty(context.Request["JSSJJS"]))
                {
                    GCJD.JSSJJS = Convert.ToDecimal(context.Request["JSSJJS"]);
                }
                GCJD.WZJS = 0;
                if (!string.IsNullOrEmpty(context.Request["WZJS"]))
                {
                    GCJD.WZJS = Convert.ToDecimal(context.Request["WZJS"]);
                }

                GCJD.SJZZB = 0;
                if (!string.IsNullOrEmpty(context.Request["SJZZB"]))
                {
                    GCJD.SJZZB = Convert.ToDecimal(context.Request["SJZZB"]);
                }
                GCJD.SJHZB = 0;
                if (!string.IsNullOrEmpty(context.Request["SJHZB"]))
                {
                    GCJD.SJHZB = Convert.ToDecimal(context.Request["SJHZB"]);
                }

                GCJD.DMHB = 0;
                if (!string.IsNullOrEmpty(context.Request["DMHB"]))
                {
                    GCJD.DMHB = Convert.ToDecimal(context.Request["DMHB"]);
                }

                GCJD.BXG = 0;
                if (!string.IsNullOrEmpty(context.Request["BXG"]))
                {
                    GCJD.BXG = Convert.ToDecimal(context.Request["BXG"]);
                }

                GCJD.SGDW = context.Request["SGDW"];
                GCJD.SGDH = context.Request["SGDH"];
                GCJD.LJFGS = context.Request["LJFGS"];
                GCJD.LJDH = context.Request["LJDH"];
                GCJD.LJYQXH = context.Request["LJYQXH"];
                if (!string.IsNullOrEmpty(context.Request["KZRQ"]))
                {
                    GCJD.KZRQ_Str = context.Request["KZRQ"];
                    GCJD.KZRQ = Convert.ToDateTime(context.Request["KZRQ"]);
                    GCJD.ND = GCJD.KZRQ.Value.Year.ToString();
                }
                else
                {
                    GCJD.KZRQ_Str = null;
                    GCJD.KZRQ = null;
                    GCJD.ND = null;
                }
                if (!string.IsNullOrEmpty(context.Request["WZRQ"]))
                {
                    GCJD.WZRQ_Str = context.Request["WZRQ"];
                    GCJD.WZRQ = Convert.ToDateTime(context.Request["WZRQ"]);
                }
                else
                {
                    GCJD.WZRQ_Str = null;
                    GCJD.WZRQ = null;
                }
                if (!string.IsNullOrEmpty(context.Request["GJRQ"]))
                {
                    GCJD.GJRQ_Str = context.Request["GJRQ"];
                    GCJD.GJRQ = Convert.ToDateTime(context.Request["GJRQ"]);
                }
                else
                {
                    GCJD.GJRQ_Str = null;
                    GCJD.GJRQ = null;

                }
                if (!string.IsNullOrEmpty(context.Request["WJRQ"]))
                {
                    GCJD.WJRQ_Str = context.Request["WJRQ"];
                    GCJD.WJRQ = Convert.ToDateTime(context.Request["WJRQ"]);
                }
                else
                {
                    GCJD.WJRQ_Str = null;
                    GCJD.WJRQ = null;
                }
                GCJD.ZYMDC = context.Request["ZYMDC"];
                GCJD.WZCW = context.Request["WZCW"];
                GCJD.WJFF = context.Request["WJFF"];
                GCJD.DYNZDJS = 0;
                if (!string.IsNullOrEmpty(context.Request["DYNZDJS"]))
                {
                    GCJD.DYNZDJS = Convert.ToDecimal(context.Request["DYNZDJS"]);
                }
                GCJD.DENZDJS = 0;
                if (!string.IsNullOrEmpty(context.Request["DENZDJS"]))
                {
                    GCJD.DENZDJS = Convert.ToDecimal(context.Request["DENZDJS"]);
                }
                GCJD.SFJJYQXS = context.Request["SFJJYQXS"];
                GCJD.SFQX = context.Request["SFQX"];
                GCJD.SFJSYQC = context.Request["SFJSYQC"];
                GCJD.SFCXGCFZ = context.Request["SFCXGCFZ"];
                GCJD.CXGCFZLX = context.Request["CXGCFZLX"];

                if (!string.IsNullOrEmpty(context.Request["GCFZCLSJ"]))
                {
                    GCJD.GCFZCLSJ_Str = context.Request["GCFZCLSJ"];
                    GCJD.GCFZCLSJ = Convert.ToDateTime(context.Request["GCFZCLSJ"]);
                }
                else
                {
                    GCJD.GCFZCLSJ_Str = null;
                    GCJD.GCFZCLSJ = null;
                }
                GCJD.SFXYCTG = context.Request["SFXYCTG"];
                GCJD.SJWZYZ = context.Request["SJWZYZ"];
                GCJD.WZYJ = context.Request["WZYJ"];

                #region 侧钻数据
                CZ.ZJH = GCJD.ZJH;
                CZ.CZMC = context.Request["CZMC"];
                CZ.CZKSJS = 0;
                if (!string.IsNullOrEmpty(context.Request["CZKSJS"]))
                {
                    CZ.CZKSJS = Convert.ToDecimal(context.Request["CZKSJS"]);
                }
                if (!string.IsNullOrEmpty(context.Request["CZKSSJ"]))
                {
                    CZ.CZKSSJ_Str = context.Request["CZKSSJ"];
                    CZ.CZKSSJ = Convert.ToDateTime(context.Request["CZKSSJ"]);
                }
                else
                {
                    CZ.CZKSSJ_Str = null;
                    CZ.CZKSSJ = null;
                }

                CZ.CZJSJS = 0;
                if (!string.IsNullOrEmpty(context.Request["CZJSJS"]))
                {
                    CZ.CZJSJS = Convert.ToDecimal(context.Request["CZJSJS"]);
                }
                if (!string.IsNullOrEmpty(context.Request["CZJSSJ"]))
                {
                    CZ.CZJSSJ_Str = context.Request["CZJSSJ"];
                    CZ.CZJSSJ = Convert.ToDateTime(context.Request["CZJSSJ"]);
                }
                else
                {
                    CZ.CZJSSJ_Str = null;
                    CZ.CZJSSJ = null;
                }


                #endregion

                #region 中停数据

                ZT.ZJH = GCJD.ZJH;
                ZT.ZTMC = context.Request["ZTMC"];
                if (!string.IsNullOrEmpty(context.Request["ZTKSSJ"]))
                {
                    ZT.ZTKSSJ_Str = context.Request["ZTKSSJ"];
                    ZT.ZTKSSJ = Convert.ToDateTime(context.Request["ZTKSSJ"]);
                }
                else
                {
                    ZT.ZTKSSJ_Str = null;
                    ZT.ZTKSSJ = null;
                }
                if (!string.IsNullOrEmpty(context.Request["ZTJSSJ"]))
                {
                    ZT.ZTJSSJ_Str = context.Request["ZTJSSJ"];
                    ZT.ZTJSSJ = Convert.ToDateTime(context.Request["ZTJSSJ"]);
                }
                else
                {
                    ZT.ZTJSSJ_Str = null;
                    ZT.ZTJSSJ = null;

                }
                #endregion

                GCJD.SFBF = context.Request["SFBF"];   //
                GCJD.BFLX = context.Request["BFLX"];  //报废类型
                if (!string.IsNullOrEmpty(context.Request["STARSTART"]))  //装卫星时间
                {
                    GCJD.STARSTART_Str = context.Request["STARSTART"];
                    GCJD.STARSTART = Convert.ToDateTime(context.Request["STARSTART"]);
                }
                else
                {
                    GCJD.STARSTART_Str = null;
                    GCJD.STARSTART = null;
                }
                if (!string.IsNullOrEmpty(context.Request["STAREND"]))   //拆卫星时间
                {
                    GCJD.STAREND_Str = context.Request["STAREND"];
                    GCJD.STAREND = Convert.ToDateTime(context.Request["STAREND"]);
                }
                else
                {
                    GCJD.STAREND_Str = null;
                    GCJD.STAREND = null;
                }
                GCJD.ZTLX = context.Request["ZTLX"]; //中停类型
                GCJD.BZ = context.Request["BZ"];//备注

                GCJD.SGDDH = context.Request["SGDDH"];     //追加字段'施工队电话'
                if (!string.IsNullOrEmpty(context.Request["YJWJRQ"]))  //预计完井日期
                {
                    GCJD.YJWJRQ = context.Request["YJWJRQ"];     //追加字段'预计完井日期'
                }
                else
                {
                    GCJD.YJWJRQ = null;
                }

                //GCJD.DRJS = 0;//当前井深
                //if (!string.IsNullOrEmpty ( context.Request["DRJS"] ))
                //{
                //    GCJD.DRJS = Convert.ToDecimal ( context.Request["DRJS"] );
                //}
                //GCJD.SGZT = context.Request["SGZT"];//当前动态
                //GCJD.TJR = CFunctions.getUserId ( context );  //添加人
                if (GcjdBLL.LQ_GCJDInfo_Check(GCJD.JH, GCJD.JX, dtName1).Rows.Count > 0)//判断井号是否存在
                {
                    if (GcjdBLL.Update(GCJD, CZ, ZT, dtName1))
                    {
                        json = "{\"IsSuccess\":\"true\",\"Message\":\"保存成功！\"}";
                    }
                    else
                    {
                        json = "{\"IsSuccess\":\"false\",\"Message\":\"保存失败！\"}";
                    }
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"保存失败！该井号不存在!\"}";
                }
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
            }
            context.Response.ContentType = "application/json";
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 预览加载
        /// </summary>
        /// <param name="context"></param>
        private void PreviewExcel(HttpContext context)
        {
            string json = "";
            try
            {
                HttpPostedFile file = context.Request.Files["FileUpload"];
                var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Upload/ExcelFile"), file.FileName);
                string directoryName = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                file.SaveAs(filePath);
                DataTable dt = NPOIHelper.ExcelToDataTable(filePath, true);

                Dictionary<string, string> colList = new Dictionary<string, string>();
                colList.Add("井号", "ZJH");
                colList.Add("井筒号", "JH");
                colList.Add("甲方单位", "SC3");
                colList.Add("地区", "SC2");
                colList.Add("录井系列", "LJXL");
                colList.Add("设计井深", "SJJS");
                colList.Add("当前井深", "DRJS");
                colList.Add("井型", "JX");
                colList.Add("井别", "REPORT_TYPE");
                colList.Add("区块", "QK");
                colList.Add("当前动态", "SGZT");
                colList.Add("地质录井开始井深", "DZLJKSJS");
                colList.Add("地质录井开始时间", "DZLJKSSJ");
                colList.Add("岩屑录井开始井深", "YXLJKSJS");
                colList.Add("岩屑录井开始时间", "YXLJKSSJ");
                colList.Add("气测录井开始井深", "QCLJKSJS");
                colList.Add("气测录井开始时间", "QCLJKSSJ");
                colList.Add("综合录井开始井深", "ZHLJKSJS");
                colList.Add("综合录井开始时间", "ZHLJKSSJ");
                colList.Add("加深设计井深", "JSSJJS");
                colList.Add("完钻井深", "WZJS");
                colList.Add("设计完钻原则", "SJWZYZ");
                colList.Add("完钻依据", "WZYJ");
                colList.Add("实测纵坐标", "SJZZB");
                colList.Add("实测横坐标", "SJHZB");
                colList.Add("地面海拔", "DMHB");
                colList.Add("补心高", "BXG");
                colList.Add("施工单位", "SGDW");
                colList.Add("施工队号", "SGDH");
                colList.Add("施工队电话", "SGDDH");
                colList.Add("录井项目部", "LJFGS");
                colList.Add("录井队号", "LJDH");
                colList.Add("开钻日期", "KZRQ");
                colList.Add("完钻日期", "WZRQ");
                colList.Add("固井日期", "GJRQ");
                colList.Add("完井日期", "WJRQ");
                colList.Add("主要目的层", "ZYMDC");
                colList.Add("完钻层位", "WZCW");
                colList.Add("完井方法", "WJFF");
                colList.Add("分支点（第一年）井深", "DYNZDJS");
                colList.Add("第二年钻达井深", "DENZDJS");
                colList.Add("是否见油气", "SFJJYQXS");
                colList.Add("是否取心", "SFQX");
                colList.Add("解释油气层否", "SFJSYQC");
                colList.Add("是否出现工程复杂", "SFCXGCFZ");
                colList.Add("出现工程复杂类型", "CXGCFZLX");
                colList.Add("工程复杂处理时间", "GCFZCLSJ");
                colList.Add("下油套否", "SFXYCTG");
                colList.Add("设备型号", "LJYQXH");
                colList.Add("装卫星时间", "STARSTART");
                colList.Add("拆卫星时间", "STAREND");
                colList.Add("是否报废", "SFBF");
                colList.Add("报废类型", "BFLX");
                colList.Add("预计完井日期", "YJWJRQ");
                colList.Add("工程备注", "BZ");

                dt = ModelConvertHelper<LQ_GCJD>.ConvertToDt(dt, colList);
                if (dt.Rows.Count > 0)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("list", dt);
                    json = JsonConvert.SerializeObject(dic);
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"操作失败！\"}";
                }

            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"操作失败！\"}";
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        public void GCJD_Import(HttpContext context)
        {
            string json = "";
            try
            {
                string Data = context.Request["Data"];

                DataTable dt = NPOIHelper.JsonToDT(Data);

                Dictionary<string, string> colList = new Dictionary<string, string>();
                colList.Add("井号", "ZJH");
                colList.Add("井筒号", "JH");
                colList.Add("甲方单位", "SC3"); 
                colList.Add("地区", "SC2");
                colList.Add("录井系列", "LJXL");
                colList.Add("设计井深", "SJJS");
                colList.Add("当前井深", "DRJS");
                colList.Add("井型", "JX");
                colList.Add("井别", "REPORT_TYPE");
                colList.Add("区块", "QK");
                colList.Add("当前动态", "SGZT");
                colList.Add("地质录井开始井深", "DZLJKSJS");
                colList.Add("地质录井开始时间", "DZLJKSSJ");
                colList.Add("岩屑录井开始井深", "YXLJKSJS");
                colList.Add("岩屑录井开始时间", "YXLJKSSJ");
                colList.Add("气测录井开始井深", "QCLJKSJS");
                colList.Add("气测录井开始时间", "QCLJKSSJ");
                colList.Add("综合录井开始井深", "ZHLJKSJS");
                colList.Add("综合录井开始时间", "ZHLJKSSJ");
                colList.Add("加深设计井深", "JSSJJS");
                colList.Add("完钻井深", "WZJS");
                colList.Add("设计完钻原则", "SJWZYZ");
                colList.Add("完钻依据", "WZYJ");
                colList.Add("实测纵坐标", "SJZZB");
                colList.Add("实测横坐标", "SJHZB");
                colList.Add("地面海拔", "DMHB");
                colList.Add("补心高", "BXG");
                colList.Add("施工单位", "SGDW");
                colList.Add("施工队号", "SGDH");
                colList.Add("施工队电话", "SGDDH");
                colList.Add("录井项目部", "LJFGS");
                colList.Add("录井队号", "LJDH");
                colList.Add("开钻日期", "KZRQ");
                colList.Add("完钻日期", "WZRQ");
                colList.Add("固井日期", "GJRQ");
                colList.Add("完井日期", "WJRQ");
                colList.Add("主要目的层", "ZYMDC");
                colList.Add("完钻层位", "WZCW");
                colList.Add("完井方法", "WJFF");
                colList.Add("分支点（第一年）井深", "DYNZDJS");
                colList.Add("第二年钻达井深", "DENZDJS");
                colList.Add("是否见油气", "SFJJYQXS");
                colList.Add("是否取心", "SFQX");
                colList.Add("解释油气层否", "SFJSYQC");
                colList.Add("是否出现工程复杂", "SFCXGCFZ");
                colList.Add("出现工程复杂类型", "CXGCFZLX");
                colList.Add("工程复杂处理时间", "GCFZCLSJ");
                colList.Add("下油套否", "SFXYCTG");
                colList.Add("设备型号", "LJYQXH");
                colList.Add("装卫星时间", "STARSTART");
                colList.Add("拆卫星时间", "STAREND");
                colList.Add("是否报废", "SFBF");
                colList.Add("报废类型", "BFLX");
                colList.Add("预计完井日期", "YJWJRQ");
                colList.Add("工程备注", "BZ");
                List<LQ_GCJD> list = ModelConvertHelper<LQ_GCJD>.ConvertToModel(dt, colList);
                if (GcjdBLL.Update(list, dtName1))
                {
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"保存成功！\"}";
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"保存失败！\"}";
                }

            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
            }
            context.Response.ContentType = "application/json";
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="context"></param>
        private void GCJD_Del(HttpContext context)
        {
            string json = "";
            try
            {
                string JH = context.Request["JH"] ?? ""; //JH
                string JX = context.Request["JX"] ?? ""; //JX
                if (GcjdBLL.Del(JH, JX, dtName1))
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
                json = " ";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 工程进度表格分页数据
        /// </summary>
        /// <param name="context"></param>
        private void GCJDDataGrid(HttpContext context)
        {
            string json = "";
            try
            {
                int rows = Convert.ToInt32(context.Request["rows"]);//页面数据条数
                int page = Convert.ToInt32(context.Request["page"]);//页面页码
                string strWhere = context.Request["strWhere"] ?? "";//搜索条件 
                string sort = context.Request["sort"] ?? "";//排序字段
                string order = context.Request["order"];//排序方式  
                string strSql = "";
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }

                if (!string.IsNullOrEmpty(strWhere))
                {
                    strSql += strWhere;
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();
                //获取表格数据
                dic = GcjdBLL.GCJDDataGrid(strSql, rows, page, sort, order, dtName1, dtName61);

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
        #endregion

        /// <summary>
        /// 根据井号获取表单数据
        /// </summary>
        /// <param name="context"></param>
        private void GCJDInfoByJH(HttpContext context)
        {
            string json = "";
            try
            {
                LQ_GCJD model = new LQ_GCJD();
                string JH = context.Request["JH"];

                model = GcjdBLL.GCJDInfoByJH(JH);
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