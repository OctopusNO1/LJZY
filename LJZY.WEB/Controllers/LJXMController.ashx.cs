using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LJZY.MODEL;
using LJZY.BLL.LQGL;
using Newtonsoft.Json;
using LJZY.WEB.Common;
using System.Data;
using System.IO;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// LJXMController 的摘要说明
    /// </summary>
    public class LJXMController : IHttpHandler
    {
        private static string DB_KLRB = System.Configuration.ConfigurationManager.AppSettings["DB_KLRB"];
        private static string T_01 = System.Configuration.ConfigurationManager.AppSettings["T_01"];
        private static string T_61 = System.Configuration.ConfigurationManager.AppSettings["T_61"];
        private static string dtName1 = DB_KLRB + T_01;
        private static string dtName61 = DB_KLRB + T_61;
        LQ_LJXMBLL LjxmBLL = new LQ_LJXMBLL();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                #region 录井项目
                //录井项目保存
                case "LJXM_Save":
                    LJXM_Save(context);
                    break;
                case "PreviewExcel":
                    PreviewExcel(context);
                    break;
                case "LJXM_Import":
                    LJXM_Import(context);
                    break;
                case "LJXMInfoByZJH":
                    LJXMInfoByZJH(context);
                    break;
                //数据删除
                case "LJXM_Del":
                    LJXM_Del(context);
                    break;
                //井筒号下拉列表
                case "ZJH_List":
                    ZJH_List(context);
                    break;
                //录井项目表格分页数据
                case "LJXMDataGrid":
                    LJXMDataGrid(context);
                    break;
                //录井项目表格数据(首页)
                case "LJXMInfo_Home":
                    LJXMInfo_Home(context);
                    break;
                //录井项目表格数据(尾页)
                case "LJXMInfo_End":
                    LJXMInfo_End(context);
                    break;
                //录井项目表格数据(上页)
                case "LJXMInfo_Up":
                    LJXMInfo_Up(context);
                    break;
                //录井项目表格数据(下页)
                case "LJXMInfo_Down":
                    LJXMInfo_Down(context);
                    break;
                #endregion
                #region 人员分配
                //人员待派列表
                case "RYXZ_List":
                    RYXZ_List(context);
                    break;
                //人员在岗列表
                case "RYZG_List":
                    RYZG_List(context);
                    break;
                //人员在岗转待派
                case "RYFPTo_DP":
                    RYFPTo_DP(context);
                    break;
                //人员待派转在岗
                case "RYFPTo_ZG":
                    RYFPTo_ZG(context);
                    break;
                #endregion
                #region 设备分配
                //闲置设备列表
                case "SBXZ_List":
                    SBXZ_List(context);
                    break;
                //再用设备列表
                case "SBZY_List":
                    SBZY_List(context);
                    break;
                //设备闲置转在用
                case "SBFPToZY":
                    SBFPToZY(context);
                    break;
                //设备在用转闲置
                case "SBFPToXZ":
                    SBFPToXZ(context);
                    break;
                #endregion
                #region 房屋分配
                //闲置房屋列表
                case "FWXZ_List":
                    FWXZ_List(context);
                    break;
                //再用房屋列表
                case "FWZY_List":
                    FWZY_List(context);
                    break;
                //房屋闲置转在用
                case "FWFPToZY":
                    FWFPToZY(context);
                    break;
                //房屋在用转闲置
                case "FWFPToXZ":
                    FWFPToXZ(context);
                    break;
                #endregion
                #region 项目部统计
                //设备动态统计
                case "SBFW_CountList":
                    SBFW_CountList(context);
                    break;
                //人员动态统计
                case "RY_CountList":
                    RY_CountList(context);
                    break;
                #endregion
                //字典数据添加
                case "DicAdd":
                    DicAdd(context);
                    break;




            }
        }

        private void LJXMInfoByZJH(HttpContext context)
        {
            string json = "";
            try
            {
                string ZJH = context.Request["ZJH"] ?? ""; //井筒号

                LQ_LJXM model = new LQ_LJXM();
                List<LQ_LJXM> list = new List<LQ_LJXM>();
                list = LjxmBLL.LJXMInfoByZJH(ZJH, dtName1, dtName61);  //单井设计信息

                if (list.Count > 0)
                {
                    model = list[0];
                }

                json = JsonConvert.SerializeObject(model);
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

        #region 录井项目模块
        /// <summary>
        /// 井号下拉列表数据
        /// </summary>
        /// <param name="context"></param>
        private void ZJH_List(HttpContext context)
        {
            string json = "";
            try
            {

                //string strTree = context.Request["strTree"];// 二级目录
                //string Ptype = LjxmBLL.Ptype(strTree);
                string strSql = "";
                string strType = "";
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strType += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }
                List<LQ_LJXM> list = new List<LQ_LJXM>();

                list = LjxmBLL.LJXMInfo_List(strType, strSql, dtName1, dtName61);

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
        /// 录井项目表格数据(上页)
        /// </summary>
        /// <param name="context"></param>
        private void LJXMInfo_Up(HttpContext context)
        {
            string json = "";
            try
            {
                LQ_LJXM ZJH = new LQ_LJXM();
                List<LQ_LJXM> list_TROW = new List<LQ_LJXM>();
                LQ_LJXM model = new LQ_LJXM();
                string JH = context.Request["JH"];//JH
                string JX = context.Request["JX"];//JX
                string strType = "";
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strType += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }

                int row = 1; //起始页序号 
                ZJH = LjxmBLL.LJXMInfo_JH(JH, strType, dtName1, dtName61);//当前页面信息
                if (ZJH.TROW > 0)
                {
                    row = ZJH.TROW - 1;
                    if (row <= 0)
                    {
                        row = 1; //上页序号
                    }
                }
                model = LjxmBLL.LJXMInfo(row, strType, dtName1, dtName61);//根据序号获取工程进度信息

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
        /// 录井项目表格数据(下页)
        /// </summary>
        /// <param name="context"></param>
        private void LJXMInfo_Down(HttpContext context)
        {
            string json = "";
            try
            {
                LQ_LJXM ZJH = new LQ_LJXM();
                List<LQ_LJXM> list_TROW = new List<LQ_LJXM>();
                LQ_LJXM model = new LQ_LJXM();
                string JH = context.Request["JH"];//JH	
                string JX = context.Request["JX"];//JX	 
                string strType = "";
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strType += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }

                int TROW_Max = LjxmBLL.COUNT_List(strType, dtName1, dtName61);//当前页序号
                ZJH = LjxmBLL.LJXMInfo_JH(JH, strType, dtName1, dtName61);//当前页面信息
                int row = ZJH.TROW + 1;
                if (row >= TROW_Max)
                {
                    row = TROW_Max;
                }
                model = LjxmBLL.LJXMInfo(row, strType, dtName1, dtName61);  //通过序号获取下页信息


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
        /// 录井项目表格数据(首页)
        /// </summary>
        /// <param name="context"></param>
        private void LJXMInfo_Home(HttpContext context)
        {
            string json = "";
            try
            {

                List<LQ_LJXM> list = new List<LQ_LJXM>();
                LQ_LJXM model = new LQ_LJXM();


                string strType = "";
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strType += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }

                int TROW = 1; //首页序号
                model = LjxmBLL.LJXMInfo(TROW, strType, dtName1, dtName61); //首页录井项目信息		

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
        /// 录井项目表格数据(尾页)
        /// </summary>
        /// <param name="context"></param>
        private void LJXMInfo_End(HttpContext context)
        {
            string json = "";
            try
            {
                List<LQ_LJXM> list = new List<LQ_LJXM>();
                LQ_LJXM model = new LQ_LJXM();
                string strType = "";
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strType += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }

                int Max_TROW = LjxmBLL.COUNT_List(strType, dtName1, dtName61); //获取尾页序号
                model = LjxmBLL.LJXMInfo(Max_TROW, strType, dtName1, dtName61);

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
        /// 录井项目数据保存
        /// </summary>
        /// <param name="context"></param>
        public void LJXM_Save(HttpContext context)
        {
            string json = "";
            try
            {
                LQ_LJXM LJXM = new LQ_LJXM();
                /// LJXM.ID = context.Request["ID"];
                LJXM.ZJH = context.Request["ZJH"];
                LJXM.SC3 = context.Request["SC3"];
                LJXM.SC2 = context.Request["SC2"];
                LJXM.QK = context.Request["QK"];
                LJXM.REPORT_TYPE = context.Request["REPORT_TYPE"];
                LJXM.JX = context.Request["JX"];
                LJXM.JH = context.Request["JH"];
                LJXM.LJXL = context.Request["LJXL"];
                LJXM.SJJS = 0;
                if (!string.IsNullOrEmpty(context.Request["SJJS"]))
                {
                    LJXM.SJJS = Convert.ToDecimal(context.Request["SJJS"]);
                }
                LJXM.JSSJJS = 0;
                if (!string.IsNullOrEmpty(context.Request["JSSJJS"]))
                {
                    LJXM.JSSJJS = Convert.ToDecimal(context.Request["JSSJJS"]);
                }

                LJXM.SCFL = context.Request["SCFL"];
                LJXM.GJ = context.Request["GJ"];
                LJXM.SC1 = context.Request["SC1"];
                LJXM.DZJDXM = context.Request["DZJDXM"];
                LJXM.DZJDZJH = context.Request["DZJDZJH"];
                LJXM.DZJDSSGS = context.Request["DZJDSSGS"];
                LJXM.ZJJDXM = context.Request["ZJJDXM"];
                LJXM.ZJJDZJH = context.Request["ZJJDZJH"];
                LJXM.ZJJDSSGS = context.Request["ZJJDSSGS"];
                LJXM.LJFGS = context.Request["LJFGS"];
                LJXM.LJDWZZ = context.Request["LJDWZZ"];
                LJXM.LJDH = context.Request["LJDH"];
                LJXM.LJYQXH = context.Request["LJYQXH"];
                LJXM.YQZZ = context.Request["YQZZ"];
                LJXM.DWZBH = context.Request["DWZBH"];
                LJXM.DZS = context.Request["DZS"];
                if (string.IsNullOrEmpty(context.Request["STARSTART"]))
                {
                    //LJXM.STARSTART = null;
                }
                else
                {
                    LJXM.STARSTART = Convert.ToDateTime(context.Request["STARSTART"]);
                }
                LJXM.STARAZR = context.Request["STARAZR"];
                if (string.IsNullOrEmpty(context.Request["STAREND"]))
                {
                    //LJXM.STAREND = null;
                }
                else
                {
                    LJXM.STAREND = Convert.ToDateTime(context.Request["STAREND"]);
                }
                LJXM.STARCCR = context.Request["STARCCR"];
                LJXM.SGDW = context.Request["SGDW"];
                LJXM.SGDH = context.Request["SGDH"];

                if (!string.IsNullOrEmpty(context.Request["YJBASJ"]))
                {
                    LJXM.YJBASJ = Convert.ToDateTime(context.Request["YJBASJ"]);
                }
                

                if (!string.IsNullOrEmpty(context.Request["SJBASJ"]))
                {
                    //LJXM.SJBASJ = null;
                }
                else
                {
                    LJXM.SJBASJ = Convert.ToDateTime(context.Request["SJBASJ"]);
                }
                LJXM.BQJL = 0;
                if (!string.IsNullOrEmpty(context.Request["BQJL"]))
                {
                    LJXM.BQJL = Convert.ToDecimal(context.Request["BQJL"]);
                }
                if (string.IsNullOrEmpty(context.Request["HQSJ"]))
                {
                    //LJXM.HQSJ = null;
                }
                else
                {
                    LJXM.HQSJ = Convert.ToDateTime(context.Request["HQSJ"]);
                }

                LJXM.DQZT = context.Request["DQZT"];
                LJXM.CHOUXIYOU = context.Request["CHOUXIYOU"];
                LJXM.HXJW = context.Request["HXJW"];
                LJXM.HXJDH = context.Request["HXJDH"];
                LJXM.JDDT = context.Request["JDDT"];
                LJXM.LSDW = context.Request["LSDW"];
                LJXM.XMBJWXX = context.Request["XMBJWXX"];
                LJXM.PGZDTS = context.Request["PGZDTS"];
                LJXM.XQXMB = context.Request["XQXMB"];
                LJXM.TJR = CFunctions.getUserId(context);  //添加人
                if (LjxmBLL.LQ_LJXMInfo_Check(LJXM.JH, LJXM.JX, dtName1).Rows.Count > 0)//判断井号是否存在
                {
                    if (LjxmBLL.Update(LJXM, dtName1))
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
                colList.Add("井型", "JX");
                colList.Add("井别", "REPORT_TYPE");
                colList.Add("录井项目部", "LJFGS");
                colList.Add("区块", "QK");
                colList.Add("国家", "GJ");
                colList.Add("设计井深", "SJJS");
                colList.Add("加深设计井深", "JSSJJS");
                colList.Add("市场类型", "SCFL");
                colList.Add("一级市场", "SC1");
                colList.Add("当前井深", "DRJS");
                colList.Add("当前动态", "SGZT");
                colList.Add("地质监督姓名", "DZJDXM");
                colList.Add("地质监督证件号", "DZJDZJH");
                colList.Add("地质监督所属公司", "DZJDSSGS");
                colList.Add("录井资质", "LJDWZZ");
                colList.Add("钻井监督姓名", "ZJJDXM");
                colList.Add("钻井监督证件号", "ZJJDZJH");
                colList.Add("钻井监督所属公司", "ZJJDSSGS");
                colList.Add("录井队号", "LJDH");
                colList.Add("设备型号", "LJYQXH");
                colList.Add("仪器资质", "YQZZ");
                colList.Add("队伍自编号", "DWZBH");
                colList.Add("地质师", "DZS");
                colList.Add("装卫星时间", "STARSTART");
                colList.Add("安装卫星人", "STARAZR");
                colList.Add("拆卫星时间", "STAREND");
                colList.Add("拆卫星人", "STARCCR");
                colList.Add("施工单位", "SGDW");
                colList.Add("施工队号", "SGDH");
                colList.Add("预计搬安时间", "YJBASJ");
                colList.Add("实际搬安时间", "SJBASJ");
                colList.Add("搬迁距离", "BQJL");
                colList.Add("回迁时间", "HQSJ");
                colList.Add("当前状态", "DQZT");
                colList.Add("稠油/稀油", "CHOUXIYOU");
                colList.Add("后续井位", "HXJW");
                colList.Add("后续井队号", "HXJDH");
                colList.Add("井队动态", "JDDT");
                colList.Add("隶属单位", "LSDW");
                colList.Add("项目部井位信息", "XMBJWXX");
                colList.Add("录井系列", "LJXL");
                colList.Add("辖区项目部", "XQXMB");
                colList.Add("派工重点提示", "PGZDTS");

                dt = ModelConvertHelper<LQ_LJXM>.ConvertToDt(dt, colList);
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

        public void LJXM_Import(HttpContext context)
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
                colList.Add("井型", "JX");
                colList.Add("井别", "REPORT_TYPE");
                colList.Add("录井项目部", "LJFGS");
                colList.Add("区块", "QK");
                colList.Add("国家", "GJ");
                colList.Add("设计井深", "SJJS");
                colList.Add("加深设计井深", "JSSJJS");
                colList.Add("市场类型", "SCFL");
                colList.Add("一级市场", "SC1");
                colList.Add("当前井深", "DRJS");
                colList.Add("当前动态", "SGZT");
                colList.Add("地质监督姓名", "DZJDXM");
                colList.Add("地质监督证件号", "DZJDZJH");
                colList.Add("地质监督所属公司", "DZJDSSGS");
                colList.Add("录井资质", "LJDWZZ");
                colList.Add("钻井监督姓名", "ZJJDXM");
                colList.Add("钻井监督证件号", "ZJJDZJH");
                colList.Add("钻井监督所属公司", "ZJJDSSGS");
                colList.Add("录井队号", "LJDH");
                colList.Add("设备型号", "LJYQXH");
                colList.Add("仪器资质", "YQZZ");
                colList.Add("队伍自编号", "DWZBH");
                colList.Add("地质师", "DZS");
                colList.Add("装卫星时间", "STARSTART");
                colList.Add("安装卫星人", "STARAZR");
                colList.Add("拆卫星时间", "STAREND");
                colList.Add("拆卫星人", "STARCCR");
                colList.Add("施工单位", "SGDW");
                colList.Add("施工队号", "SGDH");
                colList.Add("预计搬安时间", "YJBASJ");
                colList.Add("实际搬安时间", "SJBASJ");
                colList.Add("搬迁距离", "BQJL");
                colList.Add("回迁时间", "HQSJ");
                colList.Add("当前状态", "DQZT");
                colList.Add("稠油/稀油", "CHOUXIYOU");
                colList.Add("后续井位", "HXJW");
                colList.Add("后续井队号", "HXJDH");
                colList.Add("井队动态", "JDDT");
                colList.Add("隶属单位", "LSDW");
                colList.Add("项目部井位信息", "XMBJWXX");
                colList.Add("录井系列", "LJXL");
                colList.Add("辖区项目部", "XQXMB");
                colList.Add("派工重点提示", "PGZDTS");
                List<LQ_LJXM> list = ModelConvertHelper<LQ_LJXM>.ConvertToModel(dt, colList);
                if (LjxmBLL.importUpdate(list, dtName1))
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
        private void LJXM_Del(HttpContext context)
        {
            string json = "";
            try
            {
                string JH = context.Request["JH"] ?? ""; //井号
                string JX = context.Request["JX"] ?? ""; //井型
                if (LjxmBLL.Del(JH, JX, dtName1))
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
        /// 录井项目表格分页数据
        /// </summary>
        /// <param name="context"></param>
        private void LJXMDataGrid(HttpContext context)
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
                dic = LjxmBLL.LJXMDataGrid(strSql, rows, page, sort, order, dtName1, dtName61);

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

        #region 人员分配模块

        /// <summary>
        /// 人员待派列表
        /// </summary>
        /// <param name="context"></param>
        private void RYXZ_List(HttpContext context)
        {
            string json = "";
            try
            {
                string strGW = context.Request["strGW"];//岗位关键词
                string strColumn = context.Request["strColumn"];//选择字段
                string strWhere = context.Request["strWhere"];//关键词
                string strSql = "";
                if (!string.IsNullOrEmpty(strGW))
                {
                    if (strGW != "全部")
                    {
                        strSql += string.Format(" AND GW='{0}'", strGW);
                    }

                }
                if (!string.IsNullOrEmpty(strColumn) && !string.IsNullOrEmpty(strWhere))
                {
                    strSql += string.Format(" AND {0}='{1}'", strColumn, strWhere);
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();

                dic = LjxmBLL.RYXZ_List(strSql);

                json = JsonConvert.SerializeObject(dic);
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
        /// 人员在岗列表
        /// </summary>
        /// <param name="context"></param>
        private void RYZG_List(HttpContext context)
        {
            string json = "";
            try
            {
                //int rows = Convert.ToInt32(context.Request["limit"]);
                //int page = Convert.ToInt32(context.Request["page"]);

                string JH = context.Request["JH"]; //井号
                string strGW = context.Request["strGW"];//岗位关键词
                string strColumn = context.Request["strColumn"];//选择字段
                string strWhere = context.Request["strWhere"];//关键词
                string strSql = "";
                if (!string.IsNullOrEmpty(strGW))
                {
                    if (strGW != "全部")
                    {
                        strSql += string.Format(" AND GW='{0}'", strGW);
                    }
                }
                if (!string.IsNullOrEmpty(strColumn) && !string.IsNullOrEmpty(strWhere))
                {
                    strSql += string.Format(" AND {0}='{1}'", strColumn, strWhere);
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();

                dic = LjxmBLL.RYZG_List(JH, strSql);

                json = JsonConvert.SerializeObject(dic);
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

        public void RYFPTo_DP(HttpContext context)
        {
            string json = "";
            try
            {
                var Json = context.Request["ToDPJson"]; //转待派人员json

                string JH = context.Request["JH"]; //井号
                List<LQ_RYFP> list = new List<LQ_RYFP>();
                List<string> rzList = new List<string>();
                if (Json.Trim() != "")
                {
                    List<string> strlist = JsonConvert.DeserializeObject<List<string>>(Json);
                    List<LQ_SJRZ> sjrzList = LjxmBLL.SJRZList();

                    for (int i = 0; i < strlist.Count; i++)
                    {
                        LQ_RYFP model = new LQ_RYFP();

                        model.RYBH = strlist[i].ToString();
                        model.JH = JH;
                        List<LQ_SJRZ> sjrz = sjrzList.Where(o => o.JH == model.JH && o.RYBH == model.RYBH).ToList();
                        if (sjrz.Count > 0)
                        {
                            rzList.Add(sjrz[0].ID);
                            list.Add(model);
                        }

                    }
                }

                if (LjxmBLL.RYFPToDP(list, rzList))
                {
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"分配成功！\"}";
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"分配失败！\"}";
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
        /// 人员分配转在岗
        /// </summary>
        /// <param name="context"></param>
        public void RYFPTo_ZG(HttpContext context)
        {
            string json = "";
            try
            {
                var Json = context.Request["ToZGJson"]; //转在岗人员json
                string JH = context.Request["JH"]; //井号
                List<LQ_RYFP> list = new List<LQ_RYFP>();
                if (!string.IsNullOrEmpty(JH))
                {
                    if (Json.Trim() != "")
                    {
                        List<string> strlist = JsonConvert.DeserializeObject<List<string>>(Json);
                        for (int i = 0; i < strlist.Count; i++)
                        {
                            LQ_RYFP model = new LQ_RYFP
                            {
                                //model.ID = Guid.NewGuid().ToString().ToUpper();
                                RYBH = strlist[i].ToString(),
                                JH = JH,
                                TJR = CFunctions.getUserId(context)  //添加人
                            };
                            list.Add(model);
                        }
                    }

                    if (LjxmBLL.RYFPTo_ZG(list, JH, dtName1))
                    {
                        json = "{\"IsSuccess\":\"true\",\"Message\":\"分配成功！\"}";
                    }
                    else
                    {
                        json = "{\"IsSuccess\":\"false\",\"Message\":\"分配失败！\"}";
                    }
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"请选择井号!\"}";
                }


            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":" + e + "}";
            }
            context.Response.ContentType = "application/json";
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }
        #endregion

        #region 设备分配模块
        /// <summary>
        /// 闲置设备列表
        /// </summary>
        /// <param name="context"></param>
        private void SBXZ_List(HttpContext context)
        {
            string json = "";
            try
            {
                string strFL = context.Request["strFL"];//设备分类
                string strColumn = context.Request["strColumn"];//选择字段
                string strWhere = context.Request["strWhere"];//关键词
                string strSql = "";

                if (!string.IsNullOrEmpty(strColumn) && !string.IsNullOrEmpty(strWhere))
                {
                    strSql += string.Format(" AND {0}='{1}'", strColumn, strWhere);
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();
                if (!string.IsNullOrEmpty(strFL))
                {
                    if (strFL != "全部")
                    {
                        dic = LjxmBLL.SB_FL_List(strFL, strSql);
                    }
                    else
                    {
                        dic = LjxmBLL.SBXZ_List(strSql);
                    }
                }
                else
                {
                    dic = LjxmBLL.SBXZ_List(strSql);
                }



                json = JsonConvert.SerializeObject(dic);
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
        /// 在用设备列表
        /// </summary>
        /// <param name="context"></param>
        private void SBZY_List(HttpContext context)
        {
            string json = "";
            try
            {
                string JH = context.Request["JH"];//井号
                string strFL = context.Request["strFL"];//设备分类
                string strColumn = context.Request["strColumn"];//选择字段
                string strWhere = context.Request["strWhere"];//关键词
                string strSql = "";

                if (!string.IsNullOrEmpty(strColumn) && !string.IsNullOrEmpty(strWhere))
                {
                    strSql += string.Format(" AND {0}='{1}'", strColumn, strWhere);
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();


                if (strFL != "全部")
                {
                    dic = LjxmBLL.SB_FL_List(JH, strFL, strSql);
                }
                else
                {
                    dic = LjxmBLL.SBZY_List(JH, strSql);
                }


                json = JsonConvert.SerializeObject(dic);
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
        /// 设备分配转闲置
        /// </summary>
        /// <param name="context"></param>
        public void SBFPToXZ(HttpContext context)
        {
            string json = "";
            try
            {
                var Json = context.Request["ToXZJson"]; //转在岗人员json
                string JH = context.Request["JH"]; //井号
                List<LQ_SBFP> list = new List<LQ_SBFP>();
                if (Json.Trim() != "")
                {
                    list = JsonConvert.DeserializeObject<List<LQ_SBFP>>(Json);
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].JH = JH;
                        list[i].TJR = CFunctions.getUserId(context);  //添加人					
                    }
                }
                //string ZJH = context.Request["ZJH"]; //井号
                //List<LQ_SBFP> list = new List<LQ_SBFP>();
                //if (Json.Trim() != "")
                //{
                //	List<string> strlist = JsonConvert.DeserializeObject<List<string>>(Json);
                //	for (int i = 0; i < strlist.Count; i++)
                //	{
                //		LQ_SBFP model = new LQ_SBFP();
                //		model.ID = Guid.NewGuid().ToString().ToUpper();
                //		model.SBMC = strlist[i].ToString();
                //		model.ZJH = ZJH;
                //		model.TJR = CFunctions.getUserId(context);  //添加人
                //		list.Add(model);
                //	}
                //}

                if (LjxmBLL.SBFPTo_XZ(list))
                {
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"分配成功！\"}";
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"分配失败！\"}";
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
        /// 设备分配转在用
        /// </summary>
        /// <param name="context"></param>
        public void SBFPToZY(HttpContext context)
        {
            string json = "";
            try
            {
                var Json = context.Request["ToZYJson"]; //转在用json
                string JH = context.Request["JH"]; //井号
                List<LQ_SBFP> list = new List<LQ_SBFP>();
                if (!string.IsNullOrEmpty(JH))
                {
                    if (Json.Trim() != "")
                    {
                        list = JsonConvert.DeserializeObject<List<LQ_SBFP>>(Json);
                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i].JH = JH;
                            list[i].TJR = CFunctions.getUserId(context);  //添加人					
                        }
                    }

                    if (LjxmBLL.SBFPTo_ZY(list))
                    {
                        json = "{\"IsSuccess\":\"true\",\"Message\":\"分配成功！\"}";
                    }
                    else
                    {
                        json = "{\"IsSuccess\":\"false\",\"Message\":\"分配失败！\"}";
                    }
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"请选择井号!\"}";
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
        #endregion

        #region 房屋分配模块

        /// <summary>
        /// 房屋闲置列表
        /// </summary>
        /// <param name="context"></param>
        private void FWXZ_List(HttpContext context)
        {
            string json = "";
            try
            {
                string FL = context.Request["FL"]; //房屋分类
                Dictionary<string, object> dic = new Dictionary<string, object>();

                dic = LjxmBLL.FWXZ_List(FL);

                json = JsonConvert.SerializeObject(dic);
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
        /// 房屋在用列表
        /// </summary>
        /// <param name="context"></param>
        private void FWZY_List(HttpContext context)
        {
            string json = "";
            try
            {
                string FL = context.Request["FL"]; //房屋分类
                string JH = context.Request["JH"]; //井号
                Dictionary<string, object> dic = new Dictionary<string, object>();

                dic = LjxmBLL.FWZY_List(JH, FL);

                json = JsonConvert.SerializeObject(dic);
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
        /// 房屋分配转闲置
        /// </summary>
        /// <param name="context"></param>
        public void FWFPToXZ(HttpContext context)
        {
            string json = "";
            try
            {
                var Json = context.Request["ToXZJson"]; //转在岗人员json
                string JH = context.Request["JH"]; //井号
                List<LQ_FWFP> list = new List<LQ_FWFP>();
                if (Json.Trim() != "")
                {
                    list = JsonConvert.DeserializeObject<List<LQ_FWFP>>(Json);
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].JH = JH;
                        //list[i].TJR = CFunctions.getUserId(context);  //添加人					
                    }
                }

                if (LjxmBLL.FWFPTo_XZ(list))
                {
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"分配成功！\"}";
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"分配失败！\"}";
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
        /// 房屋分配转在用
        /// </summary>
        /// <param name="context"></param>
        public void FWFPToZY(HttpContext context)
        {
            string json = "";
            try
            {
                var Json = context.Request["ToZYJson"]; //转在用json
                string JH = context.Request["JH"]; //井号
                List<LQ_FWFP> list = new List<LQ_FWFP>();
                if (!string.IsNullOrEmpty(JH))
                {
                    if (Json.Trim() != "")
                    {
                        list = JsonConvert.DeserializeObject<List<LQ_FWFP>>(Json);
                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i].JH = JH;
                            list[i].TJR = CFunctions.getUserId(context);  //添加人					
                        }
                    }

                    if (LjxmBLL.FWFPTo_ZY(list))
                    {
                        json = "{\"IsSuccess\":\"true\",\"Message\":\"分配成功！\"}";
                    }
                    else
                    {
                        json = "{\"IsSuccess\":\"false\",\"Message\":\"分配失败！\"}";
                    }
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"请选择井号!\"}";
                }
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":" + e + "}";
            }
            context.Response.ContentType = "application/json";
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        #endregion


        /// <summary>
        /// 字典数据录入
        /// </summary>
        /// <param name="context"></param>
        public void DicAdd(HttpContext context)
        {
            string json = "";
            try
            {
                Sys_Dictionary dic = new Sys_Dictionary
                {
                    DICTIONARYID = Guid.NewGuid().ToString().ToUpper(),
                    CODE = context.Request["CODE"],
                    NAME = context.Request["NAME"],
                    PTYPE = context.Request["PTYPE"],
                    TYPE = context.Request["TYPE"],
                    ADDEMP = "CHEN"
                };

                if (LjxmBLL.DicAdd(dic))
                {
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"添加成功！\"}";
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"添加失败！\"}";
                }
                json = JsonConvert.SerializeObject(json);
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

        private void SBFW_CountList(HttpContext context)
        {
            string json = "";
            try
            {
                string LJFGS = context.Request["LJFGS"]; //项目部
                List<SB_FW_Count> list = new List<SB_FW_Count>();
                list = LjxmBLL.SBFW_CountList(LJFGS);
                json = JsonConvert.SerializeObject(list);
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


        private void RY_CountList(HttpContext context)
        {
            string json = "";
            try
            {
                string LJFGS = context.Request["LJFGS"]; //项目部
                List<RY_Count> list = new List<RY_Count>();
                list = LjxmBLL.RY_CountList(LJFGS);
                json = JsonConvert.SerializeObject(list);
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