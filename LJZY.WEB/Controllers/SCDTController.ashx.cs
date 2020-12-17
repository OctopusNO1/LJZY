﻿using LJZY.BLL.LQGL;
using LJZY.MODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// SCDTController 的摘要说明
    /// </summary>
    public class SCDTController : IHttpHandler
    {
        private static string DB_KLRB = System.Configuration.ConfigurationManager.AppSettings["DB_KLRB"];
        private static string T_01 = System.Configuration.ConfigurationManager.AppSettings["T_01"];
        private static string T_61 = System.Configuration.ConfigurationManager.AppSettings["T_61"];
        private static string dtName1 = DB_KLRB + T_01;
        private static string dtName61 = DB_KLRB + T_61;
        LQ_SCDTBLL ScdtBLL = new LQ_SCDTBLL ( );
        public void ProcessRequest( HttpContext context )
        {
            string action = context.Request["action"];
            switch (action)
            {
                //生产动态列表数据
                case "SCDT_List":
                    SCDT_List ( context );
                    break;
            }
        }

        /// <summary>
        /// 生产动态列表数据
        /// </summary>
        /// <param name="context"></param>
        private void SCDT_List( HttpContext context )
        {
            string json = "";
            try
            {
                List<LQ_SCDT> list = new List<LQ_SCDT> ( );
                string LJFGS = context.Request["LJFGS"];  //录井项目部
                string Time = context.Request["Time"]; //日期
                string strSql = "";
                if (!string.IsNullOrEmpty ( LJFGS ))
                {
                    strSql += string.Format ( " AND L.LJFGS='{0}'", LJFGS );
                }
                 
                list = ScdtBLL.SCDT_List ( Time, strSql, dtName1, dtName61 );
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("code", 0);
                dic.Add("msg","");
                dic.Add("count",list.Count);
                dic.Add("data", list);
                json = JsonConvert.SerializeObject (dic);
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}