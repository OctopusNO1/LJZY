using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LJZY.MODEL;
using LJZY.BLL;
using System.Web.Security;
using System.Data;
using Newtonsoft.Json;
using System.Text;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// LoginController 的摘要说明
    /// </summary>
    public class LoginController : IHttpHandler
    {
        private static string DB_KLLOGT = System.Configuration.ConfigurationManager.AppSettings["DB_KLLOGT"];
        private static string dtUser = System.Configuration.ConfigurationManager.AppSettings["SYS_USER"];
        //private static string dtName = DB_KLLOGT + dtUser;
        private static string dtName = dtUser;
        LJZY.BLL.SYSTEM.UserBLL userBll = new BLL.SYSTEM.UserBLL();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                //登录
                case "login": login(context); break;
                //退出登录
                case "logOut": logOut(context); break;
            }
        }


        private void login(HttpContext context)
        {

            context.Response.ContentType = "application/json";
            string json = "";
            try
            {
                if (string.IsNullOrEmpty(json))
                {
                    string username = context.Request["account"];
                    string password = context.Request["password"];
                    System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                    password = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", null).ToLower();
                    
                    string guids = context.Request["guids"] ?? Guid.NewGuid().ToString().ToUpper();
                    DataTable dt = userBll.LoginCheck(username, password, dtName).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Sys_User user = new Sys_User();
                        user.USERNAME = dt.Rows[0]["USERNAME"].ToString();
                        user.USERPASS = dt.Rows[0]["USERPASS"].ToString();
                        user.REALNAME = dt.Rows[0]["REALNAME"].ToString();
                        //user.STATUS = dt.Rows[0]["STATUS"].ToString();
                        //user.ADDTIME = dt.Rows[0]["ADDTIME"].ToString();
                        //user.ADDEMP = dt.Rows[0]["ADDEMP"].ToString();
                        //user.REMARK = dt.Rows[0]["REMARK"].ToString();
                        string userDate = JsonConvert.SerializeObject(user);

                        //创建一个身份验证票  
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "LJZY", DateTime.Now, DateTime.Now.AddMinutes(360), false, userDate);
                        //将身份验证票加密  
                        string EncrTicket = FormsAuthentication.Encrypt(ticket);
                        //创建一个Cookie  
                        HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName, EncrTicket);
                        //将Cookie写入客户端  
                        context.Response.Cookies.Add(myCookie);

                        string guid = Guid.NewGuid().ToString().ToUpper();

                        TimeSpan SessTimeOut = new TimeSpan(0, 0, 3600, 0, 0);//forms 认证过期时间
                        HttpContext.Current.Cache.Insert(user.USERNAME, guid, null, DateTime.MaxValue, SessTimeOut, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                        HttpContext.Current.Cache.Insert("Guids", guids, null, DateTime.MaxValue, SessTimeOut, System.Web.Caching.CacheItemPriority.NotRemovable, null);

                        if (dt.Rows[0]["USERNAME"].ToString() == username && dt.Rows[0]["USERPASS"].ToString() == password)
                        {
                            json = "{\"IsSuccess\":\"true\",\"Message\":\" 登录成功！ \"}";
                        }

                    }

                    else
                    {
                        json = "{\"IsSuccess\":\"false\",\"Message\":\"用户名或密码错误！\"}";
                    }
                }


            }
            catch (Exception ception)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"" + ception.Message + "\"}";
            }
            context.Response.ContentType = "application/json";
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }


        /// <summary>
		/// 退出登录
		/// </summary>
		/// <param name="context"></param>
		public void logOut(HttpContext context)
        {

            try
            {
                string json = "";

                //string userid = CFunctions.getUser(context).UserID.ToString();
                //object guid = HttpContext.Current.Cache.Get("Guids");

                //if (guid == null)
                //{
                //    guid = "";
                //}
                //根据userId和guid获取数据
                //Sys_LoginSession ls = new Sys_LoginSession();
                //if (string.IsNullOrEmpty(guid.ToString()))
                //{
                //    ls = lsBll.GetModel(" AND LsUserID='" + userid + "' and PlatName='PC' ");
                //}
                //else
                //{
                //    ls = lsBll.GetModel(" AND LsUserID='" + userid + "' and LsGuid='" + guid + "' ");
                //}
                //if (ls == null)
                //{
                //    json = "{\"IsSuccess\":\"true\",\"Message\":\"注销成功！\"}";
                //}
                //else
                //{
                //    //修改状态为0即为注销
                //    ls.LsStatus = "0";
                //    lsBll.Update(ls);
                //    json = "{\"IsSuccess\":\"true\",\"Message\":\"注销成功！\"}";
                //}

                json = "{\"IsSuccess\":\"true\",\"Message\":\"退出成功！\"}";
                FormsAuthentication.SignOut();
                //json = JsonConvert.SerializeObject("{IsSuccess:'true',Message:'注销成功！'}");
                context.Response.ContentType = "application/json";
                context.Response.Write(json);
                //  context.Response.End();
                context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ception)
            {
                //logger.Error(ception);
            }
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