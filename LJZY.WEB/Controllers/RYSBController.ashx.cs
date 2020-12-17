using LJZY.BLL.LQGL;
using LJZY.MODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// RYSBController 的摘要说明
    /// </summary>
    public class RYSBController : IHttpHandler
    {
        private static string DB_KLRB = System.Configuration.ConfigurationManager.AppSettings["DB_KLRB"];
        private static string T_01 = System.Configuration.ConfigurationManager.AppSettings["T_01"];
        private static string T_61 = System.Configuration.ConfigurationManager.AppSettings["T_61"];
        private static string dtName1 = DB_KLRB + T_01;
        private static string dtName61 = DB_KLRB + T_61;
        LQ_RYSBBLL rysbBLL = new LQ_RYSBBLL ( );
        public void ProcessRequest( HttpContext context )
        {
            string action = context.Request["action"];
            switch (action)
            {
                //人员设备列表数据
                case "RYSB_List":
                    RYSB_List ( context );
                    break;
                //人员轮休列表
                case "RY_List":
                    RY_List(context);
                    break;
            }
        }

        /// <summary>
        /// 人员设备列表数据
        /// </summary>
        /// <param name="context"></param>
        private void RY_List( HttpContext context )
        {
            string json = "";
            try
            {
                LQ_JDLXRY list = new LQ_JDLXRY( );
                list = rysbBLL.RY_List();
                json = JsonConvert.SerializeObject ( list );
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear ( );
            context.Response.Write ( json );
            HttpContext.Current.ApplicationInstance.CompleteRequest ( );

        }

        private void RYSB_List(HttpContext context)
        {
            string json = "";
            try
            {
                string LJFGS = context.Request["LJFGS"];    //录井项目部
                string Time = context.Request["Time"];// 日期
                string strSql = "";
                if (!string.IsNullOrEmpty(LJFGS))
                {
                    strSql += string.Format(" AND L.LJFGS='{0}'", LJFGS);
                }
                LQ_RSList list = new LQ_RSList();
                list = rysbBLL.RYSB_List(Time, strSql, dtName1, dtName61);
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