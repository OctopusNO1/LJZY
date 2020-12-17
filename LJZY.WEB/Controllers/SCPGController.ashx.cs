using LJZY.BLL.LQGL;
using LJZY.MODEL;
using LJZY.WEB.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// SCPGController 的摘要说明
    /// </summary>
    public class SCPGController : IHttpHandler
    {
        private static string DB_KLRB = ConfigurationManager.AppSettings["DB_KLRB"];
        private static string T_01 = ConfigurationManager.AppSettings["T_01"];
        private static string T_61 = ConfigurationManager.AppSettings["T_61"];
        private static string dtName1 = DB_KLRB + T_01;
        private static string dtName61 = DB_KLRB + T_61;
        LQ_SCPGBLL ScpgBLL = new LQ_SCPGBLL();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                //井类型派工列表
                case "JHList_DP":
                    JHList_DP(context);
                    break;
                //其他井列表
                case "JHList_QT":
                    JHList_QT(context);
                    break;
                //待分配井类型列表
                case "JHList_DFP":
                    JHList_DFP(context);
                    break;
                //项目部派工列表
                case "JHList_XMBPG":
                    JHList_XMBPG(context);
                    break;
                //井号分配
                case "SCPG_Insert":
                    SCPG_Insert(context);
                    break;
                //任务回退
                case "SCPG_Del":
                    SCPG_Del(context);
                    break;
                //其他回退
                case "QTPG_Del":
                    QTPG_Del(context);
                    break;
                //队伍统计
                case "DWCountList":
                    DWCountList(context);
                    break;
                //施工统计
                case "SGCountList":
                    SGCountList(context);
                    break;
                //完井明细列表
                case "WJList":
                    WJList(context);
                    break;
            }
        }

        /// <summary>
        /// 待派工井号列表
        /// </summary>
        /// <param name="context"></param>
        private void JHList_DP(HttpContext context)
        {
            string json = "";
            string strSql = "";
            try
            {
                string REPORT_TYPE = context.Request["REPORT_TYPE"]; //页面井别                
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += " And REPORT_TYPE='" + REPORT_TYPE + "'";
                }
                Dictionary<string, object> list = new Dictionary<string, object>();

                list = ScpgBLL.JHList_DP(strSql, dtName1);
                json = JsonConvert.SerializeObject(list);
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
        /// 其他分配井列表
        /// </summary>
        /// <param name="context"></param>
        private void JHList_QT(HttpContext context)
        {
            string json = "";
            try
            {

                Dictionary<string, object> list = new Dictionary<string, object>();

                list = ScpgBLL.JHList_QT(dtName1);
                json = JsonConvert.SerializeObject(list);
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

        private void JHList_DFP(HttpContext context)
        {
            string json = "";
            try
            {
                Dictionary<string, object> list = new Dictionary<string, object>();
                //Sys_User user = CFunctions.getUser(context);后续根据当前登录人项目部进行划分
                list = ScpgBLL.JHList_DFP(dtName1);
                json = JsonConvert.SerializeObject(list);
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

        private void SCPG_Insert(HttpContext context)
        {
            string json = "";
            try
            {

                string JHJson = context.Request["JHJson"] ?? "";
                string LJFGS = context.Request["LJFGS"] ?? "";
                string JHstr = "";
                //序列化
                List<LQ_SCPG> JHList = JsonConvert.DeserializeObject<List<LQ_SCPG>>(JHJson);
                for (int i = 0; i < JHList.Count; i++)
                {
                    JHList[i].LJFGS = LJFGS;
                    JHList[i].TJR = CFunctions.getUserId(context);  //添加人
                    JHList[i].TJSJ = DateTime.Now.ToString("yyyy-MM-dd");

                    JHstr += "'" + JHList[i].JH + "'" + ",";
                }
                //去掉最后一个逗号
                JHstr = JHstr.Substring(0, JHstr.Length - 1);
                if (ScpgBLL.SCPG_Check(JHList.Count, JHstr, dtName1))
                {
                    if (ScpgBLL.SCPG_Insert(JHList, dtName1))
                    {
                        json = "{\"IsSuccess\":\"true\",\"Message\":\"操作成功！\"}";
                    }
                    else
                    {
                        json = "{\"IsSuccess\":\"false\",\"Message\":\"操作失败！\"}";
                    }
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"操作失败,请刷新重新确认！\"}";
                }
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":" + e + "}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 派工撤回
        /// </summary>
        /// <param name="context"></param>
        private void SCPG_Del(HttpContext context)
        {
            string json = "";
            try
            {
                List<LQ_SCPG> list = new List<LQ_SCPG>();
                string JHJson = context.Request["JHJson"] ?? "";
                string JHstr = "";
                //序列化
                List<string> JHList = JsonConvert.DeserializeObject<List<string>>(JHJson);
                for (int i = 0; i < JHList.Count; i++)
                {
                    JHstr += "'" + JHList[i].ToString() + "'" + ",";
                }
                //去掉最后一个逗号
                JHstr = JHstr.Substring(0, JHstr.Length - 1);

                if (ScpgBLL.RWTH_Check(JHstr))
                {
                    if (ScpgBLL.SCPG_Del(JHList, dtName1))
                    {
                        json = "{\"IsSuccess\":\"true\",\"Message\":\"操作成功！\"}";
                    }
                    else
                    {
                        json = "{\"IsSuccess\":\"false\",\"Message\":\"操作失败！\"}";
                    }
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"操作失败,存在已完成派工的井！\"}";
                }
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":" + e + "}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void QTPG_Del(HttpContext context)
        {
            string json = "";
            try
            {
                List<LQ_SCPG> list = new List<LQ_SCPG>();
                string JHJson = context.Request["JHJson"] ?? "";
                string REPORT_TYPE = context.Request["REPORT_TYPE"] ?? "";
                string JHstr = "";
                //序列化
                List<LQ_SCPG> JHList = JsonConvert.DeserializeObject<List<LQ_SCPG>>(JHJson);
                for (int i = 0; i < JHList.Count; i++)
                {
                    JHstr += "'" + JHList[i].JH + "'" + ",";
                }
                //去掉最后一个逗号
                JHstr = JHstr.Substring(0, JHstr.Length - 1);

                if (ScpgBLL.RWTH_Check(JHstr))
                {
                    if (ScpgBLL.QTPG_Del(JHList, REPORT_TYPE, dtName1))
                    {
                        json = "{\"IsSuccess\":\"true\",\"Message\":\"操作成功！\"}";
                    }
                    else
                    {
                        json = "{\"IsSuccess\":\"false\",\"Message\":\"操作失败！\"}";
                    }
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"操作失败,存在已完成派工的井！\"}";
                }
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":" + e + "}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void JHList_XMBPG(HttpContext context)
        {
            string json = "";
            try
            {
                Dictionary<string, object> list = new Dictionary<string, object>();

                list = ScpgBLL.JHList_XMBPG(dtName1);
                json = JsonConvert.SerializeObject(list);
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

        private void DWCountList(HttpContext context)
        {
            string json = "";
            try
            {
                Dictionary<string, object> list = new Dictionary<string, object>();

                list = ScpgBLL.DWCountList(dtName1, dtName61);
                json = JsonConvert.SerializeObject(list);
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

        private void SGCountList(HttpContext context)
        {
            string json = "";
            try
            {
                Dictionary<string, object> list = new Dictionary<string, object>();

                list = ScpgBLL.SGCountList(dtName1, dtName61);
                json = JsonConvert.SerializeObject(list);
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

        private void WJList(HttpContext context)
        {
            string json = "";
            try
            {
                Dictionary<string, object> list = new Dictionary<string, object>();

                list = ScpgBLL.WJList(dtName1);
                json = JsonConvert.SerializeObject(list);
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