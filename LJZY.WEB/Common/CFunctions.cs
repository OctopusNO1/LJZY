using LJZY.MODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Management;

namespace LJZY.WEB.Common
{
    public class CFunctions : IRequiresSessionState
    {
        /// <summary>
        /// 获取当前登陆人的id
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string getUserId(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                string strUser = ((FormsIdentity)context.User.Identity).Ticket.UserData;
                Sys_User user = JsonConvert.DeserializeObject<Sys_User>(strUser);  //获取当前用户信息    
                return user.USERNAME;
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Sys_User getUser(HttpContext context)
        {
            var strings = context.Request["UserData"];
           // string strUser = context.Items["UserData"].ToString();
            string strUser = ((FormsIdentity)context.User.Identity).Ticket.UserData;
            Sys_User user = JsonConvert.DeserializeObject<Sys_User>(strUser);  //获取当前用户信息
            

            return user;
        }




        /// <summary>  
        /// 采用Socket方式，测试服务器连接  
        /// </summary>  
        /// <param name="host">服务器主机名或IP</param>  
        /// <param name="port">端口号</param>  
        /// <param name="millisecondsTimeout">等待时间：毫秒</param>  
        /// <returns></returns>  
        public static bool TestConnection(string host, int port, int millisecondsTimeout)
        {
            TcpClient client = new TcpClient();
            try
            {
                var ar = client.BeginConnect(host, port, null, null);
                ar.AsyncWaitHandle.WaitOne(millisecondsTimeout);
                return client.Connected;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                client.Close();
            }
        }

        /// <summary>  
        /// 数据库连接操作，可替换为你自己的程序  
        /// </summary>  
        /// <param name="ConnectionString">连接字符串</param>  
        /// <returns></returns>  
        public static bool TestConnection(string ConnectionString)
        {
            bool result = true;

            try
            {
                SqlConnection m_myConnection = new SqlConnection(ConnectionString);
                m_myConnection.Open();

                //数据库操作......  

                m_myConnection.Close();
            }
            catch (Exception)
            {
                //  System.Diagnostics.Debug.WriteLine(ex.ToString());
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 获取ip地址
        /// </summary>
        /// <returns></returns>
        public static string getIP(HttpContext context)
        {
            string ip = "";
            System.Net.IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for (int i = 0; i < addressList.Length; i++)
            {
                ip = addressList[i].ToString();
            }
            return ip;
        }
        /// <summary>
        /// 获取主机名
        /// </summary>
        /// <returns></returns>
        public static string getPCName(HttpContext context)
        {
            string name = Dns.GetHostName();
            return name;
        }

 
    }
}