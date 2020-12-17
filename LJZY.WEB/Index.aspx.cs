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
    public partial class Index : System.Web.UI.Page
    {

        private string loginUrl = System.Configuration.ConfigurationManager.AppSettings["loginUrl"];
        private string loginOut = System.Configuration.ConfigurationManager.AppSettings["loginOut"];
        protected void Page_Load(object sender, EventArgs e)
        {
          
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

        public void sigout_Click(object sender, EventArgs e)
        {
            try
            {
                FormsAuthentication.SignOut();
                string token = Session["token"].ToString()??"";
                
                if (!string.IsNullOrEmpty(token))
                {
                    //loginOut = "http://www.shiwensoft.com:8020/realtime/logout";
                    var strUser = PostData(loginOut, token);

                    Session["token"] = "";
                }
                //loginUrl = "http://www.shiwensoft.com:8020/login.html";
                Response.Redirect(loginUrl);
            }
            catch (Exception)
            {
                Response.Redirect(loginUrl);
                throw;
            }
           
        }
    }
}