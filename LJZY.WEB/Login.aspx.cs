using LJZY.BLL.SYSTEM;
using LJZY.MODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LJZY.WEB
{
    public partial class Login : System.Web.UI.Page
    {
        private string loginUrl = System.Configuration.ConfigurationManager.AppSettings["loginUrl"];
        private string loginUserUrl = System.Configuration.ConfigurationManager.AppSettings["loginUserUrl"];
        private static string DB_KLLOGT = System.Configuration.ConfigurationManager.AppSettings["DB_KLLOGT"];
        private static string dtUser = System.Configuration.ConfigurationManager.AppSettings["SYS_USER"];
        private static string dtName = DB_KLLOGT + dtUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginCheck();
        }

        private void LoginCheck()
        {
            #region  ===登录验证
            string token = Request.QueryString["token"];
            Response.Write(Request.QueryString["token"]);
            LoginUser loguser = new LoginUser();
            if (!string.IsNullOrEmpty(token))
            {
                var strUser = PostData(loginUserUrl, token);
                if (!string.IsNullOrEmpty(strUser))
                {

                    loguser = JsonConvert.DeserializeObject<LoginUser>(strUser);
                    UserBLL userBLL = new UserBLL();
                    Sys_User user = userBLL.GetModel(loguser.Username, dtName);
                    //if (user == null)
                    //{
                    //    user = new Sys_User();
                    //    user.EMPLOYEENO = loguser.Username;
                    //    if (userBLL.Add(user, dtName))
                    //    {
                    //        user = userBLL.GetModel(loguser.Username, dtName);
                    //    }
                    //}
                    Session["token"] = token;
                    string userDate = JsonConvert.SerializeObject(user);
                    string guids = Guid.NewGuid().ToString().ToUpper();
                    //创建一个身份验证票  
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "LJZY", DateTime.Now, DateTime.Now.AddMinutes(360), false, userDate);
                    //将身份验证票加密  
                    string EncrTicket = FormsAuthentication.Encrypt(ticket);
                    //创建一个Cookie  
                    HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName, EncrTicket);
                    //将Cookie写入客户端  
                    Response.Cookies.Add(myCookie);

                    string guid = Guid.NewGuid().ToString().ToUpper();

                    TimeSpan SessTimeOut = new TimeSpan(0, 0, 3600, 0, 0);//forms 认证过期时间
                    HttpContext.Current.Cache.Insert(user.USERNAME, guid, null, DateTime.MaxValue, SessTimeOut, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                    HttpContext.Current.Cache.Insert("Guids", guids, null, DateTime.MaxValue, SessTimeOut, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    //loginUrl = "http://www.shiwensoft.com:8020/login.html";
                    Response.Redirect(loginUrl);
                }

            }
            else
            {

                //string user = Request["userid"];
                //if (islogout == "1")
                //{



                //    Logout(user);
                //    return;
                //}
                //else
                //{
                //    user = PostData("http://www.shiwensoft.com:8020/realtime/login/curr-user", token);
                //    //Response.Write(user+token);
                //    if (!string.IsNullOrEmpty(user))
                //    {
                //        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                //        Dictionary<string, object> dict = (Dictionary<string, object>)serializer.DeserializeObject(user);
                //        if (dict != null && dict.ContainsKey("username"))
                //        {
                //            if (islogout == "1")
                //            {

                //            }
                //            else
                //            {
                //                Login(dict["username"].ToString(), token);
                //            }
                //            return;
                //        }
                //    }
                //}

                //// Response.Redirect("Default.aspx");
                //loginUrl = "http://www.shiwensoft.com:8020/login.html";
                //Response.Redirect(loginUrl);
            }
            #endregion
        }
        public static string PostData(string purl, string token)
        {
            try
            {
                // 准备请求    
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(purl);
                //if (!string.IsNullOrEmpty(RoadFlow.Utility.Config.ProxyUrl))
                //{
                //    req.Proxy = new WebProxy(RoadFlow.Utility.Config.ProxyUrl);
                //}
                //设置超时     
                req.Timeout = 30000;
                req.Method = "GET";
                req.Headers.Add("Cookie", "auth=" + token);
                //req.ContentType = "application/x-www-form-urlencoded";
                //req.ContentLength = data.Length;
                //Stream stream = req.GetRequestStream();
                //// 发送数据   
                //stream.Write(data, 0, data.Length);
                //stream.Close();

                HttpWebResponse rep = (HttpWebResponse)req.GetResponse();
                Stream receiveStream = rep.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("UTF-8");
                // Pipes the stream to a higher level stream reader with the required encoding format.   
                StreamReader readStream = new StreamReader(receiveStream, encode);

                Char[] read = new Char[256];
                int count = readStream.Read(read, 0, 256);
                StringBuilder sb = new StringBuilder("");
                while (count > 0)
                {
                    String readstr = new String(read, 0, count);
                    sb.Append(readstr);
                    count = readStream.Read(read, 0, 256);
                }

                rep.Close();
                readStream.Close();

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}