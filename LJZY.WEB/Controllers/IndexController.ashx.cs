using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LJZY.MODEL;
using Newtonsoft.Json;
using LJZY.WEB.Common;
using System.Data;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// IndexController 的摘要说明
    /// </summary>
    public class IndexController : IHttpHandler
    {
        LJZY.BLL.SYSTEM.MenuBLL menuBLL = new BLL.SYSTEM.MenuBLL();
        LJZY.BLL.SYSTEM.HISTBLL histBLL = new BLL.SYSTEM.HISTBLL();
        private static string DB_KLLOGT = System.Configuration.ConfigurationManager.AppSettings["DB_KLLOGT"];
        private static string dtUser = System.Configuration.ConfigurationManager.AppSettings["SYS_USER"];
        private static string dtName = DB_KLLOGT + dtUser;
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];

            switch (action)
            {
                //获取菜单列表
                case "MenuList": MenuList(context); break;
                //添加历史记录
                case "addHistory": addHistory(context); break;
                //获取历史记录列表
                case "GetHistoryList": GetHistoryList(context); break;
                //删除历史记录
                case "DeleteHistory": DeleteHistory(context); break;
                //获取用户最后浏览的页面
                case "GetUserLastHistory": GetUserLastHistory(context); break;
                //获取角色菜单
                case "getRoleMenu": getRoleMenu(context); break;
                //获取当前用户信息
                case "getUser": getUser(context); break;


            }
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <param name="context"></param>
        private void getUser(HttpContext context)
        {
            string json = "";
            try
            {

                Sys_User User = CFunctions.getUser(context);

                json = JsonConvert.SerializeObject(User);
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
        /// 添加历史记录
        /// </summary>
        /// <param name="context"></param>
        private void addHistory(HttpContext context)
        {
            string json = "";
            try
            {
                string url = context.Request["URL"];
                string title = context.Request["TITLE"];
                Sys_Hostroy sys_Hostroy = new Sys_Hostroy();
                sys_Hostroy.ID = Guid.NewGuid().ToString();
                sys_Hostroy.URL = url;
                sys_Hostroy.TITLE = title;
                sys_Hostroy.ADDTIME = DateTime.Now;
                sys_Hostroy.USER_ID = CFunctions.getUserId(context);

                if (histBLL.Add(sys_Hostroy))
                {
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"添加成功！\"}";
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"添加失败！\"}";
                }

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
        /// 获取菜单列表
        /// </summary>
        /// <param name="context"></param>
        private void MenuList(HttpContext context)
        {
            string json = "";
            string str = "";
            try
            {
                string type = context.Request.QueryString["param"];
                Sys_User user = CFunctions.getUser(context);
                if (type.Trim() == "LQ")
                {
                    str += " and TYPE='0'";
                }
                if (type.Trim() == "LZ")
                {
                    str += " and TYPE='1'";
                }
                List<Sys_Menu> list = menuBLL.SYS_MenuTreeList(str);
                if (user.USERNAME.ToUpper()=="ADMIN")
                {
                    list = list.Where(o => o.NAME != "生产派工").ToList();
                }
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
        /// 获取历史记录
        /// </summary>
        /// <param name="context"></param>
        private void GetHistoryList(HttpContext context)
        {
            string json = "";
            string str = "";
            try
            {
                string USER_ID = CFunctions.getUserId(context);
                if (USER_ID.Trim() != "")
                {
                    str = string.Format(" and USER_ID='{0}'", USER_ID);
                }

                List<Sys_Hostroy> list = histBLL.GetList(str);
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].TIME = Convert.ToDateTime(list[i].ADDTIME).ToString("yyyy-MM-dd hh:mm:ss");
                }
                json = JsonConvert.SerializeObject(list);
                json = "{IsSuccess:'true',Message:'" + json + "'}";
            }
            catch (Exception e)
            {
                json = "{IsSuccess:'false',Message:'获取数据出现异常！'}";
            }
            json = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 删除历史记录
        /// </summary>
        /// <param name="context"></param>
        private void DeleteHistory(HttpContext context)
        {
            string json = "";
            string str = "";
            try
            {
                string histid = context.Request["ID"];
                if (histid.Trim() != "")
                {
                    str = string.Format(" and ID='{0}'", histid);
                }
                if (histBLL.Delete(str))
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
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 获取用户最后登录页面数据
        /// </summary>
        /// <param name="context"></param>
        private void GetUserLastHistory(HttpContext context)
        {
            string json = "";
            try
            {
                string USER_ID = CFunctions.getUserId(context);
                if (histBLL.CheckHistoryIsHave(USER_ID) > 0)//判断用户有没有浏览记录
                {
                    List<Sys_Hostroy> list = histBLL.GetUserLastHistory(USER_ID);
                    json = JsonConvert.SerializeObject(list);
                    json = "{IsSuccess:'true',Message:'" + json + "'}";
                }
                else
                {
                    json = "{IsSuccess:'true',Message:'false'}";
                }

            }
            catch (Exception e)
            {
                json = "{IsSuccess:'false',Message:'获取数据出现异常！'}";
            }
            json = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        /// <summary>
        /// 获取用户菜单权限
        /// </summary>
        /// <param name="context"></param>
        private void getRoleMenu(HttpContext context)
        {

            Sys_User user = CFunctions.getUser(context);
            string json = "";
            string str = "";
            List<Sys_Menu> menuList = new List<Sys_Menu>();
            try
            {
                string type = context.Request.QueryString["param"];
                if (type.Trim() == "LQ")
                {
                    str += " and TYPE='0'";
                }
                if (type.Trim() == "LZ")
                {
                    str += " and TYPE='1'";
                }
                menuList = menuBLL.SYS_MenuTreeList(str);
                if (user.USERNAME.ToUpper() != "ADMIN")
                {
                    //menuList = menuBLL.GetRoleMenu(user, str);
                    menuList = menuList.Where(o => o.NAME != "生产派工").ToList();
                }
                //else
                //{ 
                //    menuList = menuBLL.SYS_MenuTreeList(str); 
                //}
                 
                json = JsonConvert.SerializeObject(menuList);
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